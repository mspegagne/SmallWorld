using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    [Serializable()]
    public class ElfUnit : Unit
    {
         //Elf
         public ElfUnit(IPlayer p):base(p){}
    }
}
