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
    /// Interaction logic for deleteItem.xaml
    /// </summary>
    public partial class deleteItem : Window
    {
        public deleteItem()
        {
            InitializeComponent();
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
            if (string.IsNullOrWhiteSpace(this.pid.Text))
            {
                if (string.IsNullOrWhiteSpace(this.pid.Text))
                {
                    pid.Background = Brushes.Red;
                }
                MessageBox.Show("Validate");
                return;

            }
            ItemBO item = new ItemBO();
            item.Pid = this.pid.Text;
            ItemBLL itenbl = new ItemBLL();
            item = itenbl.searchItem(item);

            if (item == null)
            {
                MessageBox.Show("No record Found");
                this.pid.Text = null;
                this.price.Text = null;
                this.category.Text = null;
                this.size.Text = null;
                this.color.Text = null;
                this.brand.Text = null;
                this.entryDate.Text = null;
                //this.quantity.Text = null;
            }
            else
            {
                this.pid.Text = item.Pid;
                this.price.Text = item.Price.ToString();
                this.category.Text = item.Category;
                this.size.Text = item.Size.ToString();
                this.color.Text = item.Color;
                this.brand.Text = item.Brand;
                this.entryDate.Text = item.Date;
                //this.quantity.Text = item.Quantity.ToString();
                this.pid.IsEnabled = false;
            }
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(this.price.Text, out n);
            int n2;
            bool isNumeric2 = int.TryParse(this.size.Text, out n2);
            if (string.IsNullOrWhiteSpace(this.pid.Text))
            {
                if (string.IsNullOrWhiteSpace(this.pid.Text))
                {
                    pid.Background = Brushes.Red;
                }
                MessageBox.Show("Validate");
                return;

            }
            if ((isNumeric == false) || string.IsNullOrWhiteSpace(this.category.Text) || (isNumeric2 == false) || string.IsNullOrWhiteSpace(this.color.Text) || string.IsNullOrWhiteSpace(this.brand.Text) || string.IsNullOrWhiteSpace(this.entryDate.Text))
            {
                search_btn_Click(sender, e);
                if (string.IsNullOrWhiteSpace(this.pid.Text))
                {
                    return;
                }

            }
            ItemBO item = new ItemBO();
            item.Pid = this.pid.Text;

            ItemBLL itenbl = new ItemBLL();
            int rv = itenbl.deleteItem(item);

            if (rv == 0)
            {
                MessageBox.Show("Deleted");
                this.pid.Text = null;
                this.price.Text = null;
                this.category.Text = null;
                this.size.Text = null;
                this.color.Text = null;
                this.brand.Text = null;
                this.entryDate.Text = null;
                //this.quantity.Text = null;
            }
            else if (rv == 3)
            {
                MessageBox.Show("Product ID do not Exist");
                this.pid.Text = null;


            }
            else
            {
                MessageBox.Show("Error");
            }
            this.pid.IsEnabled = true;

        }
        private void validation_GotFocus(Object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            t.Background = Brushes.White;
        }
        private void validation_LostFocus(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t != null)
            {
                if (string.IsNullOrWhiteSpace(t.Text))
                {
                    t.Background = Brushes.Red;
                }
            }
        }
    }
}
