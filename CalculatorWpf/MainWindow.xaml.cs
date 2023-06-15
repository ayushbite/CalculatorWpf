using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace CalculatorWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string prev = "";
        string next = "0";
        int counter = 0;
        bool isnextnum = false; 

        public MainWindow()
        {
            InitializeComponent();

        }

        private void div(object sender, RoutedEventArgs e)
        {
            displaybox.Text += "+";
            if (next == "0")
            {
                next = "1";
            }

            prev = Convert.ToString(Convert.ToInt64(prev) / Convert.ToInt64(next));
            next = "0";
            counter++;
            isnextnum = !isnextnum;
            resbox.Text = prev;

        }
        private void add(object sender, RoutedEventArgs e)
        {
            displaybox.Text += "+";
            prev = Convert.ToString(Convert.ToInt64(prev) + Convert.ToInt64(next));
            next = "0";
            counter++;
            isnextnum = !isnextnum;
            resbox.Text = prev;

        }
        private void sub(object sender, RoutedEventArgs e)
        {
            displaybox.Text += "-";
            prev = Convert.ToString(Convert.ToInt64(prev) - Convert.ToInt64(next));
            next = "0";
            counter++;
            isnextnum = !isnextnum;
            resbox.Text = prev;

        }
        private void mul(object sender, RoutedEventArgs e)
        {
            displaybox.Text += "x";
            if (next == "0")
            {
                next = "1";
            }
            prev = Convert.ToString(Convert.ToInt64(prev) * Convert.ToInt64(next));
            next = "0";
            counter++;
            isnextnum = !isnextnum;
            resbox.Text = prev;

        }
        private void equal(object sender, RoutedEventArgs e)
        {

            displaybox.Text = Convert.ToString(Convert.ToInt32(prev) + Convert.ToInt32(next));
            if (displaybox.Text.Contains("+"))
            {
                displaybox.Text = Convert.ToString(Convert.ToInt32(prev) + Convert.ToInt32(next));
            }
            else if (displaybox.Text.Contains("-"))
            {
                displaybox.Text = Convert.ToString(Convert.ToInt32(prev) - Convert.ToInt32(next));
            }
            else if (displaybox.Text.Contains("x"))
            {
                displaybox.Text = Convert.ToString(Convert.ToInt32(prev) * Convert.ToInt32(next));
            }
            else if (displaybox.Text.Contains("/"))
            {
                displaybox.Text = Convert.ToString(Convert.ToInt32(prev) / Convert.ToInt32(next));
            }
            prev = displaybox.Text;
        }

        private void NumberClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;



            if (counter <= 0)
            {
                prev += btn.Content.ToString();

                displaybox.Text += btn.Content.ToString();
            }
            else
            {
                next += btn.Content.ToString();

                displaybox.Text += btn.Content.ToString();
            }




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            prev = "0";
            displaybox.Text = prev;
            next = "0";
        }
    }


}
