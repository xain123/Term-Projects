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
    /// Interaction logic for manageStock.xaml
    /// </summary>
    public partial class manageStock : Window
    {
        public manageStock()
        {
            InitializeComponent();
            global.error = 0;
            entryDate.SelectedDate = DateTime.Today;
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

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(this.price.Text, out n);
            if (string.IsNullOrWhiteSpace(this.pid.Text) || (isNumeric == false))
            {
                if (string.IsNullOrWhiteSpace(this.pid.Text))
                {
                    pid.Background = Brushes.Red;
                }
                if(isNumeric == false)
                {
                    price.Background = Brushes.Red;
                   
                }
                MessageBox.Show("Validate");

                return;
            }
            ItemBO item = new ItemBO();
            item.Pid = this.pid.Text;
            item.Price =Convert.ToInt32(this.price.Text);
            item.Category = this.category.Text;
            item.Size = Convert.ToInt32(this.size.Text);
            item.Color = this.color.Text;
            item.Brand = this.brand.Text;
            item.Date = this.entryDate.Text;
            item.Quantity = 1;
            //MessageBox.Show(item.Pid + " " + item.Price + " " + item.Category + " " + item.Size + " " + item.Color + " " + item.Brand + " " + item.Date);

            ItemBLL itenbl = new ItemBLL();
            int rv = itenbl.addItem(item);

            if (rv == 0)
            {
                MessageBox.Show("INSERTED");
                this.pid.Text = null;
                this.price.Text = null;
                //this.quantity.Text = null;

            }
            else if (rv == 3)
            {
                MessageBox.Show("Product ID Already Exist");
                this.pid.Text = null;
                
            }
            else
            {
                MessageBox.Show("Error");
            }


        }

        private void validation_GotFocus(Object sender, EventArgs e)
        {


            TextBox t = sender as TextBox;
            t.Background = Brushes.White;
            //global.error = global.error - 1;

        }
        private void validation_LostFocus(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t != null)
            {
                if (string.IsNullOrWhiteSpace(t.Text))
                {
                    //global.error = global.error + 1;
                    t.Background = Brushes.Red;
                }
            }

        }

        private void numbervalidation_LostFocus(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t != null)
            {
                if (string.IsNullOrWhiteSpace(t.Text))
                {
                    //global.error = global.error + 1;
                    t.Background = Brushes.Red;
                }
                else
                {
                    int n;
                    bool isNumeric = int.TryParse(t.Text, out n);
                    if (isNumeric == false)
                    {
                        //global.error = global.error + 1;
                        t.Background = Brushes.Red;
                    }
                } 

            }

        }
    }
}
