﻿using System;
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
        DoubleAnimation closeAnimation = new DoubleAnimation();
        DoubleAnimation moveAnimation = new DoubleAnimation();
        public MainWindow()
        {
            InitializeComponent();
            pressBruch = this.FindResource("keyPressColor") as LinearGradientBrush;
            fontSizeAnimation.From = 20;
            fontSizeAnimation.To = 80;
            fontSizeAnimation.Duration = TimeSpan.FromSeconds(1);
            fontSizeAnimation.Completed += fontSizeAnimation_Completed;
            //fontSizeAnimation.AutoReverse = true;
            //fontSizeAnimation.SpeedRatio = 2;
            fontSizeAnimation.AccelerationRatio = 0.3;
            fontSizeAnimation.DecelerationRatio = 0.3;

            closeAnimation.To = 0;
            closeAnimation.Duration = TimeSpan.FromMilliseconds(800);
            closeAnimation.Completed += closeAnimation_Completed;


            moveAnimation.From = 0;
            moveAnimation.To = this.canMoveArea.ActualWidth;
            moveAnimation.RepeatBehavior = RepeatBehavior.Forever;
            moveAnimation.Duration = TimeSpan.FromSeconds(5);
            //this.btnTest.BeginAnimation();
        }

        void closeAnimation_Completed(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.BeginAnimation(Window.HeightProperty, closeAnimation);
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
