using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    public abstract class GameBuilder : IGameBuilder
    {
        public StrategieMap StrategieMap
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public void remplirTiles()
        {
            throw new System.NotImplementedException();
        }

        public void setStrategie()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IGameBuilder
    {
        void setStrategie();

        void remplirTiles();
    }
}
