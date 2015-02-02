using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public interface IUnit
    {
        bool isAlive();

        int getAttackPts();

        int getDefensePts();

        double getMovePts();

        void incBonusPts();

        int getBonusPts();

        int getHealthPts();

        void setAttackPts(int a);

        void setDefensePts(int d);

        void setMovePts(double m);

        void setHealthPts(int v);

        IPlayer getOwner();

        int defaultHealthPts { get; }

        int defaultMovePts { get; }
        
        int defaultAttackPts { get; }

        int defaultDefensePts { get; }

        void setWinPts(int v);

        int getWinPts();
    }
}
