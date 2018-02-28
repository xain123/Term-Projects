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
using System.Windows.Shapes;

namespace Assingment_1.User
{
    /// <summary>
    /// Interaction logic for userPanel.xaml
    /// </summary>
    public partial class userPanel : Window
    {
        public userPanel()
        {
            InitializeComponent();
            if (global.user == null)
            {
                global.user = "abc";
            }
            String after = global.user.Substring(0, 1).ToUpper() + global.user.Substring(1);
            this.user.Content = after;
        }

       
        private void newSale_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("Manage Stock");
            this.Hide();
            sales ms = new sales();
            ms.Show();
        }
        private void report_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

           // MessageBox.Show("Sales report");
            reportPanel a = new reportPanel();
            this.Hide();
            a.Show();
        }

        private void services_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("Services");
            this.Hide();
            servicePanel s = new servicePanel();
            s.Show();
        }
        private void logout_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("Logout");
            MainWindow u = new MainWindow();
            this.Hide();
            u.Show();

        }
    }
}
