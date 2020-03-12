using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SwissTransportApp
{
    /// <summary>
    /// Interaktionslogik für MailExport.xaml
    /// </summary>
    public partial class MailExport : Window
    {

        public MailExport()
        {
            InitializeComponent();
        }

        private void btnMailCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMailSendClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtMailTo.Text.Length > 0 && txtMailSubject.Text.Length > 0 && txtMailBody.Text.Length > 0)
                {
                    string uri = "mailto:" + txtMailTo.Text + "?subject=" + txtMailSubject.Text + "&body=" + txtMailBody.Text;
                    var process = Process.Start(uri);
                }
            }
            catch
            {
                MessageBox.Show("Fehler beim Mail-To");
            }
        }
    }
}
