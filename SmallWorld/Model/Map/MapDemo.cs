using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    [Serializable]
    public class MapDemo : Map
    {
        // map 5*5
        public MapDemo():base(5){}
    }
}
