using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransportApp
{
    public class Verbindungen
    {
        public int VerbindungId { get; set; }
        public string VerbindungAb { get; set; }
        public string VerbindungAn { get; set; }
        public string VerbindungDauer { get; set; }
        public string VerbindungGleisAb { get; set; }
        public string VerbindungGleisAn { get; set; }
    }
}
