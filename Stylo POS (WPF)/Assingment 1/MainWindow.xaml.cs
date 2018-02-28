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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL;
using BO;
using Assingment_1.User;

namespace Assingment_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginHandler_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txt_username.Text) || string.IsNullOrWhiteSpace(this.txt_password.Password.ToString()))
            {
                if (string.IsNullOrWhiteSpace(this.txt_username.Text))
                {
                    txt_username.Background = Brushes.Red;
                }
                if (string.IsNullOrWhiteSpace(this.txt_password.Password.ToString()))
                {
                    txt_password.Background = Brushes.Red;
                }
                MessageBox.Show("Validate");

                return;
            }
            loginBLL aBLL = new loginBLL();
            loginBO lBO = new loginBO();
            lBO.Username = this.txt_username.Text;
            lBO.Password = this.txt_password.Password.ToString();
            int rv;
            rv = aBLL.login(lBO);

            if (rv == 1)
            {
                //MessageBox.Show("Loged in");
                //this.Show(adminPanel.x);
                adminPanel a = new adminPanel();
                this.Hide();
                a.Show();

            }
            else if (rv == 2)
            {
                //MessageBox.Show("User Panael");
                global.user = this.txt_username.Text;
                userPanel u = new userPanel();
                this.Hide();
                u.Show();
            }
            else if (rv == 3)
            {
                MessageBox.Show("User Do Not Exist");

            }
            else if (rv == 4)
            {
                MessageBox.Show("Invalid Username/Password");
            }
        }

        private void exitHandler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
