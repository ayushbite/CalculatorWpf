using System;
using System.Collections;
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

namespace CalculatorWpf
{
    /// <summary>
    /// Interaction logic for CallStackNew.xaml
    /// </summary>
    public partial class CallStackNew : Window
    {
        String s;
        Queue<String> qt;
        Stack<string> st = new Stack<string>();
        public CallStackNew()
        {
            InitializeComponent();
            qt =  new Queue<string> ();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (s != null)
            {
               qt.Enqueue (s);
                
                s = null;
            }
            qt.Enqueue("+");
            displaybox.Text += "+";

        }

        private void Sub(object sender, RoutedEventArgs e)
        {

            if (s != null)
            {
                qt.Enqueue(s);

                s = null;
            }
            qt.Enqueue("-");
            displaybox.Text += "-";

        }

        private void One(object sender, RoutedEventArgs e)
        {
           
                s += "1";
            displaybox.Text += "1";


        }

        private void Equal(object sender, RoutedEventArgs e)
        {
           /* if (s != null)
            {
                qt.Enqueue (s);
                s= null;
            }*/
            while (!(qt.Count == 0))
            {
                var a = qt.Dequeue();
                if (st.Count == 0)
                {
                    st.Push(a);
                }
                else if (st.Peek() == "+" && a == "+")
                {
                    continue;
                }
                else if (st.Peek() == "+" && a == "-" || (st.Peek() == "+" && a == "*") || (st.Peek() == "+" && a == "/") || (st.Peek() == "+" && a == "%"))
                {
                    st.Pop();
                    st.Push(a);
                }
                else if (st.Peek() == "-" && a == "-")
                {
                    continue;
                }

                else if (st.Peek() == "-" && a == "+" || (st.Peek() == "-" && a == "*") || (st.Peek() == "-" && a == "/") || (st.Peek() == "-" && a == "%"))
                {
                    st.Pop();
                    st.Push(a);
                }

                else if (st.Peek() == "*" && a == "*")
                {
                    continue;
                }
                else if ((st.Peek() == "*" && a == "+") || (st.Peek() == "*" && a == "-") || (st.Peek() == "*" && a == "/") || (st.Peek() == "*" && a == "%"))
                {
                    st.Pop();
                    st.Push(a);
                }
                else if (st.Peek() == "/" && a == "/")
                {
                    continue;
                }
                else if ((st.Peek() == "/" && a == "+") || (st.Peek() == "/" && a == "-") || (st.Peek() == "/" && a == "*") || (st.Peek() == "/" && a == "%"))
                {
                    st.Pop();
                    st.Push(a);
                }
                else if (st.Peek() == "%" && a == "%")
                {
                    continue;
                }
                else if ((st.Peek() == "%" && a == "+") || (st.Peek() == "%" && a == "-") || (st.Peek() == "%" && a == "*") || (st.Peek() == "%" && a == "/"))
                {
                    st.Pop();
                    st.Push(a);
                }
                else
                {
                    st.Push(a);
                }
            }
            if (st.Peek() == "+" || st.Peek() == "-")
            {
                st.Push("0");
            }
            else if (st.Peek() == "*" || st.Peek() == "/")
            {
                st.Push("1");
            }
            //to arr
           string[] sarr =  st.ToArray();
            int sum = 0;
            for (int i = 0; i < sarr.Length;i++)
            {
                if (sarr[i] == "+")
                {
                    sum += Convert.ToInt32(sarr[i - 1]) + Convert.ToInt32(sarr[i + 1]);
                }
                else if(sarr[i] == "-")
                {
                    sum += Convert.ToInt32(sarr[i - 1]) - Convert.ToInt32(sarr[i + 1]);
                }
                else if (sarr[i] == "*")
                {
                    sum += Convert.ToInt32(sarr[i - 1]) * Convert.ToInt32(sarr[i + 1]);
                }
                else if (sarr[i] == "/")
                {
                    sum += Convert.ToInt32(sarr[i - 1]) * Convert.ToInt32(sarr[i + 1]);
                }
            }

            resbox.Text = sum.ToString();   


        }
    }
}
