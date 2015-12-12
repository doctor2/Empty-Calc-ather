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
        string stroka, strokatmp;
        int IndMult, IndPlus, IndMin, IndDiv, index;
        ArrayList div = new ArrayList();
        char[] znak = { '*', '/', '+', '-' };
        char[] pm = { '+', '-' };
        char[] md = { '*', '/' };
        
        Func<double, double, double> func_div = (x, y) => x / y;
        Func<double, double, double> func_mult = (x, y) => x * y;
        Func<double, double, double> func_plus = (x, y) => x + y;
        Func<double, double, double> func_minus = (x, y) => x - y;
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
               // div.Add(Vvod.Text.Length);
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
        private void FindFault(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            short value;

            // Если: введена не цифра
            if (!Int16.TryParse(e.Text, out value))
            {
                // То: Указываем, что событие обработано и распространятся далее не должно.
                e.Handled = true;
            }
        }

        public void EnterNumber (object sender, RoutedEventArgs e)
        {
            try
            {
            stroka = Vvod.Text;
            strokatmp =Vvod.Text;
            while (stroka.Length != 0 && stroka.IndexOfAny(md)>0)
            {
                Search();
                IndMult= stroka.IndexOf("*");
                IndDiv = stroka.IndexOf("/");
                if (IndMult>0 && IndDiv<0)
	                {
                        stroka = Function(IndMult,0);
                    //  temp = div.BinarySearch(IndMult);
                    //if (temp == 0 )                                      
                    //    {
                    //            Double.TryParse(stroka.Substring(0,IndMult), out x);
                    //            Double.TryParse(stroka.Substring(IndMult + 1,div.Count==1 ? stroka.Length - IndMult - 1: (int)div[1]- IndMult - 1 ), out y);
                    //            strokatmp = stroka.Replace(x.ToString() + "*" + ((int)y == 0 ? String.Empty : y.ToString()), ((int)y == 0 ? x.ToString() : func_mult(x, y).ToString()));
                    //    }
                    //else
                    //    {
                    //            Double.TryParse(stroka.Substring((int)div[temp-1]+1, IndMult -(int)div[temp-1]-1), out x);
                    //            Double.TryParse(stroka.Substring(IndMult + 1,div.Count==temp+1 ? stroka.Length - IndMult - 1: (int)div[temp+1]- IndMult - 1 ), out y);
                    //            strokatmp = stroka.Replace(x.ToString() + "*" + ((int)y == 0 ? String.Empty : y.ToString()), ((int)y == 0 ? x.ToString() : func_mult(x, y).ToString()));
                    //    }
	                }
                else
                {
                    if (IndDiv>0 && IndMult<0)
                    {
                        stroka = Function(IndDiv,1);
                    }
                    else{
                        if (IndDiv>IndMult)
                        {
                            stroka = Function(IndMult, 0);
                        }
                        else
                        {
                            if (IndDiv!=-1 && IndMult!=-1)
                            {
                                stroka = Function(IndDiv, 1);
                            }  
                        }
                    }
                }
            }
            bool fl = true;
            while (stroka.Length != 0 && stroka.IndexOfAny(pm) >= 0 && fl)
            {
                Search();
                IndPlus = stroka.IndexOf("+");
                IndMin = stroka.IndexOf("-");
                if (IndPlus >= 0 && IndMin < 0)
                {
                    stroka = Function(IndPlus, 2);      
                }
                else
                {
                    if (IndMin >= 0 && IndPlus < 0)
                    {
                        if (IndMin == 0 && div.Count==1)
                        {
                            fl = false;
                        }
                        else
                        {
                            if (IndMin == 0)
                            {
                                stroka = Function((int)div[1], 2);
                            }
                            else
                            {
                                stroka = Function(IndMin, 3); // stroka = Function((int)div[1], 2);
                            }
                            
                        }
                    }
                    else
                    {
                        if (IndMin > IndPlus )
                        {
                            stroka = Function(IndPlus, 2); 
                        }
                        else
                        {
                            if (IndPlus!=-1 && IndMin!=-1)
                            {
                                if (IndMin==0 && (int)div[1]== IndPlus)
                                {
                                     stroka = Function(IndPlus, 3); 
                                }
                                else
                                {  
                                        stroka = Function(IndMin, 3);                                 
                                }
                            }
                        }
                    }
                }
            }
            Vivod.Text = strokatmp;
           
            }
            catch 
            {      
                Vivod.Text="Ошибка";
            }
            
            
        }

        public string Function(int temp, int change)
        {
            int temp1 = div.BinarySearch(temp);
            if (temp1 == 0)
            {
                Double.TryParse(stroka.Substring(0, temp), out x);
                Double.TryParse(stroka.Substring(temp + 1, div.Count == 1 ? stroka.Length - temp - 1 : (int)div[1] - temp - 1), out y);
                strokatmp = stroka.Remove(0, div.Count == 1 ? stroka.Length : (int)div[1]);
                strokatmp = ((int)y == 0 ? x.ToString() : Change_Fun(change, x, y)) + strokatmp;
                
               // strokatmp = stroka.Replace(x.ToString() + "*" + ((int)y == 0 ? String.Empty : y.ToString()), ((int)y == 0 ? x.ToString() : Change_Fun(change,x,y)));
            }
            else
            {
                Double.TryParse(stroka.Substring((int)div[temp1 - 1] + 1, temp - (int)div[temp1 - 1] - 1), out x);
                Double.TryParse(stroka.Substring(temp + 1, div.Count == temp1 + 1 ? stroka.Length - temp - 1 : (int)div[temp1 + 1] - temp - 1), out y);
                strokatmp = stroka.Remove((int)div[temp1 - 1] + 1, div.Count == temp1 + 1 ? stroka.Length - (int)div[temp1 - 1] - 1 : (int)div[temp1 + 1] - (int)div[temp1 - 1] - 1);
                strokatmp = div.Count == temp1 + 1 ? strokatmp + ((int)y == 0 ? x.ToString() : Change_Fun(change, x, y)) : strokatmp.Insert((int)div[temp1 - 1] + 1,((int)y == 0 ? x.ToString() : Change_Fun(change, x, y)));
                if ((int)div[0] == 0 && x < y)
                {
                    strokatmp = strokatmp.Remove(0, 2);
                }
               // strokatmp = stroka.Replace(x.ToString() + "*" + ((int)y == 0 ? String.Empty : y.ToString()), ((int)y == 0 ? x.ToString() : Change_Fun(change, x, y)));
            }
            return strokatmp;
        }

        public string Change_Fun(int ch, double x, double y)
        {
            switch (ch)
            {
                case 0:
                    return func_mult(x, y).ToString();
                case 1:
                    return func_div (x, y).ToString();
                case 2:
                    return func_plus(x, y).ToString();
                case 3:
                    return func_minus(x, y).ToString();
                default:
                    return "";
                   // break;
            }
        }
        private void Search ()
        {
            
            div.Clear();
            int temp = 0;
            while (stroka.IndexOfAny(znak) >= 0)
            {
                IndMult = stroka.IndexOfAny(znak);
                div.Add(IndMult + temp);
                stroka = stroka.Remove(IndMult, 1);
                temp = temp + 1;
            }
            stroka = strokatmp;
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            //добавлям в массив позицию элемента деления
           // div.Add(Vvod.Text.Length);
            Vvod.Text = Vvod.Text + "+";
            Vvod.Select(Vvod.Text.Length, 0);
            Vvod.Focus();
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            //добавлям в массив позицию элемента деления
           // div.Add(Vvod.Text.Length);
            Vvod.Text = Vvod.Text + "-";
            Vvod.Select(Vvod.Text.Length, 0);
            Vvod.Focus();
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            //добавлям в массив позицию элемента деления
           // div.Add(Vvod.Text.Length);
            Vvod.Text = Vvod.Text + "*";
            Vvod.Select(Vvod.Text.Length, 0);
            Vvod.Focus();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Vvod.Text = String.Empty;
            Vvod.Select(Vvod.Text.Length, 0);
            Vvod.Focus();
        }

    }
}
