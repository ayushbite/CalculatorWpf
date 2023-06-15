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

namespace CalculatorWpf
{
    /// <summary>
    /// Interaction logic for CalStack.xaml
    /// </summary>
    public partial class CalStack : Window
    {
        Queue<string> queue;
        string value;
        public CalStack()
        {
            InitializeComponent();
            queue = new Queue<string>();  
            value = string.Empty;
        }

        private void One(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            value += btn.Content.ToString();
            displaybox.Text = value;
        }

        private void Sub(object sender, RoutedEventArgs e)
        {

            var len = value.Length - 1;
            if (value[len] == '-' || value[len] == '+')
            {
                value = value.Substring(0, len) + "-";
            }
            else
            {
                value += "-";
            }
            displaybox.Text = value;
            resbox.Text = Displayop(value).ToString();
            /* if (value != null)
             {
                 queue.Enqueue(value);

             }

             queue.Enqueue("-");

             value = null;*/
        }
        private void Mul(object sender, RoutedEventArgs e)
        {
            var len = value.Length - 1;
            if (value[len] == '+' || value[len] == '-' || value[len] == '*' || value[len] == '/')
            {
                value = value.Substring(0, len) + "*";
            }
            else
            {
                value += "*";
            }
            displaybox.Text = value;
            resbox.Text = Displayop(value).ToString();

        }

        

        private void Add(object sender, RoutedEventArgs e)
        {
            var len = value.Length - 1;
            if (value[len] == '-' || value[len] == '+')
            {
                value = value.Substring(0, len) + "+";
            }
            else
            {
                value += "+";
            }
            displaybox.Text = value;
           resbox.Text =  Displayop(value).ToString();

          /*  if(value != null)
            {
                queue.Enqueue(value);
              
            }

            queue.Enqueue("+");

            value = null;*/
            
           
        }

        private int Displayop(string value)
        {
           Stack<string> st = new Stack<string>();
            string s = string.Empty;
            foreach(var item in value)
            {
                if(item == '+' || item == '-' || item == '*')
                {
                    if(s != null)
                    {
                        st.Push(s);
                        s = null;
                    }
                    st.Push(item.ToString());
                }
                else
                {
                    s += item.ToString();
                }
               
            }
            if(s != null)
            {
                st.Push(s);
            }
            if(st.Peek() == "+" || st.Peek() == "-")
            {
                st.Push("0");
            }
            else if(st.Peek() == "*" || st.Peek() == "/")
            {
                st.Push("1");
            }
          return  AddStack(st);

        }

        private int  AddStack(Stack<string> st)
        {
            string[] sarr = st.ToArray();
            int sum = 0;
            for (int i = 0; i < sarr.Length; i++)
            {
                if (sarr[i] == "+")
                {
                    sum += Convert.ToInt32(sarr[i - 1]) + Convert.ToInt32(sarr[i + 1]);
                }
                else if (sarr[i] == "-")
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
            return sum;

            /*int i = 0;
           
            while (!(st.Count == 0))
            {

                var b = st.Pop();
                if (b == "+")
                {
                    var c = st.Pop();

                    i += Convert.ToInt32(a) + Convert.ToInt32(c);

                }
                else if (b == "-")
                {
                    var c = st.Pop();
                    i -= Convert.ToInt32(a) - Convert.ToInt32(c);
                }
                else if (b == "*")
                {
                    var c = st.Pop();
                    i *= Convert.ToInt32(a) * Convert.ToInt32(c);
                }
                else if (b == "/")
                {
                    var c = st.Pop();
                    i /= Convert.ToInt32(a) / Convert.ToInt32(c);
                }

            }
            return i;*/
        }

     
    }
}
