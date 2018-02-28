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

namespace Assingment_1.Admin
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            var a = new StringBuilder();
            a.AppendLine("                        APPLICATION DEVELOPER");
            a.AppendLine("                                   ZAIN ASGHAR");
            var b = new StringBuilder();
            b.AppendLine("                                        CONTACT");
            b.AppendLine("                        BCSF14A040@PUCIT.EDU.PK");
            b.AppendLine("                                             .");
            b.AppendLine("                                             .");
            b.AppendLine("                                             .");
            b.AppendLine("                             SPECIAL THANKS TO");
            b.AppendLine("                              STACK OVERFLOW");
            b.AppendLine("                               WPF TUTORIALS");




            this.A.Text = a.ToString();
            this.B.Text = b.ToString();
            
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            adminPanel a = new adminPanel();
            this.Hide();
            a.Show();
        }
    }
    public class NegatingConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
            {
                return (-((double)value) -2100);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
            {
                return (+(double)value);
            }
            return value;
        }
    }
}

