using SwissTransport;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Windows;
using System.Windows.Controls;

namespace SwissTransportApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Lists for each DataGrid
        /// </summary>
        private List<Verbindungen> verbindungenList = new List<Verbindungen>();
        private List<Abfahrtstafel> abfahrtstafelList = new List<Abfahrtstafel>();
        private List<Stationen> stationenList = new List<Stationen>();

        /// <summary>
        /// Transport object
        /// </summary>
        private ITransport transportAPI;

        /// <summary>
        /// Initialize MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            txtVerbindungenDate.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// Function for getting the connection data
        /// </summary>
        private void getConnection()
        {
            /// Define variables
            string verbindungenVon = "";
            string verbindungenNach = "";
            bool verbindungenType = false;
            txtVerbindungenDate.Text = DateTime.Now.ToString();

            /// Initialize Object from Transport Class
            transportAPI = new Transport();

            /// Check Controls
            if (cmbVerbindungenVon.Text.Length > 0)
            {
                verbindungenVon = cmbVerbindungenVon.Text;
            }
            else
            {
                showError("Bitte Startstation eingeben.");
            }
            if (cmbVerbindungenNach.Text.Length > 0)
            {
                verbindungenNach = cmbVerbindungenNach.Text;
            }
            else
            {
                showError("Bitte Endstation eingeben.");
            }
            if (!txtVerbindungenDate.Value.HasValue)
            {
                showError("Bitte Datum und Uhrzeit auswählen.");
            }
            if (radioBtnVerbindungenAb.IsChecked.Value)
            {
                verbindungenType = false;
            }
            if (radioBtnVerbindungenAn.IsChecked.Value)
            {
                verbindungenType = true;
            }

            /// Getting the data from the Api
            try
            {
                var date = Convert.ToDateTime(txtVerbindungenDate.Text);
                var year = date.Year;
                var month = date.Month;
                var day = date.Day;
                var time = date.TimeOfDay;
                var apiDate = year + "-" + month + "-" + day;
                var connectionResult = transportAPI.GetConnectionsByTime(verbindungenVon, verbindungenNach, apiDate, time.ToString(), verbindungenType);
                int id = 0;
                string verbindungAn = "";
                string verbindungAb = "";
                DateTime dateTimeFrom;
                DateTime dateTimeTo;
                foreach (var line in connectionResult.ConnectionList)
                {
                    dateTimeFrom = UnixTimeStampToDateTime(Convert.ToDouble(line.From.DepartureTimestamp));
                    dateTimeTo = UnixTimeStampToDateTime(Convert.ToDouble(line.To.ArrivalTimestamp));
                    verbindungAb = line.From.Station.Name + ", " + dateTimeFrom.ToString();
                    verbindungAn = line.To.Station.Name + ", " + dateTimeTo.ToString();
                    verbindungenList.Add(new Verbindungen { VerbindungId = id, VerbindungAb = verbindungAb, VerbindungAn = verbindungAn, VerbindungDauer = line.Duration, VerbindungGleisAb = line.From.Platform, VerbindungGleisAn = line.To.Platform });
                    id++;
                }
                dataGridVerbindung.ItemsSource = verbindungenList;
            }
            catch
            {
                showError("Fehler bei der Abfrage der Daten, stellen Sie sicher, dass Sie eine aktive Internetverbindung haben und ihre Angaben korrekt sind.");
            }
        }

        /// <summary>
        /// Function for getting the stationBoard data
        /// </summary>
        private void getStationBoard()
        {
            /// Define variables
            string station = "";
            string stationId = "";
            transportAPI = new Transport();

            /// Check controls
            if (cmbStation.Text.Length > 0)
            {
                station = cmbStation.Text;
            }
            else
            {
                showError("Bitte Station eingeben.");
            }

            stationId = getStationId(station);

            try
            {
                if (stationId.Length > 0)
                {
                    var stationBoardResult = transportAPI.GetStationBoard(station, stationId);
                    int id = 0;
                    foreach (var line in stationBoardResult.Entries)
                    {
                        abfahrtstafelList.Add(new Abfahrtstafel { AbfahrtstafelId = id, AbfahrtstafelAbfahrt = line.Stop.Departure.ToString(), AbfahrtstafelNach = line.To, AbfahrtstafelTyp = line.Name });
                    }
                }
                dataGridAbfahrtstafel.ItemsSource = abfahrtstafelList;
            }
            catch
            {
                showError("Fehler bei der Abfrage der Daten, stellen Sie sicher, dass Sie eine aktive Internetverbindung haben und ihre Angaben korrekt sind.");
            }

        }

        /// <summary>
        /// Function for getting the station id
        /// </summary>
        private string getStationId(string station)
        {
            string stationId = "";
            try
            {
                var stationBoardResult = transportAPI.GetStations(station);
                foreach (var line in stationBoardResult.StationList)
                {
                    if (line.Name == station)
                    {
                        stationId = line.Id;
                    }
                }
                return stationId;
            }
            catch
            {
                showError("Fehler bei der Abfrage der Daten, stellen Sie sicher, dass Sie eine aktive Internetverbindung haben und ihre Angaben korrekt sind.");
                return stationId;
            }
        }

        /// <summary>
        /// Function for getting the stations
        /// </summary>
        private void getStations()
        {
            /// Define variables
            string station = "";
            transportAPI = new Transport();

            /// Check Controls
            if (txtStationen.Text.Length > 0)
            {
                station = txtStationen.Text;
            }
            else
            {
                showError("Bitte Station eingeben.");
            }

            try
            {
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
                    stationenList.Add(new Stationen { StationenId = id, StationenName = line.Name, StationenTyp = line.Icon, StationenMapURL = "https://www.google.com/maps/place/" + line.Coordinate.XCoordinate + "+" + line.Coordinate.YCoordinate });
                }
                dataGridStationen.ItemsSource = stationenList;
            }
            catch
            {
                showError("Fehler bei der Abfrage der Daten, stellen Sie sicher, dass Sie eine aktive Internetverbindung haben und ihre Angaben korrekt sind.");
            }
        }

        /// <summary>
        /// Function for getting the stations by coordinate
        /// </summary>
        private void getStationsByCoordinate ()
        {
            /// Define variables 
            string coordX = "";
            string coordY = "";
            transportAPI = new Transport();

            /// Initialize object GeoCoordinateWatcher
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            watcher.TryStart(false, TimeSpan.FromMilliseconds(4000));

            GeoCoordinate coord = watcher.Position.Location;
            if (coord.IsUnknown != true)
            {
                coordX = coord.Latitude.ToString().Replace(",", ".");
                coordY = coord.Longitude.ToString().Replace(",", ".");

                try
                {
                    var stationsResult = transportAPI.GetStationsByCoordinates(coordX, coordY);
                    int id = 0;
                    foreach (var line in stationsResult.StationList)
                    {
                        if (line.Icon == "train")
                        {
                            line.Icon = "Zug";
                        }
                        else if (line.Icon == "bus")
                        {
                            line.Icon = "Bus";
                        }
                        stationenList.Add(new Stationen { StationenId = id, StationenName = line.Name, StationenTyp = line.Icon, StationenMapURL = "https://www.google.com/maps/place/" + line.Coordinate.XCoordinate.ToString().Replace(",", ".") + "+" + line.Coordinate.YCoordinate.ToString().Replace(",", ".") });
                    }
                    dataGridStationen.ItemsSource = stationenList;
                }
                catch
                {
                    showError("Fehler bei der Abfrage der Daten, stellen Sie sicher, dass Sie eine aktive Internetverbindung haben und ihre Angaben korrekt sind.");
                }
            }
            else
            {
               showError("Ihre Position konnte nicht ermittelt werden, stellen Sie sicher, dass Sie GPS auf Ihrem Computer aktiviert haben.");
            }

        }

        /// <summary>
        /// Button connection search click event handler
        /// </summary>
        private void btnVerbindungSuchenClick(object sender, RoutedEventArgs e)
        {
            /// Clear DataGrid 
            dataGridVerbindung.ItemsSource = null;
            verbindungenList.Clear();

            /// Get Connection data from Api function
            getConnection();
        }

        /// <summary>
        /// Button stationBoard search click event handler
        /// </summary>
        private void btnAbfahrtstafelSuchenClick(object sender, RoutedEventArgs e)
        {
            /// Clear DataGrid 
            dataGridAbfahrtstafel.ItemsSource = null;
            abfahrtstafelList.Clear();

            /// Get Stationboard data from Api function
            getStationBoard();
        }

        /// <summary>
        /// Button stations search click event handler
        /// </summary>
        private void btnStationenSuchenClick(object sender, RoutedEventArgs e)
        {
            dataGridStationen.ItemsSource = null;
            stationenList.Clear();

            /// Get stations data from Api function
            getStations();
        }

        /// <summary>
        /// Button map open click event handler
        /// </summary>
        private void btnMapOpenClick(object sender, RoutedEventArgs e)
        {
            try
            {
                object URL = ((Button)sender).CommandParameter;
                System.Diagnostics.Process.Start(URL.ToString());
            }
            catch
            {
                showError("Google Maps konnte nicht geöffnet werden.");
            }

        }

        /// <summary>
        /// Button location click event handler
        /// </summary>
        private void btnLocationClick(object sender, RoutedEventArgs e)
        {
            dataGridStationen.ItemsSource = null;
            stationenList.Clear();

            /// Get stations data by coordinate from Api function
            getStationsByCoordinate();
        }

        /// <summary>
        /// Autoselect function for the combobox
        /// </summary>
        private void cmbAutoSelect(ComboBox combobox)
        {
            if (combobox.Text.Length > 2 && combobox.Text.Length < 5)
            {
                combobox.Items.Clear();
                transportAPI = new Transport();
                try
                {
                    var stationsResult = transportAPI.GetStations(combobox.Text);
                    foreach (var line in stationsResult.StationList)
                    {
                        if (line.Id != null)
                        {
                            combobox.Items.Add(line.Name);
                        }
                    }
                }
                catch
                {
                    showError("Fehler bei der Abfrage der Daten, stellen Sie sicher, dass Sie eine aktive Internetverbindung haben und ihre Angaben korrekt sind.");
                }
            }

            if (combobox.Text.Length < 3)
            {
                combobox.IsDropDownOpen = false;
            }

            if (combobox.Text.Length >= 3)
            {
                combobox.IsDropDownOpen = true;
                var myTextBox = (combobox.Template.FindName("PART_EditableTextBox", combobox) as TextBox);
                if (myTextBox != null)
                {
                    myTextBox.Focus();
                    myTextBox.Select(myTextBox.Text.Length, 0);
                }
            }
        }

        /// <summary>
        /// Combobox text changed event handler
        /// </summary>
        private void cmbAutoSelectTextChanged(object sender, TextChangedEventArgs e)
        {
            cmbAutoSelect((ComboBox)sender);
        }

        /// <summary>
        /// Button export mail click event handler
        /// </summary>
        private void btnExportMailClick(object sender, RoutedEventArgs e)
        {
            if (verbindungenList.Count > 0)
            {
                MailExport mailExport = new MailExport(verbindungenList);
                mailExport.ShowDialog();
            }
            else
            {
                showError("Bitte suchen Sie zuerst nach einer Verbindung bevor Sie E-Mails versenden.");
            }
        }

        /// <summary>
        /// Function for converting unix timestamp to date time
        /// </summary>
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        /// <summary>
        /// Function for show errors
        /// </summary>
        private void showError(string message)
        {
            MessageBox.Show(message);
        }
    }
}
