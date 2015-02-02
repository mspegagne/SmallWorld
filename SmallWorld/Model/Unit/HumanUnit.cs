using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Model
{
    [Serializable()]
    public class HumanUnit : Unit
    {
        //Human
         public HumanUnit(IPlayer p):base(p){}
    }
}
