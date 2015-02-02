using Microsoft.Win32;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wrapper;

namespace WpfApp
{

    public partial class FenetreCarte : Window
    {
        
        private IGame game;
        private Round round;
        private int nbRoundInit = 1;
        private IPlayer player;
        private Unit[,] selectUnit;
        private int selectX;
        private int selectY;
        private Border[,] unitBoard;
        private Grid unitGrid;
        private Border selectedTile;
        private Grid selectedGrid;
        private Boolean twoPlayerRound;
        private Border[,] boardTip;
        private Border clicTile;
        private const int tailleCase = 96;
        private const int numMaxImg = 11;

        public FenetreCarte(IGame j)
        {

            InitializeComponent();

            this.game = j;
            this.selectedGrid = new Grid();
            this.boardTip = new Border[this.game.getMap().getSize(), this.game.getMap().getSize()];
            this.unitBoard = new Border[this.game.getMap().getSize(), this.game.getMap().getSize()];
            this.selectUnit = new Unit[this.game.getMap().getSize(), this.game.getMap().getSize()];
            this.player = this.game.getCurrentPlayer();
            this.round = new Round(this.game, this.player);
            this.selectX = -1;
            this.selectY = -1;
            this.Menu.Text = "Tour " + (this.game.getNbRoundsTotal()-this.game.getNbRounds()+1) + " sur " + this.game.getNbRoundsTotal();
            this.twoPlayerRound = false;
            this.clicTile = null;
            informationsJoueur();
            this.mapGrid.Focus();
          
        }
      
        
        /// Remplissage de la map
        
        private void creerCarte(object sender, RoutedEventArgs e)
        {
            int t = 0;
            int l = 0;

            for (int x = 0; x < this.game.getMap().getSize(); x++)
            {
                if ((x % 2) != 0)
                    l = 50;
                else
                    l = 0;

                for (int y = 0; y < this.game.getMap().getSize(); y++)
                {
                    // Creation et positionnement de la case
                    Border hexagone = new Border();
                    hexagone.Background = FabriqueImage.getInstance().getBrushCase(this.game.getMap().getTile(x, y));
                    Canvas.SetLeft(hexagone, l);
                    Canvas.SetTop(hexagone, t);
                    hexagone.Width = tailleCase;
                    hexagone.Height = tailleCase;
                    hexagone.Cursor = Cursors.Hand;
                    hexagone.MouseLeftButtonDown += new MouseButtonEventHandler(this.clicGaucheCase);
                    hexagone.MouseEnter += new MouseEventHandler(this.survolCase);
                    this.mapGrid.Children.Add(hexagone);
                    l = l + 100;
                }
                t = t + 75;
            }

            // Determine la taille du canvas
            this.mapGrid.Width = this.game.getMap().getSize() * 100;
            this.mapGrid.Height = this.game.getMap().getSize() * 75;
            this.mapGrid.HorizontalAlignment = HorizontalAlignment.Center;
            this.mapGrid.VerticalAlignment = VerticalAlignment.Center;

            // Ajoute les unites sur la map
            ajoutUnite();

            // Selectionne la premiere case cliquee
            if (this.game.getMap().getTile(0, 0).isTile(this.player))
            {
                this.selectX = 0;
                this.selectY = 0;
            }
            else
            {
                this.selectX = this.game.getMap().getSize() - 1;
                this.selectY = this.game.getMap().getSize() - 1;
            }
            selectionCase();
        }

        
        /// Placement des unités sur la map
        
        private void ajoutUnite()
        {
            int t = 0;
            int l = 10;

            // Supprime les anciennes unites
            for (int x = 0; x < this.unitBoard.GetLength(0); x++)
            {
                for (int y = 0; y < this.unitBoard.GetLength(1); y++)
                {
                    this.mapGrid.Children.Remove(this.unitBoard[x, y]);
                }
            }


            for (int x = 0; x < this.unitBoard.GetLength(0); x++)
            {
                if ((x % 2) != 0)
                    l = 50;
                else
                    l = 0;

                for (int y = 0; y < this.unitBoard.GetLength(1); y++)
                {
                    List<IUnit> units = this.game.getMap().getTile(x, y).getUnit();

                    if (units.Count() > 0)
                    {
                        // Ajout image unit
                        Border hexagoneUnite = new Border();
                        hexagoneUnite.Background = FabriqueImage.getInstance().getBrushUnite(units[0]);
                        TextBlock unitText = new TextBlock();
                        hexagoneUnite.Width = tailleCase;
                        hexagoneUnite.Height = tailleCase;

                        hexagoneUnite.MouseLeftButtonDown += new MouseButtonEventHandler(this.clicGaucheCase);
                        hexagoneUnite.MouseEnter += new MouseEventHandler(this.survolCase);
                        this.unitBoard[x, y] = hexagoneUnite;
                        this.mapGrid.Children.Add(hexagoneUnite);
                    }
                    l = l + 100;
                }
                t = t + 75;
            }
        }


        
        
