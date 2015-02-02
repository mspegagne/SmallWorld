using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public abstract class Tile : ITile
    {
        public List<IUnit> listUnit;

        //initialise listUnit
        public Tile()
        {
            this.listUnit = new List<IUnit>();
        }


        //getter listUnit
        public List<IUnit> getUnit()
        {
            return this.listUnit;
        }

        //renvoie vrai si case ennemie
        public bool isTileEnemy(IPlayer p) 
        {
            bool res = false;
            if (this.listUnit.Count() > 0)
            {
                if (this.listUnit[0].getOwner() != p)
                    res = true;
            }
            return res;
        }

        //Renvoi vrai si case du joueur
        public bool isTile(IPlayer p)
        {
            bool res = false;
            if (this.listUnit.Count() > 0)
            {
                if (this.listUnit[0].getOwner() == p)
                    res = true;
            }
            return res;
        }

        //ajoute une unité sur la case
        public void addUnit(IUnit unit)
        {
            this.listUnit.Add(unit);
        }

        //supprime l'unité de la case
        public void deleteUnit(IUnit unit)
        {
            this.listUnit.Remove(unit);
        }

    }

    public interface ITile
    {
        List<IUnit> getUnit();

        bool isTileEnemy(IPlayer j);

        bool isTile(IPlayer j);

        void addUnit(IUnit unit);

        void deleteUnit(IUnit unit);
    }
}
