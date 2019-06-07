using System;
using System.Collections.Generic;
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

namespace MUA_Share
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool error = false;

        public MainWindow()
        {
            InitializeComponent();


        }

        private void SendB_Click(object sender, RoutedEventArgs e)
        {
            if(!error)
            {
                Util.CreateServerClient(ipTB, pnTB);
                Send send = new Send();
                send.Show();
                this.Close();
            }
        }

        private void RecieveB_Click(object sender, RoutedEventArgs e)
        {
            if(!error)
            {
                Util.CreateServerClient(ipTB, pnTB);
                Recieve recieve = new Recieve();
                recieve.Show();
                this.Close();
            }
        }

        private void StopB_Click(object sender, RoutedEventArgs e)
        {

            Util.StopServerClient();

        }

        private void IpTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                IPAddress.Parse(ipTB.Text);
            }
            catch(Exception ex)
            {
                ipTB.Background = Brushes.Red;
                error = true;
                return;

            }
            error = false;
            ipTB.Background = Brushes.White;
        }

        private void PnTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            int pnx;
            try
            {
                pnx = int.Parse(pnTB.Text);
            }
            catch (Exception ex)
            {
                pnTB.Background = Brushes.Red;
                error = true;
                return;

            }
            error = false;
            pnTB.Background = Brushes.White;
            if (pnx < 0 || pnx > 9999)
            {
                error = true;
                pnTB.Background = Brushes.Red;
            }
        }
    }
}
