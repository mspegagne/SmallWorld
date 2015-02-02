using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    [Serializable]
    public class MapNormal : Map
    {
        // map 15*15
        public MapNormal():base(15){}
    }
}
