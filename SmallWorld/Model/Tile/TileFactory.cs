using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ITileFactory
    {

        private TileMountain TileMountain;
        private TileDesert TileDesert;
        private TilePlain TilePlain;
        private TileForest TileForest;
        private TileMarsh TileMarsh;

        public ITileFactory() { }
       
        //Créer montagne
        public TileMountain createMountain() 
        {
            this.TileMountain = new TileMountain();
            return TileMountain;
        }

        //Créer plaine
        public TilePlain createPlain()
        {
            this.TilePlain = new TilePlain();
            return TilePlain;
        }

        //Créer desert
        public TileDesert createDesert()
        {
            this.TileDesert = new TileDesert();
            return TileDesert;
        }

        //Créer foret
        public TileForest createForest()
        {
            this.TileForest = new TileForest();
            return TileForest;
        }

        //Créer marais
        public TileMarsh createMarsh()
        {
            this.TileMarsh = new TileMarsh();
            return TileMarsh;
        }
        public Tile makeTile(int type)
        {
            switch (type)
            {
                case 1:
                    return this.createDesert();
                case 2:
                    return this.createForest();
                case 3:
                    return this.createMountain();
                case 4:
                    return this.createPlain();
                case 5:
                    return this.createMarsh();
                default:
                    return this.createForest();
            }
        }
    }
}
