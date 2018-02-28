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

namespace Assingment_1.User
{
    /// <summary>
    /// Interaction logic for viewService.xaml
    /// </summary>
    public partial class viewService : Window
    {
        public viewService()
        {
            InitializeComponent();
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            servicePanel u = new servicePanel();
            this.Hide();
            u.Show();
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
            ServiceForUpdateBO item = new ServiceForUpdateBO();
            item.Pid = this.pid.Text;

            ServiceBLL salebl = new ServiceBLL();
            item = salebl.searchToUpdateItem(item);

            if (item == null)
            {
                MessageBox.Show("Product is not Serviced");
                this.pid.Text = null;

                this.pid.IsEnabled = true;
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
                this.address.Text = item.Address;
                this.customerName.Text = item.CustomerName;
                this.phone.Text = item.Phone;
                this.serviceCharges.Text = item.Charges.ToString();
                this.entryDate.Text = item.Date;
                this.serviceDate.Text = item.ServiceDate;
                this.returnDate.Text = item.ReturnDate;
                //this.quantity.Text = item.Quantity.ToString();
                this.pid.IsEnabled = false;


            }
        }

        private void refresh_btn_Click(object sender, RoutedEventArgs e)
        {
            this.pid.Text = null;
            this.price.Text = null;
            this.category.Text = null;
            this.size.Text = null;
            this.color.Text = null;
            this.brand.Text = null;
            this.entryDate.Text = null;
            this.address.Text = null;
            this.customerName.Text = null;
            this.phone.Text = null;
            this.serviceCharges.Text = null;
            this.entryDate.Text = null;
            this.serviceDate.Text = null;
            this.returnDate.Text = null;
            this.pid.IsEnabled = true;

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
    }
}
