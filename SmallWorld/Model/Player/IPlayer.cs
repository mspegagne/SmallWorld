using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public interface IPlayer
    {
        IFaction getFaction();

        String getFactionName();

        int getNbUnit();

        IUnit getUnit(int i);

        void removeUnit(IUnit u);

        void decNbUnit();

        int getPoints();

        string getPseudo();

        void setWinPts(int v);

        int getWinPts();

    }
}
