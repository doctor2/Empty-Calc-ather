using System.Windows;
using System.Windows.Controls;


namespace Employees
{
    /// <summary>
    /// Interaction logic for UserCont.xaml
    /// </summary>
    public partial class UserCont : UserControl
    {
        //DoubleAnimation anim;
        //int left;
        //int top;
        //DependencyProperty prop;
        //int end;
       // private readonly Timer tmrShow;
        public UserCont()
        {
            InitializeComponent();
            //TrayPos tpos = new TrayPos();
            //tpos.getXY((int)this.Width, (int)this.Height, out top, out left, out prop, out end);
            ////this.Top = top;
            ////this.Left = left;
            //anim = new DoubleAnimation(end, TimeSpan.FromSeconds(5));
        }
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
        }
        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    AnimationClock clock = anim.CreateClock();
        //    this.ApplyAnimationClock(prop, clock);
        //}
    }
}
