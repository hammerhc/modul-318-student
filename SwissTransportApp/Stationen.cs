using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransportApp
{
    public class Stationen
    {
        public int StationenId { get; set; }
        public string StationenName { get; set; }
        public string StationenOrt { get; set; }
        public string StationenTyp { get; set; }
        public string StationenEntfernung { get; set; }
        public string StationenMapX { get; set; }
        public string StationenMapY { get; set; }
        public string StationenMapURL { get; set; }
    }
}
