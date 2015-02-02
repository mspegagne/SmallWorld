using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public abstract class Unit : IUnit
    {
        private const int DEFAULT_HEALTH_PTS = 5;
        private const int DEFAULT_ATTACK_PTS = 2;
        private const int DEFAULT_DEFENSE_PTS = 1;
        private const int DEFAULT_MOVE_PTS = 1;
        private int bonusPts;
        private int attackPts;
        private int defensePts;
        private int healthPts;
        private int winPts;
        private double movePts;
        private IPlayer owner;

        //construit une unité pour p
        public Unit(IPlayer p)
        {
            this.attackPts = DEFAULT_ATTACK_PTS;
            this.defensePts = DEFAULT_DEFENSE_PTS;
            this.healthPts = DEFAULT_HEALTH_PTS;
            this.movePts = DEFAULT_MOVE_PTS;
            this.winPts = 0;
            this.owner = p;
            this.bonusPts = 1;
        }
        

        //incrémente le nombre de pts bonus
        public void incBonusPts()
        {
            this.bonusPts++;
        }

        //vrai si unité vivante
        public bool isAlive()
        {
            return (this.healthPts > 0);
        }

        //getter bonusPts
        public int getBonusPts()
        {
            return this.bonusPts;
        }

        //getter winPts
        public int getWinPts()
        {
            return this.winPts;
        }

        //setter winPts
        public void setWinPts(int v)
        {
            this.winPts = v;
        }

        //getter attackPts
        public int getAttackPts()
        {
           return this.attackPts;
        }

        //setter attackPts
        public void setAttackPts(int a)
        {
            this.attackPts = a;
            if (this.attackPts < 0)
                this.attackPts = 0;
        }

        //getter defensePts
        public int getDefensePts()
        {
            return this.defensePts;
        }

        //setter defensePts
        public void setDefensePts(int d)
        {
            this.defensePts = d;
            if (this.defensePts < 0)
                this.defensePts = 0;
        }

        //getter movePts
        public double getMovePts()
        {
            return this.movePts;
        }

        //setter movePts
        public void setMovePts(double m)
        {
            this.movePts = m;
            if (this.movePts < 0)
                this.movePts = 0;
        }
        
        //getter healthPts
        public int getHealthPts()
        {
            return this.healthPts;
        }

        //setter healthPts
        public void setHealthPts(int v)
        {
            this.healthPts = v;
        }
    
        //getter owner
        public IPlayer getOwner()
        {
            return this.owner;
        }

        //getter DEFAULT_HEALTH_PTS
        public int defaultHealthPts
        {
            get { return DEFAULT_HEALTH_PTS; }
        }

        //getter DEFAULT_MOVE_PTS
        public int defaultMovePts
        {
            get { return DEFAULT_MOVE_PTS; }
        }

        //getter DEFAULT_ATTACK_PTS
        public int defaultAttackPts
        {
            get { return DEFAULT_ATTACK_PTS; }
        }

        //getter DEFAULT_DEFENSE_PTS
        public int defaultDefensePts
        {
            get { return DEFAULT_DEFENSE_PTS; }
        }

    }
}
