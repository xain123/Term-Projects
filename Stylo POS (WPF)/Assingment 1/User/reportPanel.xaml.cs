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
    /// Interaction logic for reportPanel.xaml
    /// </summary>
    public partial class reportPanel : Window
    {
        public reportPanel()
        {
            InitializeComponent();
        }

        private void saleReport_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("Sale report");
            this.Hide();
            saleReport ms = new saleReport();
            ms.Show();
        }
        private void stockReport_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("Service Report");
            stockReport a = new stockReport();
            this.Hide();
            a.Show();
        }

        private void serviceReport_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("Service Report");
            serviceReport v = new serviceReport();
            this.Hide();
            v.Show();
        }
        private void back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //MessageBox.Show("Back");
            userPanel u = new userPanel();
            this.Hide();
            u.Show();

        }
    }
}
