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
using System.IO;
using BO;
using BLL;
namespace Assingment_1.User
{
    /// <summary>
    /// Interaction logic for newService.xaml
    /// </summary>
    public partial class newService : Window
    {
        public newService()
        {
            InitializeComponent();
            serviceDate.SelectedDate = DateTime.Today;
            returnDate.SelectedDate = DateTime.Today;



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
            ItemBO item = new ItemBO();
            item.Pid = this.pid.Text;
            ServiceBLL salebl = new ServiceBLL();
            item = salebl.searchItem(item);

            if (item == null)
            {
                MessageBox.Show("Product is not Sold");
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

        private void newService_btn_Click(object sender, RoutedEventArgs e)
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
            this.recept.Text = null;
            serviceDate.SelectedDate = DateTime.Today;
            returnDate.SelectedDate = DateTime.Today;

        }

        private void addService_btn_Click(object sender, RoutedEventArgs e)
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
            int n3;
            bool isNumeric3 = int.TryParse(this.serviceCharges.Text, out n3);
            if ((isNumeric3 == false) || string.IsNullOrWhiteSpace(this.customerName.Text) || string.IsNullOrWhiteSpace(this.address.Text) || string.IsNullOrWhiteSpace(this.phone.Text))
            {
                if ((isNumeric3 == false))
                {
                    serviceCharges.Background = Brushes.Red;
                }
                if (string.IsNullOrWhiteSpace(this.customerName.Text))
                {
                    customerName.Background = Brushes.Red;
                }
                if (string.IsNullOrWhiteSpace(this.address.Text))
                {
                    address.Background = Brushes.Red;
                }
                if (string.IsNullOrWhiteSpace(this.phone.Text))
                {
                    phone.Background = Brushes.Red;
                }
                return;

            }
            ServiceBO item = new ServiceBO();
            item.Pid = this.pid.Text;
            item.Charges = Convert.ToInt32(this.serviceCharges.Text);
            item.CustomerName = this.customerName.Text;
            item.Address = this.address.Text;
            item.Phone = this.phone.Text;
            item.ServiceDate = this.serviceDate.Text;
            item.ReturnDate = this.returnDate.Text;

            //MessageBox.Show(item.Pid + " " + item.Price + " " + item.Category + " " + item.Size + " " + item.Color + " " + item.Brand + " " + item.Date);

            ServiceBLL itenbl = new ServiceBLL();
            int rv = itenbl.addService(item);

            if (rv == 0)
            {
                MessageBox.Show("Service Added");
                this.pid.Text = null;
                this.price.Text = null;
                this.pid.IsEnabled = true;

                //this.quantity.Text = null;

            }
            else if (rv == 3)
            {
                MessageBox.Show("Product ID Already Exist");
                this.pid.Text = null;
                this.pid.IsEnabled = true;

            }
            else
            {
                MessageBox.Show("Error");
                this.pid.IsEnabled = true;

            }
        }

        private void showService_btn_Click(object sender, RoutedEventArgs e)
        {
            string p = "PRODUCT ID  ";
            string pr = "PRICE (RS)  ";
            string c = "COLOR       ";
            string S = "SIZE        ";
            string cat = "CATEGORY    ";
            string b = "BRAND       ";
            
            string cn = "CUSTOMER NAME   ";
            string a = "ADDRESS   ";
            string pH = "PHONE   ";
            string pR = "PURCHASED   ";
            string sr = "SERVICE   ";
            string re = "RETURN   ";
            string ch = "CHARGE (RS)   ";


            var sb = new StringBuilder();
            sb.AppendLine("                               EFSI SERVICE RECEIPT");
            sb.AppendLine("                          15/12, NEW MARKET, KISHOREGANJ");
            sb.AppendLine("                     Cell: +880-1711-360899 / +880-1919-360899\n");

            sb.Append(p);
            sb.Append("                     ");
            sb.Append(this.pid.Text);
            sb.Append("\n");

            sb.Append(pr);
            sb.Append("                         ");
            sb.Append(this.price.Text);
            sb.Append("\n");

            sb.Append(c);
            sb.Append("                          ");
            sb.Append(this.color.Text);
            sb.Append("\n");

            sb.Append(S);
            sb.Append("                              ");
            sb.Append(this.size.Text);
            sb.Append("\n");

            sb.Append(cat);
            sb.Append("                     ");
            sb.Append(this.category.Text);
            sb.Append("\n");

            sb.Append(b);
            sb.Append("                          ");
            sb.Append(this.brand.Text);
            sb.Append("\n");

            sb.Append(cn);
            sb.Append("        ");
            sb.Append(this.customerName.Text);
            sb.Append("\n");

            sb.Append(a);
            sb.Append("                         ");
            sb.Append(this.address.Text);
            sb.Append("\n");

            sb.Append(pH);
            sb.Append("                              ");
            sb.Append(this.phone.Text);
            sb.Append("\n");

            sb.Append(pR);
            sb.Append("                   ");
            sb.Append(this.entryDate.Text);
            sb.Append("\n");

            sb.Append(sr);
            sb.Append("                          ");
            sb.Append(this.serviceDate.Text);
            sb.Append("\n");

            sb.Append(re);
            sb.Append("                           ");
            sb.Append(this.returnDate.Text);
            sb.Append("\n");

            sb.Append(ch);
            sb.Append("                  ");
            sb.Append(this.serviceCharges.Text);
            sb.Append("\n");


            sb.AppendLine("=======================================================");
            sb.AppendLine("WE ARE GLAD TO SERVICE YOU !!!");
            sb.AppendLine("FOR FUTURE REFRENCE KINDLY PROVIDE THE RECEIPT");


            this.recept.Text = sb.ToString();
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            
                // create a writer and open the file
                TextWriter tw = new StreamWriter("ServiceRecord.txt");
                // write a line of text to the file
                tw.WriteLine(this.recept.Text);
                // close the stream
                tw.Close();
                MessageBox.Show("Saved" );
            
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
