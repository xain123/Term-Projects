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
    /// Interaction logic for updatePassword.xaml
    /// </summary>
    public partial class updatePassword : Window
    {
        public updatePassword()
        {
            InitializeComponent();
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            adminPanel a = new adminPanel();
            this.Hide();
            a.Show();
        }

        private void updatePass_btn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txt_username.Text) || string.IsNullOrWhiteSpace(this.txt_password.Password.ToString()) || string.IsNullOrWhiteSpace(this.txt_cpassword.Password.ToString()))
            {
                if (string.IsNullOrWhiteSpace(this.txt_username.Text))
                {
                    txt_username.Background = Brushes.Red;
                }
                if (string.IsNullOrWhiteSpace(this.txt_password.Password.ToString()))
                {
                    txt_password.Background = Brushes.Red;
                }
                if (string.IsNullOrWhiteSpace(this.txt_cpassword.Password.ToString()))
                {
                    txt_cpassword.Background = Brushes.Red;
                }
                MessageBox.Show("Validate");

                return;
            }


            if (!(txt_password.Password.ToString().Equals(txt_cpassword.Password.ToString())))
            {
                MessageBox.Show("Password Do Not Match");
                return;
            }

            UserBO ub = new UserBO();
            ub.Username = this.txt_username.Text;
            ub.Password = this.txt_password.Password.ToString();
           

            UserBLL ul = new UserBLL();
            int rv = ul.updateUser(ub);
            if (rv == 0)
            {
                MessageBox.Show("Password Updated");
                this.txt_username.Text = null;
                this.txt_password.Password = null;
                this.txt_cpassword.Password = null;
            }
            else if (rv == 3)
            {
                MessageBox.Show("Username Do Not Exist");
                this.txt_username.Text = null;
                this.txt_password.Password = null;
                this.txt_cpassword.Password = null;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        private void passvalidation_GotFocus(Object sender, EventArgs e)
        {
            PasswordBox t = sender as PasswordBox;
            t.Background = Brushes.White;
        }
        private void passvalidation_LostFocus(object sender, EventArgs e)
        {
            PasswordBox t = sender as PasswordBox;
            if (t != null)
            {
                if (string.IsNullOrWhiteSpace(t.Password.ToString()))
                {
                    t.Background = Brushes.Red;
                }
            }
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
