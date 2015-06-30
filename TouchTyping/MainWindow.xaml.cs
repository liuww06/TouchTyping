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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace TouchTyping
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        LinearGradientBrush pressBruch;
        DoubleAnimation fontSizeAnimation = new DoubleAnimation();
        public MainWindow()
        {
            InitializeComponent();
            pressBruch = this.FindResource("keyPressColor") as LinearGradientBrush;
            fontSizeAnimation.From = 20;
            fontSizeAnimation.To = 80;
            fontSizeAnimation.Duration = TimeSpan.FromSeconds(0.7);
            fontSizeAnimation.Completed += fontSizeAnimation_Completed;
        }

        void fontSizeAnimation_Completed(object sender, EventArgs e)
        {
            this.labTip.Content = string.Empty;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Button btn = this.keyBoardGrid.FindName("btn" + e.Key.ToString().ToUpper()) as Button;
            if (btn!=null)
            {
                btn.Background = pressBruch;
                this.labTip.Content = e.Key.ToString().ToUpper();
                this.labTip.BeginAnimation(Label.FontSizeProperty, fontSizeAnimation);
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            Button btn = this.keyBoardGrid.FindName("btn" + e.Key.ToString().ToUpper()) as Button;
            if (btn != null)
            {
                btn.Background = null;
            }
        }
    }
}
