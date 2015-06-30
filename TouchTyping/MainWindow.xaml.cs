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

namespace TouchTyping
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        LinearGradientBrush pressBruch; 
        public MainWindow()
        {
            InitializeComponent();
            pressBruch = this.FindResource("keyPressColor") as LinearGradientBrush;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Button btn = this.keyBoardGrid.FindName("btn" + e.Key.ToString().ToUpper()) as Button;
            if (btn!=null)
            {
                btn.Background = pressBruch;
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
