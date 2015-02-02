using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using System.Runtime.Serialization;

namespace Model
{
    [Serializable()]
    public class Game : IGame
    {
        private IPlayer currentPlayer;
        private int nbRounds;
        private int nbRoundsTotal;
        private IPlayer Player2;
        private IPlayer Player1;
        private IMap map;

        //Construit une partie avec n tours, les deux joueurs et la map
        public Game(int n, IPlayer j1, IPlayer j2, IMap c) 
        {
            this.nbRounds = n;
            this.nbRoundsTotal = n;
            this.Player1 = j1;
            this.Player2 = j2;
            this.map = c;
        }

        //Retourne vrai si partie terminée
        public bool end()
        {
            return (this.Player1.getNbUnit() == 0 || this.Player2.getNbUnit() == 0 || this.nbRounds == 0);
        }

        //Renvoie le gagnant
        public IPlayer getWinner()
        {
            //Gagnant aux points 
            if (this.Player1.getNbUnit() == 0 && this.Player2.getNbUnit() == 0)
            {
                if (this.Player1.getWinPts() > this.Player2.getWinPts())
                {
                    return this.Player1;
                }
                else if (this.Player2.getWinPts() > this.Player1.getWinPts())
                {
                    return this.Player2;
                }
            }
            else
            {
                if (this.Player1.getNbUnit() == 0)
                {
                    return this.Player2;
                }
                else if (this.Player2.getNbUnit() == 0)
                {
                    return this.Player1;
                }
            }
            return null;
        }

        //getter NbRounds
        public int getNbRounds()
        {
            return this.nbRounds;
        }

        //getter NbRoundsTotal
        public int getNbRoundsTotal()
        {
            return this.nbRoundsTotal;
        }

        //getter map
        public IMap getMap()
        {
            return this.map;
        }
      
        //Decremente NbRounds
        public void decNbRounds()
        {
            this.nbRounds--;
        }
        
        //Defini le joueur courant à g
        public void setCurrentPlayer(IPlayer g)
        {
            this.currentPlayer = g;
        }
        
        //getter CurrentPlayer
        public IPlayer getCurrentPlayer()
        {
            if (this.currentPlayer == null)
            {
                return getFirstPlayer();
            }
            else
            {
                return this.currentPlayer;
            }
        }

        //getter Player1
        public IPlayer getPlayer1()
        {
            return this.Player1;
        }

        //getter Player2
        public IPlayer getPlayer2()
        {
           return this.Player2;
        }

        //getter FirstPlayer
        public IPlayer getFirstPlayer()
        {
            Random r = new Random();
            int rand = r.Next(1, 3);

            if (rand == 1)
            {
                this.currentPlayer = this.Player1;
                return this.Player1;
            }
            else
            {
                this.currentPlayer = this.Player2;
                return this.Player2;
            }

        }

        //Reinitialisation des pts
        public void reinitialization()
        {
            for (int i = 0; i < this.Player1.getNbUnit(); i++)
            {
                this.Player1.getUnit(i).setMovePts(this.Player1.getUnit(i).defaultMovePts);
                this.Player1.getUnit(i).setAttackPts(this.Player1.getUnit(i).defaultAttackPts);
                this.Player1.getUnit(i).setDefensePts(this.Player1.getUnit(i).defaultDefensePts);
                this.Player1.getUnit(i).setWinPts(0);
            }
            for (int i = 0; i < this.Player2.getNbUnit(); i++)
            {
                this.Player2.getUnit(i).setMovePts(this.Player2.getUnit(i).defaultMovePts);
                this.Player2.getUnit(i).setAttackPts(this.Player2.getUnit(i).defaultAttackPts);
                this.Player2.getUnit(i).setDefensePts(this.Player2.getUnit(i).defaultDefensePts);
                this.Player2.getUnit(i).setWinPts(0);
            }
        }

      
    }

 
    public interface IGame
    {
        bool end();

        IPlayer getWinner();

        int getNbRounds();

        int getNbRoundsTotal();

        IMap getMap();

        void decNbRounds();

        void setCurrentPlayer(IPlayer g);

        IPlayer getCurrentPlayer();

        IPlayer getPlayer1();

        IPlayer getPlayer2();

        IPlayer getFirstPlayer();

        void reinitialization();



    }
}
