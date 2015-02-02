using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Player : IPlayer
    {
        private string pseudo;
        private IFaction faction;
        private List<IUnit> listUnit;
        private int nbUnit;
        private int winPts;

        //Constructeur avec peuple p, nombre unité n et pseudo s
        public Player(IFaction p, int n, string s)
        {
            this.nbUnit = n;
            this.faction = p;
            this.pseudo = s;
            this.listUnit = new List<IUnit>();

            if (this.faction is Elf)
            {
                for (int i = 0; i < nbUnit; i++)
                {
                    this.listUnit.Add(new ElfUnit(this));
                }
            }
            else if (this.faction is Orc)
            {
                for (int i = 0; i < nbUnit; i++)
                {
                    this.listUnit.Add(new OrcUnit(this));
                }
            }
            else if (this.faction is Dwarf)
            {
                for (int i = 0; i < nbUnit; i++)
                {
                    this.listUnit.Add(new DwarfUnit(this));
                }
            }
            else if (this.faction is Human)
            {
                for (int i = 0; i < nbUnit; i++)
                {
                    this.listUnit.Add(new HumanUnit(this));
                }
            }
        }


        //getter peuple
        public IFaction getFaction()
        {
            return this.faction;
        }

        //getter nom peuple
        public String getFactionName()
        {
            if (this.faction is Elf)
            {
                return "Elfe";
            }
            else if (this.faction is Dwarf)
            {
                return "Nain";
            } 
            else if(this.faction is Orc)
            {
                return "Orc";
            }
            else if (this.faction is Human)
            {
                return "Humain";
            }
            return "";
        }

        //getter de l'unité numéro i
        public IUnit getUnit(int i)
        {
            return this.listUnit[i];
        }

        //supprime l'unité u de la liste
        public void removeUnit(IUnit u)
        {
            this.listUnit.Remove(u);
        }

        //getter pseudo
        public string getPseudo()
        {
            return this.pseudo;
        }

        //ajoute v points de victoire
        public void setWinPts(int v)
        {
            this.winPts += v;
        }

        //getter points de victoire
        public int getWinPts()
        {
            return this.winPts;
        }

        //getter nombre d'unités
        public int getNbUnit()
        {
            return this.nbUnit;
        }

        //decremente le nb d'unités
        public void decNbUnit()
        {
            this.nbUnit--;
        }

        //calcule le nb de points
        public int getPoints()
        {
            int total = 0;
            foreach (IUnit unit in listUnit)
            {
                total += unit.getWinPts();
            }
            return total;
        }

    }
}
