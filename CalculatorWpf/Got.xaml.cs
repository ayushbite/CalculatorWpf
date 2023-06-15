using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.Serialization;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CalculatorWpf
{
    /// <summary>
    /// Interaction logic for Got.xaml
    /// </summary>
    public partial class Got : Window
    {
        string s = string.Empty;
        int rose;
        int len;
        public Got()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            len = s.Length - 1;

            if(s.Count() == 0)
            {
                return;
            }

            /*if (s[len] == '0' || s[len] == '1')
            {
                return;
            }*/
            if (s[len] == '-' || s[len] == '+')
            {
                s = s.Substring(0, len) + "+";
            }
            if (!(s[len] == '+'))
            {
                s += "+";
            }
            len = s.Length - 1;
            if (s[len] == '+')
            {
               rose +=  Calc(s, 0,'+');
              s= string.Empty;
              
                
            }

        }

        private void One(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            s += btn.Content.ToString();
           
        }
        private int Calc(string s,int val,char op)
        {
            int result =0;
            if (op == '+')
            {
                var res = s.Split('+');
                result =  Convert.ToInt32(res[0]) + val;
            }
            return result;
        }
      
    }
}
