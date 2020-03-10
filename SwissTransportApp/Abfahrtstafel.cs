using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransportApp
{
    public class Abfahrtstafel
    {
        public int AbfahrtstafelId { get; set; }
        public string AbfahrtstafelAb { get; set; }
        public string AbfahrtstafelAn { get; set; }
        public string AbfahrtstafelDauer { get; set; }
        public string AbfahrtstafelGleisAb { get; set; }
        public string AbfahrtstafelGleisAn { get; set; }
    }
}
