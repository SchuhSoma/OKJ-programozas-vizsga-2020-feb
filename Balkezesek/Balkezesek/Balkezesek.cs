using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balkezesek
{
    class Balkezesek
    {
        public string Nev;
        public string PalyaraLepes;
        public string PalyarolLelepes;
        public int SulyFontban;
        public int MagassagInchben;

        public Balkezesek(string sor)
        {
            var dbok = sor.Split(';');
            this.Nev = dbok[0];
            this.PalyaraLepes = dbok[1];
            this.PalyarolLelepes = dbok[2];
            this.SulyFontban = int.Parse(dbok[3]);
            this.MagassagInchben = int.Parse(dbok[4]);
        }
    }
}
