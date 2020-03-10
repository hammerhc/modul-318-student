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
        }
    }
}
