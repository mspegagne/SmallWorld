using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    [Serializable]
    public class MapSmall : Map
    {
        // map 10*10
        public MapSmall():base(10){}
    }
}
