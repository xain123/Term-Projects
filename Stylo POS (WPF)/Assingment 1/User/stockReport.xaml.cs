﻿using System;
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
    /// Interaction logic for stockReport.xaml
    /// </summary>
    public partial class stockReport : Window
    {
        public stockReport()
        {
            InitializeComponent();
            from.SelectedDate = DateTime.Today;
            to.SelectedDate = DateTime.Today;
            this.dataGrid.ItemsSource = getItems();
        }
        List<ItemBO> getItems()
        {
            ItemBLL ib = new ItemBLL();
            return ib.getItem();

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
            List<ItemBO> ls = ib.getStockReport(from, to);
            this.dataGrid.ItemsSource = ls;

        }
        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            reportPanel a = new reportPanel();
            this.Hide();
            a.Show();
        }

        private void view_btn_Click(object sender, RoutedEventArgs e)
        {
            this.dataGrid.ItemsSource = getItems();
        }
    }
}
