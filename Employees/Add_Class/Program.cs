using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Employees
{
    public partial class Employee
    {
        public Employee()
        {
            Expiration_date = DateTime.Today;
        }
    }
    public delegate void mydeleg();
    public partial class MainWindow : Window
    {
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Загрузка данных асинхронно
            try
            {
                var action = new Action(MyTask);
                // Создание экземпляра задачи.
                var task = new Task(action);
                // Выполнение задачи.
                task.Start();
            }
            catch
            {
                MessageBox.Show("Somthing wrong");
            }
            //    abcd.DataContext = context.EmployeeSet.Local.ToBindingList();
            //  abcd.Columns[1].Visibility = Visibility.Collapsed;
            //Employeer.Columns[3].Visibility = Visibility.Collapsed;
        }
        private void MyTask()
        {
            context.EmployeeSet.Load();
            Application.Current.Dispatcher.Invoke((Action)(() =>
            {
                // update collection here
                Employeer.DataContext = context.EmployeeSet.Local.ToBindingList();
            }));
//            Employeer.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, new Action(delegate{
//// your code
//                 Employeer.DataContext = context.EmployeeSet.Local.ToBindingList();
//}));
        }

        private void Employeer_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }
        # region ToggleButton - кнопка, вызывающая панель редактирования
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Employeer.IsReadOnly = false;
            //DependencyObject dpObj = LogicalTreeHelper.FindLogicalNode(main, "EditPanel");
            //((FrameworkElement)dpObj).Visibility = Visibility.Visible;   
            EditPanel.Visibility = Visibility.Visible;
        }
        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Employeer.IsReadOnly = true;
            EditPanel.Visibility = Visibility.Collapsed;
            //DependencyObject dpObj = LogicalTreeHelper.FindLogicalNode(main, "EditPanel");
            //((FrameworkElement)dpObj).Visibility = Visibility.Collapsed;
        }
        # endregion
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.SaveChanges();
                MessageBox.Show("sucseed");
            }
            catch
            {
                MessageBox.Show("Somthing wrong");
            }

        }
    }

}
