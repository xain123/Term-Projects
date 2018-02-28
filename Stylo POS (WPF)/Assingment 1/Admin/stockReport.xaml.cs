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
    /// Interaction logic for stockReport.xaml
    /// </summary>
    /// 
    public partial class stockReport : Window
    {
        public stockReport()
        {
            InitializeComponent();
            from.SelectedDate = DateTime.Today;
            to.SelectedDate = DateTime.Today;

            this.dataGrid.ItemsSource = getItems();

            //dataGrid.Columns[8].Visibility = "false";
            

        }

        List<ItemBO> getItems()
        {
            ItemBLL ib = new ItemBLL();
            return ib.getItem();

        }
        void CommonHandler(object sender, RoutedEventArgs e)
        {

            MenuItem mi = e.Source as MenuItem;

            switch (mi.Name)
            {

                case "add":
                    { //do something;
                      //MessageBox.Show("add");

                        manageStock a = new manageStock();
                        this.Hide();
                        a.Show();
                        break;
                    }

                case "delete":
                    { //do something else
                      //MessageBox.Show("delete");

                        deleteItem a = new deleteItem();
                        this.Hide();
                        a.Show();
                        break;
                    }

                case "update":
                    { //something else again
                      //MessageBox.Show("update");

                        updateItem a = new updateItem();
                        this.Hide();
                        a.Show();
                        break;
                    }
                case "stock":
                    { //something else again
                      //MessageBox.Show("stock");

                        stockReport a = new stockReport();
                        this.Hide();
                        a.Show();
                        break;
                    }

            }
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            adminPanel a = new adminPanel();
            this.Hide();
            a.Show();
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            string from = this.from.Text;
            string to = this.to.Text;

            if(DateTime.Parse(to)< DateTime.Parse(from))
            {
                MessageBox.Show("Invalid Dates");
                return;
            }

            ItemBLL ib = new ItemBLL();
            List<ItemBO> ls = ib.getStockReport(from, to);
            this.dataGrid.ItemsSource = ls;

        }

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            this.dataGrid.ItemsSource = getItems();
        }
    }
}
