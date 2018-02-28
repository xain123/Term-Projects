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
using BO;
using BLL;

namespace Assingment_1
{
    /// <summary>
    /// Interaction logic for adminSalesReport.xaml
    /// </summary>
    public partial class adminSalesReport : Window
    {
        public adminSalesReport()
        {
            InitializeComponent();
            this.dataGrid.ItemsSource = getSaleReport();

           
            from.SelectedDate = DateTime.Today;
            to.SelectedDate = DateTime.Today;
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            adminPanel a = new adminPanel();
            this.Hide();
            a.Show();
        }

        List<SalesReportBo> getSaleReport()
        {
            ItemBLL ib = new ItemBLL();
            return ib.getSalesReport();

        }
       

       

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            string from = this.from.Text;
            string to = this.to.Text;

            if (DateTime.Parse(to) < DateTime.Parse(from))
            {
                MessageBox.Show("Invalid Dates");
                return;
            }

            ItemBLL ib = new ItemBLL();
            List<SalesReportBo> ls = ib.getAdminSalekReportBW(from, to);
            this.dataGrid.ItemsSource = ls;

        }

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            this.dataGrid.ItemsSource = getSaleReport();
        }

      
    }
}
