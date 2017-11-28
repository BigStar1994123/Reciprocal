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
using System.Timers;

namespace TestTimer
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer _timer = new Timer();
        int reciprocalTime = 10;
        public MainWindow()
        {
            InitializeComponent();     
        }

        private void Window_Loaded(object sender , RoutedEventArgs e)
        {
            try
            {
                _timer.Interval = 1000;
                _timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerTick);
                _timer.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TimerTick(object sender , System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (reciprocalTime > 0)
                {
                    reciprocalTime--;
                    //   reciprocal.Text = reciprocalTime.ToString();   
                    Action methodDelegate = delegate ()
                    {
                        reciprocal.Text = reciprocalTime.ToString();
                    };
                    this.Dispatcher.BeginInvoke(methodDelegate);
                }
                else if (reciprocalTime == 0)
                {
                    reciprocalTime = 10;
                    Action methodDelegate = delegate ()
                    {
                        reciprocal.Text = reciprocalTime.ToString();
                    };
                    this.Dispatcher.BeginInvoke(methodDelegate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
