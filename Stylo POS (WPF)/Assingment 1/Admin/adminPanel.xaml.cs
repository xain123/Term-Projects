using Assingment_1.Admin;
using Assingment_1.User;
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

namespace Assingment_1
{
    /// <summary>
    /// Interaction logic for adminPanel.xaml
    /// </summary>
    public partial class adminPanel : Window
    {
        public adminPanel()
        {
            InitializeComponent();
            
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Hide();
            m.Show();


        }
        private void manageStock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("Manage Stock");
            this.Hide();
            manageStock ms = new manageStock();
            ms.Show();
        }
        private void salesReport_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("Sales report");
            adminSalesReport a = new adminSalesReport();
            this.Hide();
            a.Show();
        }

        private void services_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("Services");
            global.MyProperty = 1;
            this.Hide();
            servicePanel s = new servicePanel();
            s.Show();

        }
        private void updatePassword_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("Update password");
            updatePassword u = new updatePassword();
            this.Hide();
            u.Show();

        }
        private void staffReg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            // MessageBox.Show("staff registration");
            staffRegistration s = new staffRegistration();
            this.Hide();
            s.Show();
        }
        private void about_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("About");
            About a = new About();
            this.Hide();
            a.Show();
        }

    }
}
