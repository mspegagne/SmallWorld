using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace Model
{
    public class GameCreator
    {
        private int nbRounds;
        private int nbUnits;
        private IMap map;

        public GameCreator(IMap c)
        {
            this.map = c;

            if (this.map.getSize() == 5)
            {
                this.nbUnits = 4;
                this.nbRounds = 5;
            }
            else if (this.map.getSize() == 10)
            {
                this.nbUnits = 6;
                this.nbRounds = 20;
            }
            else 
            {
                this.nbUnits = 8;
                this.nbRounds = 30;
            }
        }

        //Monteur Partie
        unsafe public IGame buildGame(string pseudo1, IFaction faction1, string pseudo2, IFaction faction2)
        {
           
            IPlayer Player1 = new Player(faction1, this.nbUnits, pseudo1);
            IPlayer Player2 = new Player(faction2, this.nbUnits, pseudo2);

            WrapperAlgo wp = new WrapperAlgo();
            int* posPlayer = wp.placingPlayer(this.map.getSize());

            for (int i = 0; i < this.nbUnits; i++)
            {
                IUnit u = Player1.getUnit(i);
                this.map.getTile(posPlayer[0], posPlayer[1]).addUnit(u);
                IUnit v = Player2.getUnit(i);
                this.map.getTile(posPlayer[2], posPlayer[3]).addUnit(v);
            }

            return new Game(this.nbRounds, Player1, Player2, this.map);
        }

        //Pour partie sauvegardée, non implementée pour le moment...
        public void loadGame()
        {
            throw new System.NotImplementedException();
        }
    }

}
