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
        public string AbfahrtstafelAbfahrt { get; set; }
        public string AbfahrtstafelNach { get; set; }
        public string AbfahrtstafelTyp { get; set; }
    }
}
