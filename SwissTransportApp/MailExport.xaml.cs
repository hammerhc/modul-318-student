using System;
using System.Collections.Generic;
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
            bool settingsStatus = checkSettings();
            if (settingsStatus == true)
            {
                if (txtMailTo.Text.Length > 0 && txtMailSubject.Text.Length > 0 && txtMailBody.Text.Length > 0)
                {
                    var smtpClient = new SmtpClient(txtSMTPHost.Text, Convert.ToInt32(txtSMTPPort.Text))
                    {
                        Credentials = new NetworkCredential(txtUsername.Text, txtPassword.Text),
                        EnableSsl = true
                    };
                    try
                    {
                        smtpClient.Send(txtUsername.Text, txtMailTo.Text, txtMailSubject.Text, txtMailBody.Text);
                        MessageBox.Show("E-Mail wurde erfolgreich gesendet");
                        txtMailTo.Text = "";
                        txtMailSubject.Text = "";
                        txtMailBody.Text = "";
                        txtMailTo.Focus();
                    }
                    catch
                    {
                        MessageBox.Show("E-Mail wurde nicht gesendet");
                    }
                }
            }
        }

        private bool checkSettings()
        {
            if (txtSMTPHost.Text.Length > 0 && txtSMTPPort.Text.Length > 0 && txtUsername.Text.Length > 0 && txtPassword.Text.Length > 0)
            {
                return true;
            } 
            else
            {
                return false;
            }
            
        }
    }
}
