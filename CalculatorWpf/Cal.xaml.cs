using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace CalculatorWpf
{
    /// <summary>
    /// Interaction logic for Cal.xaml
    /// </summary>
    public partial class Cal : Window
    {
        string v1;
        string v2;
        bool toggle = false;
        public Cal()
        {
            InitializeComponent();
        }

    

        private void One(object sender, RoutedEventArgs e)
        {
            if (toggle)
            {
                v2 += "1";
                displaybox.Text += "1";
            }
            else
            {
                v1 += "1";
                displaybox.Text += "1";
            }
        }

        private void Two(object sender, RoutedEventArgs e)
        {
            if (toggle)
            {
                v2 += "2";
                displaybox.Text += "2";
            }
            else
            {
                v1 += "2";
                displaybox.Text += "2";
            }

        }
        private void Three(object sender, RoutedEventArgs e)
        {
            if (toggle)
            {
                v2 += "3";
                displaybox.Text += "3";
            }
            else
            {
                v1 += "3";
                displaybox.Text += "3";
            }

        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if(v2 == null)
            {
                toggle = true;
                displaybox.Text += "+";
            }
            else
            {
                displaybox.Text += "+";
                v1 = Convert.ToString((Convert.ToInt32(v1) + Convert.ToInt32(v2)));
                resbox.Text = v1;
                v2 = "0";
            }
        }
        private void Sub(object sender, RoutedEventArgs e)
        {
            if (v2 == null)
            {
                toggle = true;
                displaybox.Text += "-";
            }
            else
            {
                displaybox.Text += "-";
                v1 = Convert.ToString((Convert.ToInt32(v1) - Convert.ToInt32(v2)));
                resbox.Text = v1;
                v2 = "0";
            }
        }


        private void Zero(object sender, RoutedEventArgs e)
        {
            if (toggle)
            {
                v2 += "0";
            }
            else
            {
                v1 += "0";
            }
        }

        private void Mul(object sender, RoutedEventArgs e)
        {
            if (v2 == null)
            {
                toggle = true;
            }
            else
            {
                v1 = Convert.ToString((Convert.ToInt32(v1) * Convert.ToInt32(v2)));
                v2 = "0";
            }
        }
    }
}