        private int getY(double coordY)
        {
            if (coordY == 0)
                return 0;
            return (int)(coordY / 75);
        }

        private int getX(double coordX)
        {
            if (coordX == 0)
                return 0;
            if ((coordX % 100) != 0)
                coordX -= 50;
            return (int)(coordX / 100);
        }


        
        // Clic sur une case 
       
        private void clicGaucheCase(object sender, MouseButtonEventArgs e)
        {
            var selection = sender as Border;

            this.selectX = this.getX(Canvas.GetLeft(selection));
            this.selectY = this.getY(Canvas.GetTop(selection));
            selectionCase();

        }

        
        // Selection d'une case
        
        private void selectionCase()
        {
            // Supprime bordure de l'ancienne case selectionnee
            if (this.clicTile != null)
                this.mapGrid.Children.Remove(this.clicTile);

            // Ajoute bordure sur la nouvelle case selectionnee
            Border bordure = new Border();
            bordure.Background = FabriqueImage.getInstance().getSelection(true);
            bordure.Width = tailleCase;
            bordure.Height = tailleCase;
            bordure.Cursor = Cursors.Hand;
            bordure.MouseLeftButtonDown += new MouseButtonEventHandler(this.clicGaucheCase);
            bordure.MouseEnter += new MouseEventHandler(this.survolCase);
            int ligne1 = 0;
            if (this.selectY % 2 != 0)
            {
                ligne1 = (this.selectX * 100) + 50;
            }
            else
            {
                ligne1 = this.selectX * 100;
            }

            Canvas.SetLeft(bordure, ligne1);
            Canvas.SetTop(bordure, this.selectY * 75);
            this.mapGrid.Children.Add(bordure);
            this.clicTile = bordure;

            // Affiche les unites de la case selectionnee
            afficherUniteCase(this.game.getMap().getTile(this.selectY, this.selectX).getUnit());

        }


        
        // Survol sur une case
        
        private void survolCase(object sender, MouseEventArgs e)
        {
            // Supprimer ancienne case survolee
            if (this.selectedTile != null)
                this.mapGrid.Children.Remove(this.selectedTile);

            // Ajoute une bordure auround de la case survolee
            var selection = sender as Border;
            Border bordure = new Border();
            bordure.Background = FabriqueImage.getInstance().getSelection(false);
            bordure.Width = tailleCase;
            bordure.Height = tailleCase;
            bordure.Cursor = Cursors.Hand;
            bordure.MouseLeftButtonDown += new MouseButtonEventHandler(this.clicGaucheCase);
            Canvas.SetLeft(bordure, Canvas.GetLeft(selection));
            Canvas.SetTop(bordure, Canvas.GetTop(selection));
            this.mapGrid.Children.Add(bordure);
            this.selectedTile = bordure;

            
            if (this.game.getMap().getTile(this.getY(Canvas.GetTop(selection)), this.getX(Canvas.GetLeft(selection))).getUnit().Count() > 0)
            {
                afficherUniteCase(this.game.getMap().getTile(this.getY(Canvas.GetTop(selection)), this.getX(Canvas.GetLeft(selection))).getUnit());
            }
            else if (this.game.getMap().getTile(this.selectX, this.selectY).getUnit().Count() > 0)
            {
                afficherUniteCase(this.game.getMap().getTile(this.selectX, this.selectY).getUnit());
            }

        }

        
        private void effacementGrilleUnite()
        {
            this.barreInfo.Children.Remove(this.unitGrid);
        }



        // Affichage des unités

