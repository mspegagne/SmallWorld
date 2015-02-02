using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Wrapper;

namespace Model
{
    public class Map : IMap
    {

        private int size;
        private ITileFactory factory;
        private ITile[,] map;

        //Créer une map de taille t
        unsafe public Map(int size)
        {
            this.size = size;
            this.map = new ITile[size, size];
            
            this.factory = new ITileFactory();
            WrapperAlgo wp = new WrapperAlgo();
            int** typeTile = wp.buildMap(size);

            int i, j;
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    this.map[i, j] = factory.makeTile(typeTile[i][j]);
                }
            }
        }

        //Retourne la case de coordonnées x et y
        public ITile getTile(int x, int y)
        {
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            return this.map[x, y];
        }

        //getter size
        public int getSize()
        {
            return this.size;
        }

        //renvoie la comptabilité des points de victoire issus des cases
        //Prend en compte la gestion des bonus
        public int getTilesPts(IPlayer player)
        {
            int total = 0;
            for (int i = 0; i < this.map.GetLength(0); i++)
            {
                for (int j = 0; j < this.map.GetLength(1); j++)
                {
                    if (this.map[i,j].isTile(player))
                    {
                        if (!(player.getFaction() is Dwarf && this.map[i, j] is TilePlain) &&
                            !(player.getFaction() is Orc && this.map[i, j] is TileForest) &&
                            !(player.getFaction() is Human && this.map[i, j] is TileDesert))
                        {
                            total += this.map[i,j].getUnit()[0].getBonusPts();
                        }
                    }
                }
            }
            return total;
        }

    }

    public interface IMap
    {
        ITile getTile(int x, int y);

        int getSize();

        int getTilesPts(IPlayer j);

    }
}
