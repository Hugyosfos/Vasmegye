using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasmegye
{
    class Szemelyiszam
    {
        readonly string szam;

        public string Szam => szam;

        public Szemelyiszam(string szam)
        {
            this.szam = szam;
 
        }
        public int evSzam()
        {
            int evSzam = int.Parse(Szam.Substring(2, 2));
            evSzam = szam[0] == '1' || szam[0] == '2' ? 1900 + evSzam : 2000 + evSzam;
            return evSzam;
        }
    }
}
