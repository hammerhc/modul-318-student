using SwissTransport;
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
        private ITransport transportAPI;
        public MainWindow()
        {
            InitializeComponent();

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

        private void btnVerbindungSuchenClick(object sender, RoutedEventArgs e)
        {
            string verbindungenVon = "";
            string verbindungenNach = "";
            DateTime? verbindungenDatum = DateTime.Now;
            dateVerbindungenDate.SelectedDate = verbindungenDatum;
            string verbindungenZeit = DateTime.Now.ToString();
            txtVerbindungenTime.Text = verbindungenZeit;

            if (txtVerbindungenVon.Text.Length > 0)
            {
                verbindungenVon = txtVerbindungenVon.Text;
            } 
            else
            {
                showError("Von ist leer");
            }
            if (txtVerbindungenNach.Text.Length > 0)
            {
                verbindungenNach = txtVerbindungenNach.Text;
            }
            else
            {
                showError("Nach ist leer");
            }
            if (dateVerbindungenDate.SelectedDate >= DateTime.Now)
            {
                verbindungenDatum = dateVerbindungenDate.SelectedDate;
            }
            else
            {
                showError("Datum ist leer oder kleiner");
            }
            if (txtVerbindungenTime.Text.Length > 0)
            {
                verbindungenZeit = txtVerbindungenTime.Text;
            } else
            {
                showError("Zeit ist leer");
            }
            bool? verbindungenAb = radioBtnVerbindungenAb.IsChecked;
            bool? verbindungenAn = radioBtnVerbindungenAn.IsChecked;

            transportAPI = new Transport();
            var test = transportAPI.GetConnections(verbindungenVon, verbindungenNach);
            int id = 0;
            foreach (var line in test.ConnectionList)
            {
                verbindungList.Add(new Verbindungen { VerbindungId = id, VerbindungAb = line.From.Station.Name, VerbindungAn = line.To.Station.Name, VerbindungDauer = line.Duration, VerbindungGleisAb = line.From.Platform, VerbindungGleisAn = line.To.Platform });
                id++;
            }
            dataGridVerbindung.ItemsSource = verbindungList;
        }

        private void btnAbfahrtstafelSuchenClick(object sender, RoutedEventArgs e)
        {
            string station = "";
            if (txtStation.Text.Length > 0)
            {
                station = txtStation.Text;
            }
            else
            {
                showError("Station ist leer");
            }

            transportAPI = new Transport();
            var test = transportAPI.GetStations(station);
            string stationId = "";
            foreach (var line in test.StationList)
            {
                if (line.Name == station)
                {
                    stationId = line.Id;
                }
            }

            if (stationId.Length > 0)
            {
                var test2 = transportAPI.GetStationBoard(station, stationId);
                int id = 0;
                foreach (var line in test2.Entries)
                {
                    abfahrtstafelList.Add(new Abfahrtstafel { AbfahrtstafelId = id, AbfahrtstafelAbfahrt = line.Stop.Departure.ToString(), AbfahrtstafelNach = line.To, AbfahrtstafelTyp = line.Name});
                }
            }
            dataGridAbfahrtstafel.ItemsSource = abfahrtstafelList;
        }

        private void showError(string message)
        {
            MessageBox.Show(message);
        }
    }
}
