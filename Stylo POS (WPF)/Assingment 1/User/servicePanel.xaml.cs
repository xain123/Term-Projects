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
    /// Interaction logic for servicePanel.xaml
    /// </summary>
    public partial class servicePanel : Window
    {
        public servicePanel()
        {
            InitializeComponent();
        }

        private void newService_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("New Service");
            this.Hide();
            newService ms = new newService();
            ms.Show();
        }
        private void updateService_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("Update Service");
            updateService a = new updateService();
            this.Hide();
            a.Show();
        }

        private void viewService_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("View Services");
            viewService v = new viewService();
            this.Hide();
            v.Show();
        }
        private void back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("Back");
            if (global.MyProperty == 1)
            {
                global.MyProperty = 0;
                adminPanel a = new adminPanel();
                this.Hide();
                a.Show();
            }
            else
            {
                userPanel u = new userPanel();
                this.Hide();
                u.Show();
            }
        }
    }
}
