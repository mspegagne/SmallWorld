using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Model
{
    [Serializable()]
    public class DwarfUnit : Unit
    {
         //Nain
         public DwarfUnit(IPlayer p):base(p){}
    }
}
