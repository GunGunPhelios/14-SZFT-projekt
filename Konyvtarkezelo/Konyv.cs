using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtarkezelo
{
    internal class Konyv
    {
        public string Cim {  get; set; }
        public string Szerzo { get; set; }
        public string Kategoria { get; set; }

        public int Kiadas_ev {  get; set; }

        public int Oldalszam { get; set; }

        public Konyv()
        {
            
        }

        public Konyv(string cim, string szerzo, string kategoria, int kiadas_ev, int oldalszam)
        {
            Cim = cim;
            Szerzo = szerzo;
            Kategoria = kategoria;
            Kiadas_ev = kiadas_ev;
            Oldalszam = oldalszam;
        }

        public override string ToString()
        {
                return $"{Cim}- {Szerzo} - {Kategoria}- {Kiadas_ev} - {Oldalszam}";
        }
    }
}
