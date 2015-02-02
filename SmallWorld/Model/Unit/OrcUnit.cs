using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Model
{
    [Serializable()]
    public class OrcUnit : Unit
    {        
         //Orc
         public OrcUnit(IPlayer p):base(p){}
    }
}
