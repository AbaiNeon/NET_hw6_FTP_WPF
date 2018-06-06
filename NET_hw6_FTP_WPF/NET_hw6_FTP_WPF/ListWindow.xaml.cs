using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace NET_hw6_FTP_WPF
{
    /// <summary>
    /// Логика взаимодействия для ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        public ListWindow()
        {
            InitializeComponent();

            using (Stream stream = Authorization.ftpWebResponse.GetResponseStream())
            {
                byte[] buffer = new byte[512];
                int bytes = stream.Read(buffer, 0, buffer.Length);

                string data = Encoding.Default.GetString(buffer);
                string[] arr = data.Split(new[] { @"\r\n" }, StringSplitOptions.None);
                myListBox.ItemsSource = arr.ToList();
            }
        }
    }
}
