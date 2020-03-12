using SwissTransport;
using System;
using System.Collections.Generic;
using System.Device.Location;
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
        private List<Verbindungen> verbindungList = new List<Verbindungen>();
        private List<Abfahrtstafel> abfahrtstafelList = new List<Abfahrtstafel>();
        private List<Stationen> stationenList = new List<Stationen>();
        private ITransport transportAPI;

        public MainWindow()
        {
            InitializeComponent();
            txtVerbindungenDate.Text = DateTime.Now.ToString();
        }

        private void btnVerbindungSuchenClick(object sender, RoutedEventArgs e)
        {
            dataGridVerbindung.ItemsSource = null;
            verbindungList.Clear();
            string verbindungenVon = "";
            string verbindungenNach = "";
            DateTime? verbindungenDatum = DateTime.Now;
            txtVerbindungenDate.Text = verbindungenDatum.ToString();
            string verbindungenZeit = DateTime.Now.ToString();

            if (cmbVerbindungenVon.Text.Length > 0)
            {
                verbindungenVon = cmbVerbindungenVon.Text;
            } 
            else
            {
                showError("Von ist leer");
            }
            if (cmbVerbindungenNach.Text.Length > 0)
            {
                verbindungenNach = cmbVerbindungenNach.Text;
            }
            else
            {
                showError("Nach ist leer");
            }
            if (!txtVerbindungenDate.Value.HasValue)
            {
                showError("Date ist leer");
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
            dataGridAbfahrtstafel.ItemsSource = null;
            abfahrtstafelList.Clear();
            string station = "";
            if (cmbStation.Text.Length > 0)
            {
                station = cmbStation.Text;
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

        private void btnStationenSuchenClick(object sender, RoutedEventArgs e)
        {
            dataGridStationen.ItemsSource = null;
            stationenList.Clear();
            string station = "";
            if (txtStationen.Text.Length > 0)
            {
                station = txtStationen.Text;
            } else
            {
                showError("Station ist leer");
            }

            transportAPI = new Transport();
            var test = transportAPI.GetStations(station);
            int id = 0;
            foreach (var line in test.StationList)
            {
                if (line.Icon == "train")
                {
                    line.Icon = "Zug";
                }
                else if (line.Icon == "bus")
                {
                    line.Icon = "Bus";
                }
                stationenList.Add(new Stationen { StationenId = id, StationenName = line.Name, StationenTyp = line.Icon, StationenMapURL = "https://www.google.com/maps/place/" + line.Coordinate.XCoordinate + "+" + line.Coordinate.YCoordinate});
            }
            dataGridStationen.ItemsSource = stationenList;
        }

        private void btnMapOpenClick(object sender, RoutedEventArgs e)
        {
            object URL = ((Button)sender).CommandParameter;
            System.Diagnostics.Process.Start(URL.ToString());
        }

        private void btnLocationClick(object sender, RoutedEventArgs e)
        {
            dataGridStationen.ItemsSource = null;
            stationenList.Clear();
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            // Do not suppress prompt, and wait 1000 milliseconds to start.
            watcher.TryStart(false, TimeSpan.FromMilliseconds(4000));

            GeoCoordinate coord = watcher.Position.Location;
            if (coord.IsUnknown != true)
            {
                string coordX = coord.Latitude.ToString().Replace(",", ".");
                string coordY = coord.Longitude.ToString().Replace(",", ".");
                txtStationen.Text = coord.Latitude + ", " + coord.Longitude;
                transportAPI = new Transport();
                var test = transportAPI.GetStationsByCoordinates(coordX, coordY);
                int id = 0;
                foreach (var line in test.StationList)
                {
                    if (line.Icon == "train")
                    {
                        line.Icon = "Zug";
                    }
                    else if (line.Icon == "bus")
                    {
                        line.Icon = "Bus";
                    }
                    stationenList.Add(new Stationen { StationenId = id, StationenName = line.Name, StationenTyp = line.Icon, StationenMapURL = "https://www.google.com/maps/place/" + line.Coordinate.XCoordinate.ToString().Replace(",",".") + "+" + line.Coordinate.YCoordinate.ToString().Replace(",", ".") });
                }
                dataGridStationen.ItemsSource = stationenList;
            }
            else
            {
                MessageBox.Show("Position konnte nicht ermittelt werden");
            }
        }

        private void cmbAutoSelect(ComboBox combobox)
        {
            if (combobox.Text.Length == 3)
            {
                string input = combobox.Text;
                combobox.Items.Clear();
                combobox.Text = input;
                transportAPI = new Transport();
                var test = transportAPI.GetStations(combobox.Text);
                foreach (var line in test.StationList)
                {
                    if (line.Id != null)
                    {
                        combobox.Items.Add(line.Name);
                    }
                }
                var myTextBox = (combobox.Template.FindName("PART_EditableTextBox", combobox) as TextBox);
                if (myTextBox != null)
                {
                    myTextBox.Focus();
                    myTextBox.SelectionStart = myTextBox.Text.Length;
                }
            }

            if (combobox.Text.Length > 0)
            {
                combobox.IsDropDownOpen = true;
            }
        }

        private void cmbAutoSelectTextChanged(object sender, TextChangedEventArgs e)
        {
            cmbAutoSelect((ComboBox)sender);
        }

        private void btnExportMailClick(object sender, RoutedEventArgs e)
        {
            if (verbindungList.Count > 0)
            {
                MailExport mailExport = new MailExport(verbindungList);
                mailExport.ShowDialog();
            }
            else
            {
                showError("Es sind keine Verbindungen vorhanden");
            }
        }

        private void showError(string message)
        {
            MessageBox.Show(message);
        }
    }
}
