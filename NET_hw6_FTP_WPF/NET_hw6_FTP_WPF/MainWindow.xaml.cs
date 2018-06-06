using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace NET_hw6_FTP_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConnectClick(object sender, RoutedEventArgs e)
        {
            string url = txtBoxUrl.Text;
            string login = txtBoxLogin.Text;
            string password = txtBoxPassword.Text;

            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(url);
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            ftpWebRequest.Credentials = new NetworkCredential(login, password);

            if (checkBoxSsl.IsChecked.Value == true)
            {
                ftpWebRequest.EnableSsl = true;
            }

            FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
            Authorization.ftpWebResponse = ftpWebResponse;
        }

        private void BtnGetListClick(object sender, RoutedEventArgs e)
        {
            ListWindow lw = new ListWindow();
            lw.ShowDialog();
        }
    }
}
