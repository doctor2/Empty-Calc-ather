using System;
using System.Collections;
using System.Windows;


namespace Employees
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double x, y;
        string stroka;
        int IndMult, IndPlus, IndMin, IndDiv, index;
        ArrayList div = new ArrayList();
        
        Func<double, double, double> func_div = (x, y) => x / y;
        Func<double, double, double> func_mult = (x, y) => x * y;
        public MainWindow()
        {
            InitializeComponent();
            Vvod.Focus();
        }

        private void Same_Click(object sender, RoutedEventArgs e)
        {
            Double.TryParse(Vvod.Text, out y);
          //  Vivod.Text =  String.Format("{0}",func(x, y));
            
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                //добавлям в массив позицию элемента деления
                div.Add(Vvod.Text.Length);
                //Double.TryParse(Vvod.Text, out x);
                Vvod.Text = Vvod.Text + "/";
                Vvod.Select(Vvod.Text.Length, 0);
                Vvod.Focus();
                

            }
            catch (Exception)
            {

                MessageBox.Show("Чето не так");
            }

        }
        public void EnterNumber (object sender, RoutedEventArgs e)
        {
            //if (div.Count==0)
            //{
            //    Double.TryParse(Vvod.Text, out x);
            //    Vivod.Text = String.Format("{0}", x);
            //}
            //else
            //{

            //    foreach (var item in div)
            //    {
            //        Double.TryParse(Vvod.Text.Substring(0, (int)item), out x);
            //        Double.TryParse(Vvod.Text.Substring((int)item+1, Vvod.Text.Length - (int)item-1), out y);
            //    }
            //    Vivod.Text = String.Format("{0}", func(x, y));
            //}
            IndMult= Vvod.Text.IndexOf("*");
            IndDiv = Vvod.Text.IndexOf("/");
            IndPlus = Vvod.Text.IndexOf("+");
            IndPlus = Vvod.Text.IndexOf("-");
            index = div.IndexOf(IndMult);
            stroka = Vvod.Text;
            while (stroka.Length != 0)
            {   
                if (Double.TryParse(stroka, out x))
                { Vivod.Text = x.ToString(); stroka = ""; }
                else
	            {
                    if (IndMult > 0 || IndDiv > 0)
                    {
                        if (div.IndexOf(IndMult) < div.IndexOf(IndDiv) || div.IndexOf(IndDiv) == -1)
                        {
                            index = div.IndexOf(IndMult);
                            Double.TryParse(stroka.Substring(index == 0 ? 0 : (int)div[index - 1], div.Count - index - 1 > 0 && index != 0 ? (int)div[index + 1] - IndMult - 1 : IndMult), out x);
                            Double.TryParse(stroka.Substring(IndMult + 1, div.Count-index-1> 0 ? (int)div[index + 1]- IndMult -1 : stroka.Length - IndMult - 1), out y);
                            stroka = stroka.Replace(x.ToString() + "*" + y.ToString(), func_mult(x, y).ToString());
                            //Vivod.Text = String.Format("{0}", func_mult(x, y));
                            //if (Double.TryParse(stroka, out x))
                            //    {
                            //        stroka = "";
                            //    }
                             
                        }
                        else
                        {
                            index = div.IndexOf(IndDiv);
                            Double.TryParse(Vvod.Text.Substring((int)div[index ], IndDiv - (int)div[index]), out x);
                            Double.TryParse(Vvod.Text.Substring(IndDiv + 1, div.Count - index - 1 > 0 ? (int)div[index + 1] : stroka.Length - IndDiv - 1), out y);
                            stroka.Remove((int)div[index ], div.Count - index - 1 > 0 ? (int)div[index + 1] : stroka.Length - IndDiv);
                            Vivod.Text = String.Format("{0}", func_div(x, y));
                        }
                    }
                    else
                    {

                    }
	            }
                
                //if (index > 1)
                //{
                //    Double.TryParse(Vvod.Text.Substring((int)div[index - 1], IndMult - (int)div[index - 1]), out x);
                //    Double.TryParse(Vvod.Text.Substring(IndMult + 1, stroka.Length - IndMult - 1), out y);
                //    Vivod.Text = String.Format("{0}", func_div(x, y));
                //}
                //else
                //{
                //    if (IndMult > 0)
                //    {
                //        Double.TryParse(Vvod.Text.Substring(0, IndMult), out x);
                //        Double.TryParse(Vvod.Text.Substring(IndMult + 1, stroka.Length - IndMult - 1), out y);
                //        Vivod.Text = String.Format("{0}", func_mult(x, y));
                //    }
                //}
            }
            
            
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            //добавлям в массив позицию элемента деления
            div.Add(Vvod.Text.Length);
            Vvod.Text = Vvod.Text + "+";
            Vvod.Select(Vvod.Text.Length, 0);
            Vvod.Focus();
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            //добавлям в массив позицию элемента деления
            div.Add(Vvod.Text.Length);
            Vvod.Text = Vvod.Text + "-";
            Vvod.Select(Vvod.Text.Length, 0);
            Vvod.Focus();
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            //добавлям в массив позицию элемента деления
            div.Add(Vvod.Text.Length);
            Vvod.Text = Vvod.Text + "*";
            Vvod.Select(Vvod.Text.Length, 0);
            Vvod.Focus();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Vvod.Text = "";
            Vvod.Select(Vvod.Text.Length, 0);
            Vvod.Focus();
        }

    }
}