        private void afficherUniteCase(List<IUnit> lunite)
        {
            //effacerSelection();
            string vie = "";
            string attaque = "";
            string defense = "";
            string mouvement = "";
            int i = 0;
            int j = 0;
            int cpt = 0;
            effacementGrilleUnite();

            //On vérifie que la case contient bien des unités
            if (lunite.Count() > 0)
            {
                //Création de la grille qui va contenir les unités dans la barre d'information
                unitGrid = new Grid();
                for (i = 0; i < 3; i++)
                {
                    unitGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(3, GridUnitType.Star) });
                    unitGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3, GridUnitType.Star) });
                }
                Grid.SetRow(unitGrid, 0);
                Grid.SetColumn(unitGrid, 1);
                this.barreInfo.Children.Add(unitGrid);
                this.unitGrid.Focus();

                for (i = 0; i < 5; i++)
                {
                    for (j = 0; j < 2; j++)
                    {
                        if (cpt < lunite.Count())
                        {
                            //Mise en place de la grille interne
                            Grid grille = new Grid();
                            //grille.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                            grille.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(3, GridUnitType.Star) });
                            Grid.SetRow(grille, i);
                            Grid.SetColumn(grille, j);                          
                            grille.Cursor = Cursors.Hand;
                            unitGrid.Children.Add(grille);

                            //Ajout de l'image de l'unité à la grille interne
                            Rectangle image = new Rectangle();
                            image.Fill = FabriqueImage.getInstance().getBrushUnite(lunite[cpt]);
                            image.Width = tailleCase;
                            image.Height = tailleCase;
                            image.HorizontalAlignment = HorizontalAlignment.Center;
                            Grid.SetRow(image, 0);
                            Grid.SetColumn(image, 0);
                            grille.Children.Add(image);

                            //Ajout des caractéristiques de l'unité à la grille interne
                            TextBlock texte = new TextBlock();
                            texte.TextAlignment = TextAlignment.Left;
                            vie = "Vie : " + lunite[cpt].getHealthPts();
                            mouvement = "Mouvement : " + lunite[cpt].getMovePts();
                            attaque = "Attaque : " + lunite[cpt].getAttackPts();
                            defense = "Defense : " + lunite[cpt].getDefensePts();
                            texte.Text = vie + "\n" + mouvement + "\n" + attaque + "\n" + defense;
                            Grid.SetRow(texte, 1);
                            Grid.SetColumn(texte, 0);
                            grille.Children.Add(texte);

                            // Enregistre les unites
                            this.selectUnit[i, j] = (Unit) lunite[cpt];
                            cpt++;
                        }
                    }
                }
            }
        }


        
     




        
        // Affichage des informations joueurs
       
        private void informationsJoueur()
        {
            string uniteRestantes = "";
            string pointVictoire = "";
            string peuple = "";

            // player 1
            this.pseudoJ1.Text = this.game.getPlayer1().getPseudo();
            peuple = "Peuple " + this.game.getPlayer1().getFaction() + "\n";
            uniteRestantes = this.game.getPlayer1().getNbUnit() + " unités restantes\n";
            pointVictoire = this.game.getPlayer1().getWinPts() + " points.\n";
            this.infoJ1.Text = peuple + uniteRestantes + pointVictoire;

            // player 2
            this.pseudoJ2.Text = this.game.getPlayer2().getPseudo();
            peuple = "Peuple " + this.game.getPlayer2().getFaction() + "\n";
            uniteRestantes = this.game.getPlayer2().getNbUnit() + " unités restantes\n";
            pointVictoire = this.game.getPlayer2().getWinPts() + " points.\n";
            this.infoJ2.Text = peuple + uniteRestantes + pointVictoire;
        }


        private void FinTour_Click(object sender, RoutedEventArgs e)
        {
            FinDuTour();
        }
        
        // Bouton fin du round

        private void FinDuTour()
        {            
            if (this.game.getNbRounds() > 1 && (this.game.end() == false))
            {               
                if (this.twoPlayerRound)
                {                  
                    this.game.getPlayer1().setWinPts(this.game.getPlayer1().getPoints() + this.game.getMap().getTilesPts(this.game.getPlayer1()));
                    this.game.getPlayer2().setWinPts(this.game.getPlayer2().getPoints() + this.game.getMap().getTilesPts(this.game.getPlayer2()));                    
                    this.game.decNbRounds();
                    this.game.reinitialization();
                    this.nbRoundInit++;
                    this.twoPlayerRound = false;
                }
                else
                {
                  this.twoPlayerRound = true;
                }

                // Switch player
                if (this.player == this.game.getPlayer1())
                {
                    this.player = this.game.getPlayer2();
                    this.game.setCurrentPlayer(this.player);
                }
                else
                {
                    this.player = this.game.getPlayer1();
                    this.game.setCurrentPlayer(this.player);
                }

                // Nouveau round
                this.round = new Round(this.game, this.player);               
                this.Menu.Text = "Tour " + (this.game.getNbRoundsTotal() - this.game.getNbRounds() + 1) + " sur " + this.game.getNbRoundsTotal();
                informationsJoueur();

                // Affiche les unites sur la case selectionnee
                afficherUniteCase(this.game.getMap().getTile(this.selectY, this.selectX).getUnit());

            }
            else
            {
                // Determine le gagnant et on affiche le résultat
                if (this.game.getWinner() == this.game.getPlayer1())
                {
                    MessageBox.Show("Le gagnant est " + this.game.getPlayer1().getPseudo() + ".");
                }
                else if (this.game.getWinner() == this.game.getPlayer2())
                {
                    MessageBox.Show("Le gagnant est " + this.game.getPlayer2().getPseudo() + ".");
                }
                else
                {
                    MessageBox.Show("Égalité.");
                }
            }
        }


       

     
    }
}
