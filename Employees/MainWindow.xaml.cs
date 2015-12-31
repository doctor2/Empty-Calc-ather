using System.Threading;
using System.Windows;


namespace Employees
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeEntities context;
        public MainWindow()
        {
            InitializeComponent();
            DependencyObject dpObj = LogicalTreeHelper.FindLogicalNode(main, "EditPanel");
            ((FrameworkElement)dpObj).Visibility = Visibility.Collapsed;
            Employeer.IsReadOnly = true;
            
           // Employeer.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd";

            context = new EmployeeEntities();
        }
        
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var customer = Employeer.SelectedItem as Employee;

            context.EmployeeSet.Remove(customer);
            //Save_Click(sender, e);
        }
              
    }
}
