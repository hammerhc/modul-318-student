using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SwissTransportApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Verbindungen> verbindungList = new List<Verbindungen>();
        List<Abfahrtstafel> abfahrtstafelList = new List<Abfahrtstafel>();
        List<Stationen> stationenList = new List<Stationen>();
        public MainWindow()
        {
            InitializeComponent();

            verbindungList.Add(new Verbindungen { VerbindungId = 1, VerbindungAb = "Luzern, 12:00", VerbindungAn = "Sursee, 13:00", VerbindungDauer = "60 min", VerbindungGleisAb = "Gl.3", VerbindungGleisAn = "Gl.3" });
            verbindungList.Add(new Verbindungen { VerbindungId = 1, VerbindungAb = "Luzern, 12:00", VerbindungAn = "Sursee, 13:00", VerbindungDauer = "60 min", VerbindungGleisAb = "Gl.3", VerbindungGleisAn = "Gl.3" });
            verbindungList.Add(new Verbindungen { VerbindungId = 1, VerbindungAb = "Luzern, 12:00", VerbindungAn = "Sursee, 13:00", VerbindungDauer = "60 min", VerbindungGleisAb = "Gl.3", VerbindungGleisAn = "Gl.3" });
            verbindungList.Add(new Verbindungen { VerbindungId = 1, VerbindungAb = "Luzern, 12:00", VerbindungAn = "Sursee, 13:00", VerbindungDauer = "60 min", VerbindungGleisAb = "Gl.3", VerbindungGleisAn = "Gl.3" });
            verbindungList.Add(new Verbindungen { VerbindungId = 1, VerbindungAb = "Luzern, 12:00", VerbindungAn = "Sursee, 13:00", VerbindungDauer = "60 min", VerbindungGleisAb = "Gl.3", VerbindungGleisAn = "Gl.3" });
            verbindungList.Add(new Verbindungen { VerbindungId = 1, VerbindungAb = "Luzern, 12:00", VerbindungAn = "Sursee, 13:00", VerbindungDauer = "60 min", VerbindungGleisAb = "Gl.3", VerbindungGleisAn = "Gl.3" });
            verbindungList.Add(new Verbindungen { VerbindungId = 1, VerbindungAb = "Luzern, 12:00", VerbindungAn = "Sursee, 13:00", VerbindungDauer = "60 min", VerbindungGleisAb = "Gl.3", VerbindungGleisAn = "Gl.3" });
            verbindungList.Add(new Verbindungen { VerbindungId = 1, VerbindungAb = "Luzern, 12:00", VerbindungAn = "Sursee, 13:00", VerbindungDauer = "60 min", VerbindungGleisAb = "Gl.3", VerbindungGleisAn = "Gl.3" });
            verbindungList.Add(new Verbindungen { VerbindungId = 1, VerbindungAb = "Luzern, 12:00", VerbindungAn = "Sursee, 13:00", VerbindungDauer = "60 min", VerbindungGleisAb = "Gl.3", VerbindungGleisAn = "Gl.3" });
            verbindungList.Add(new Verbindungen { VerbindungId = 1, VerbindungAb = "Luzern, 12:00", VerbindungAn = "Sursee, 13:00", VerbindungDauer = "60 min", VerbindungGleisAb = "Gl.3", VerbindungGleisAn = "Gl.3" });
            verbindungList.Add(new Verbindungen { VerbindungId = 1, VerbindungAb = "Luzern, 12:00", VerbindungAn = "Sursee, 13:00", VerbindungDauer = "60 min", VerbindungGleisAb = "Gl.3", VerbindungGleisAn = "Gl.3" });
            verbindungList.Add(new Verbindungen { VerbindungId = 1, VerbindungAb = "Luzern, 12:00", VerbindungAn = "Sursee, 13:00", VerbindungDauer = "60 min", VerbindungGleisAb = "Gl.3", VerbindungGleisAn = "Gl.3" });
            verbindungList.Add(new Verbindungen { VerbindungId = 1, VerbindungAb = "Luzern, 12:00", VerbindungAn = "Sursee, 13:00", VerbindungDauer = "60 min", VerbindungGleisAb = "Gl.3", VerbindungGleisAn = "Gl.3" });
            dataGridVerbindung.ItemsSource = verbindungList;

            abfahrtstafelList.Add(new Abfahrtstafel { AbfahrtstafelId = 1, AbfahrtstafelAb = "Luzern, 12:00", AbfahrtstafelAn = "Sursee, 13:00", AbfahrtstafelDauer = "60 min", AbfahrtstafelGleisAb = "Gl.3", AbfahrtstafelGleisAn = "Gl.3" });
            abfahrtstafelList.Add(new Abfahrtstafel { AbfahrtstafelId = 1, AbfahrtstafelAb = "Luzern, 12:00", AbfahrtstafelAn = "Sursee, 13:00", AbfahrtstafelDauer = "60 min", AbfahrtstafelGleisAb = "Gl.3", AbfahrtstafelGleisAn = "Gl.3" });
            abfahrtstafelList.Add(new Abfahrtstafel { AbfahrtstafelId = 1, AbfahrtstafelAb = "Luzern, 12:00", AbfahrtstafelAn = "Sursee, 13:00", AbfahrtstafelDauer = "60 min", AbfahrtstafelGleisAb = "Gl.3", AbfahrtstafelGleisAn = "Gl.3" });
            abfahrtstafelList.Add(new Abfahrtstafel { AbfahrtstafelId = 1, AbfahrtstafelAb = "Luzern, 12:00", AbfahrtstafelAn = "Sursee, 13:00", AbfahrtstafelDauer = "60 min", AbfahrtstafelGleisAb = "Gl.3", AbfahrtstafelGleisAn = "Gl.3" });
            abfahrtstafelList.Add(new Abfahrtstafel { AbfahrtstafelId = 1, AbfahrtstafelAb = "Luzern, 12:00", AbfahrtstafelAn = "Sursee, 13:00", AbfahrtstafelDauer = "60 min", AbfahrtstafelGleisAb = "Gl.3", AbfahrtstafelGleisAn = "Gl.3" });
            abfahrtstafelList.Add(new Abfahrtstafel { AbfahrtstafelId = 1, AbfahrtstafelAb = "Luzern, 12:00", AbfahrtstafelAn = "Sursee, 13:00", AbfahrtstafelDauer = "60 min", AbfahrtstafelGleisAb = "Gl.3", AbfahrtstafelGleisAn = "Gl.3" });
            abfahrtstafelList.Add(new Abfahrtstafel { AbfahrtstafelId = 1, AbfahrtstafelAb = "Luzern, 12:00", AbfahrtstafelAn = "Sursee, 13:00", AbfahrtstafelDauer = "60 min", AbfahrtstafelGleisAb = "Gl.3", AbfahrtstafelGleisAn = "Gl.3" });
            abfahrtstafelList.Add(new Abfahrtstafel { AbfahrtstafelId = 1, AbfahrtstafelAb = "Luzern, 12:00", AbfahrtstafelAn = "Sursee, 13:00", AbfahrtstafelDauer = "60 min", AbfahrtstafelGleisAb = "Gl.3", AbfahrtstafelGleisAn = "Gl.3" });
            abfahrtstafelList.Add(new Abfahrtstafel { AbfahrtstafelId = 1, AbfahrtstafelAb = "Luzern, 12:00", AbfahrtstafelAn = "Sursee, 13:00", AbfahrtstafelDauer = "60 min", AbfahrtstafelGleisAb = "Gl.3", AbfahrtstafelGleisAn = "Gl.3" });
            abfahrtstafelList.Add(new Abfahrtstafel { AbfahrtstafelId = 1, AbfahrtstafelAb = "Luzern, 12:00", AbfahrtstafelAn = "Sursee, 13:00", AbfahrtstafelDauer = "60 min", AbfahrtstafelGleisAb = "Gl.3", AbfahrtstafelGleisAn = "Gl.3" });
            abfahrtstafelList.Add(new Abfahrtstafel { AbfahrtstafelId = 1, AbfahrtstafelAb = "Luzern, 12:00", AbfahrtstafelAn = "Sursee, 13:00", AbfahrtstafelDauer = "60 min", AbfahrtstafelGleisAb = "Gl.3", AbfahrtstafelGleisAn = "Gl.3" });
            abfahrtstafelList.Add(new Abfahrtstafel { AbfahrtstafelId = 1, AbfahrtstafelAb = "Luzern, 12:00", AbfahrtstafelAn = "Sursee, 13:00", AbfahrtstafelDauer = "60 min", AbfahrtstafelGleisAb = "Gl.3", AbfahrtstafelGleisAn = "Gl.3" });
            dataGridAbfahrtstafel.ItemsSource = abfahrtstafelList;

            stationenList.Add(new Stationen { StationenId = 1, StationenName = "Bahnhof Sursee", StationenOrt = "Sursee", StationenTyp = "Bahnhof", StationenEntfernung = "10km", StationenMapX = "34324345", StationenMapY = "3453134213", StationenMapURL = "www.google.ch/maps" });
            stationenList.Add(new Stationen { StationenId = 1, StationenName = "Bahnhof Sursee", StationenOrt = "Sursee", StationenTyp = "Bahnhof", StationenEntfernung = "10km", StationenMapX = "34324345", StationenMapY = "3453134213", StationenMapURL = "www.google.ch/maps" });
            stationenList.Add(new Stationen { StationenId = 1, StationenName = "Bahnhof Sursee", StationenOrt = "Sursee", StationenTyp = "Bahnhof", StationenEntfernung = "10km", StationenMapX = "34324345", StationenMapY = "3453134213", StationenMapURL = "www.google.ch/maps" });
            stationenList.Add(new Stationen { StationenId = 1, StationenName = "Bahnhof Sursee", StationenOrt = "Sursee", StationenTyp = "Bahnhof", StationenEntfernung = "10km", StationenMapX = "34324345", StationenMapY = "3453134213", StationenMapURL = "www.google.ch/maps" });
            stationenList.Add(new Stationen { StationenId = 1, StationenName = "Bahnhof Sursee", StationenOrt = "Sursee", StationenTyp = "Bahnhof", StationenEntfernung = "10km", StationenMapX = "34324345", StationenMapY = "3453134213", StationenMapURL = "www.google.ch/maps" });
            stationenList.Add(new Stationen { StationenId = 1, StationenName = "Bahnhof Sursee", StationenOrt = "Sursee", StationenTyp = "Bahnhof", StationenEntfernung = "10km", StationenMapX = "34324345", StationenMapY = "3453134213", StationenMapURL = "www.google.ch/maps" });
            stationenList.Add(new Stationen { StationenId = 1, StationenName = "Bahnhof Sursee", StationenOrt = "Sursee", StationenTyp = "Bahnhof", StationenEntfernung = "10km", StationenMapX = "34324345", StationenMapY = "3453134213", StationenMapURL = "www.google.ch/maps" });
            stationenList.Add(new Stationen { StationenId = 1, StationenName = "Bahnhof Sursee", StationenOrt = "Sursee", StationenTyp = "Bahnhof", StationenEntfernung = "10km", StationenMapX = "34324345", StationenMapY = "3453134213", StationenMapURL = "www.google.ch/maps" });
            stationenList.Add(new Stationen { StationenId = 1, StationenName = "Bahnhof Sursee", StationenOrt = "Sursee", StationenTyp = "Bahnhof", StationenEntfernung = "10km", StationenMapX = "34324345", StationenMapY = "3453134213", StationenMapURL = "www.google.ch/maps" });
            dataGridStationen.ItemsSource = stationenList;
        }
    }
}
