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
    /// Interaction logic for sales.xaml
    /// </summary>
    public partial class sales : Window
    {
        public sales()
        {
            InitializeComponent();
            purchaseDate.SelectedDate = DateTime.Today;

        }

        private void newSale_btn_Click(object sender, RoutedEventArgs e)
        {
            this.pid.Text = null;
            this.price.Text = null;
            this.category.Text = null;
            this.size.Text = null;
            this.color.Text = null;
            this.brand.Text = null;
            this.pid.IsEnabled = true;
            this.recept.Text = null;
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            userPanel u = new userPanel();
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
            saleBLL salebl = new saleBLL();
            item = salebl.searchItem(item);

            if (item == null)
            {
                MessageBox.Show("Product is not Available");
                this.pid.Text = null;
                this.price.Text = null;
                this.category.Text = null;
                this.size.Text = null;
                this.color.Text = null;
                this.brand.Text = null;
                //this.entryDate.Text = null;
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
                //this.entryDate.Text = item.Date;
                //this.quantity.Text = item.Quantity.ToString();
                this.pid.IsEnabled = false;


            }
        }

        private void purchase_btn_Click(object sender, RoutedEventArgs e)
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
            if ((isNumeric == false) || string.IsNullOrWhiteSpace(this.category.Text) || (isNumeric2 == false) || string.IsNullOrWhiteSpace(this.color.Text) || string.IsNullOrWhiteSpace(this.brand.Text) || string.IsNullOrWhiteSpace(this.purchaseDate.Text))
            {
                search_btn_Click(sender, e);
                if (string.IsNullOrWhiteSpace(this.pid.Text))
                {
                    return;
                }

            }

            saleBO sale = new saleBO();
            sale.Pid = this.pid.Text;
            sale.PurchaseDate = this.purchaseDate.Text;
           
            //MessageBox.Show(item.Pid + " " + item.Price + " " + item.Category + " " + item.Size + " " + item.Color + " " + item.Brand + " " + item.Date);

            saleBLL salebl = new saleBLL();
            int rv = salebl.ssaleItem(sale);

            if (rv == 0)
            {
                MessageBox.Show("Soled");
                this.pid.Text = null;
                this.price.Text = null;
                this.category.Text = null;
                this.size.Text = null;
                this.color.Text = null;
                this.brand.Text = null;

                //this.quantity.Text = null;

            }
            else if (rv == 3)
            {
                MessageBox.Show("Product Is Not Available");
                this.pid.Text = null;

            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void showSale_btn_Click(object sender, RoutedEventArgs e)
        {
          
            string p = "PRODUCT ID  ";
            string pr = "PRICE (RS)  ";
            string c = "COLOR       ";
            string S = "SIZE        ";
            string cat= "CATEGORY    ";
            string b = "BRAND       ";
            string pR = "PURCHASED   ";


            var sb = new StringBuilder();
            sb.AppendLine("                             EFSI PURCHASING RECEIPT");
            sb.AppendLine("                          15/12, NEW MARKET, KISHOREGANJ");
            sb.AppendLine("                     Cell: +880-1711-360899 / +880-1919-360899\n");

            sb.Append(p);
            sb.Append("         ");
            sb.Append(this.pid.Text);
            sb.Append("\n");

            sb.Append(pr);
            sb.Append("             ");
            sb.Append(this.price.Text);
            sb.Append("\n");

            sb.Append(c);
            sb.Append("               ");
            sb.Append(this.color.Text);
            sb.Append("\n");

            sb.Append(S);
            sb.Append("                   ");
            sb.Append(this.size.Text);
            sb.Append("\n");

            sb.Append(cat);
            sb.Append("          ");
            sb.Append(this.category.Text);
            sb.Append("\n");

            sb.Append(b);
            sb.Append("               ");
            sb.Append(this.brand.Text);
            sb.Append("\n");

            sb.Append(pR);
            sb.Append("        ");
            sb.Append(this.purchaseDate.Text);
            sb.Append("\n");


            sb.AppendLine("=======================================================");
            sb.AppendLine("THANK YOU FOR PURCHASING !!!");
            sb.AppendLine("FOR FUTURE REFRENCE KINDLY PROVIDE THE RECEIPT");
            sb.AppendLine("REPAIRMENT WARRANTY PERIOD : 6 MONTHS (EFSI PRODUCT)");


            this.recept.Text = sb.ToString();
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            // create a writer and open the file
            TextWriter tw = new StreamWriter("SaleRecord.txt");
            // write a line of text to the file
            tw.WriteLine(this.recept.Text);
            // close the stream
            tw.Close();
            MessageBox.Show("Saved");
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

        private void numbervalidation_LostFocus(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t != null)
            {
                if (string.IsNullOrWhiteSpace(t.Text))
                {
                    t.Background = Brushes.Red;
                }
                else
                {
                    int n;
                    bool isNumeric = int.TryParse(t.Text, out n);
                    if (isNumeric == false)
                    {
                        t.Background = Brushes.Red;
                    }
                }

            }

        }
    }
}
