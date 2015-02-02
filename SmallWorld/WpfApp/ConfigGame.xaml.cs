using System;
using System.Collections.Generic;
using System.Linq;
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
using Model;
using System.ComponentModel; 

namespace WpfApp
{
    /// <summary>
    /// Logique d'interaction pour ConfigPlayer.xaml
    /// </summary>
    public partial class ConfigPartie : Window
    {
        private IFaction choixPeupleJ1;
        private IFaction choixPeupleJ2;
        private Map map;
        private IGame game;

        private Window mwindow;
        public ConfigPartie(Window mw)
        {
            InitializeComponent();
            this.mwindow = mw;
        }

        // Verifier validite des infos au clic sur le bouton valider
        
        private void Valider(object sender, RoutedEventArgs e)
        {
            if (this.pseudoJ1.Text == "")
            {
                MessageBox.Show("Veuillez renseigner le pseudo du Player 1");
            }
            else if (this.pseudoJ2.Text == "")
            {
                MessageBox.Show("Veuillez renseigner le pseudo du Player 2");
            }
            else if (this.choixPeupleJ1 == null)
            {
                MessageBox.Show("Veuillez choisir un faction pour le Player 1");
            }
            else if (this.choixPeupleJ2 == null)
            {
                MessageBox.Show("Veuillez choisir un faction pour le Player 2");
            }
            else if (this.pseudoJ1.Text == this.pseudoJ2.Text)
            {
                MessageBox.Show("Veuillez choisir des pseudos différents");
            }
            else if (this.choixPeupleJ1.GetType() == this.choixPeupleJ2.GetType())
            {
                MessageBox.Show("Veuillez choisir des factions différents");
            }
            if (this.map == null)
            {
                MessageBox.Show("Veuillez choisir une map");
            }
            else
            {
                GameCreator dieu = new GameCreator(this.map);
                this.game = dieu.buildGame(this.pseudoJ1.Text, this.choixPeupleJ1, this.pseudoJ2.Text, this.choixPeupleJ2);
                FenetreCarte frm = new FenetreCarte(this.game);
                this.mwindow.Close();
                frm.Show();
            }
            
        }

        
        // Choix du peuple Dwarf par le Joueur 1
        
        private void ChoixDwarfJ1(object sender, RoutedEventArgs e)
        {
            this.OrcJ1.StrokeThickness = 0;
            this.ElfJ1.StrokeThickness = 0;
            this.HumanJ1.StrokeThickness = 0;
            this.DwarfJ1.StrokeThickness = 2;
            this.DwarfJ1.Stroke = Brushes.Black;
            this.choixPeupleJ1 = new Dwarf();
        }
        
        // Choix du peuple Orc par le Joueur 1
       
        private void ChoixOrcJ1(object sender, RoutedEventArgs e)
        {
            this.DwarfJ1.StrokeThickness = 0;
            this.ElfJ1.StrokeThickness = 0;
            this.HumanJ1.StrokeThickness = 0;
            this.OrcJ1.StrokeThickness = 2;
            this.OrcJ1.Stroke = Brushes.Black;
            this.choixPeupleJ1 = new Orc();
        }
        
        // Choix du peuple Elf par le Joueur 1
        
        private void ChoixElfJ1(object sender, RoutedEventArgs e)
        {
            this.DwarfJ1.StrokeThickness = 0;
            this.OrcJ1.StrokeThickness = 0;
            this.HumanJ1.StrokeThickness = 0;
            this.ElfJ1.StrokeThickness = 2;
            this.ElfJ1.Stroke = Brushes.Black;
            this.choixPeupleJ1 = new Elf();
        }
        
        // Choix du peuple Human par le Joueur 1
       
        private void ChoixHumanJ1(object sender, RoutedEventArgs e)
        {
            this.DwarfJ1.StrokeThickness = 0;
            this.OrcJ1.StrokeThickness = 0;
            this.ElfJ1.StrokeThickness = 0;
            this.HumanJ1.StrokeThickness = 2;
            this.HumanJ1.Stroke = Brushes.Black;
            this.choixPeupleJ1 = new Human(); 
        }
        
        // Choix du peuple Dwarf de la partie consacrée Joueur 2
        
        private void ChoixDwarfJ2(object sender, RoutedEventArgs e)
        {
            this.OrcJ2.StrokeThickness = 0;
            this.ElfJ2.StrokeThickness = 0;
            this.HumanJ2.StrokeThickness = 0;
            this.DwarfJ2.StrokeThickness = 2;
            this.DwarfJ2.Stroke = Brushes.Black;
            this.choixPeupleJ2 = new Dwarf();
        }
        
        // Choix du peuple Orc par le Joueur 2
        
        private void ChoixOrcJ2(object sender, RoutedEventArgs e)
        {
            this.DwarfJ2.StrokeThickness = 0;
            this.ElfJ2.StrokeThickness = 0;
            this.HumanJ2.StrokeThickness = 0;
            this.OrcJ2.StrokeThickness = 2;
            this.OrcJ2.Stroke = Brushes.Black;
            this.choixPeupleJ2 = new Orc();
        }
        
        // Choix du peuple Elf par le Joueur 2
       
        private void ChoixElfJ2(object sender, RoutedEventArgs e)
        {
            this.DwarfJ2.StrokeThickness = 0;
            this.OrcJ2.StrokeThickness = 0;
            this.HumanJ2.StrokeThickness = 0;
            this.ElfJ2.StrokeThickness = 2;
            this.ElfJ2.Stroke = Brushes.Black;
            this.choixPeupleJ2 = new Elf();
        }
       
        // Choix du peuple Human par le Joueur 2
        
        private void ChoixHumanJ2(object sender, RoutedEventArgs e)
        {
            this.DwarfJ2.StrokeThickness = 0;
            this.OrcJ2.StrokeThickness = 0;
            this.ElfJ2.StrokeThickness = 0;
            this.HumanJ2.StrokeThickness = 2;
            this.HumanJ2.Stroke = Brushes.Black;
            this.choixPeupleJ2 = new Human();
        }

        // Choix de la map Demo

        private void ChoixDemoCarte(object sender, RoutedEventArgs e)
        {
            this.demo.Background = Brushes.Gray;
            this.map = new MapDemo();
        }


        // Choix de la petite map

        private void ChoixPetiteCarte(object sender, RoutedEventArgs e)
        {
            this.petite.Background = Brushes.Gray;
            this.map = new MapSmall();
        }


        // Choix de la map normale

        private void ChoixNormaleCarte(object sender, RoutedEventArgs e)
        {
            this.normale.Background = Brushes.Gray;
            this.map = new MapNormal();
        }

    }
}
