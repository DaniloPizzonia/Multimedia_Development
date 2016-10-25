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
using System.Windows.Threading;

namespace ChickenRun {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        DispatcherTimer oTimer = new DispatcherTimer();
        Random oRandom = new Random();
        double oGoal;
        
        public MainWindow() {
            InitializeComponent();
            oTimer.Interval = TimeSpan.FromSeconds(0.01);
            oTimer.Tick += TimerTick;
        }

        private void TimerTick(object sender, EventArgs e) {
            
            if((double)oImage_ChickenOne.GetValue(Canvas.LeftProperty) >= oGoal) {
                MessageBox.Show("Win!");
                oTimer.Stop();
                newGame();
                
            } else{
                moveChicken(oImage_ChickenOne);
            }
        }

        private void newGame() {
            oButton_NewGame.IsEnabled = true;
        }

        private void oButton_Start_Click(object sender, RoutedEventArgs e) {
            oTimer.Start();
            (sender as Button).IsEnabled = false;
        }

        private void moveChicken(Image oImage) {
            var fStep = oRandom.Next(0, 20);
            double fPosX = (double)oImage_ChickenOne.GetValue(Canvas.LeftProperty) + fStep;
            oImage_ChickenOne.SetValue(Canvas.LeftProperty, fPosX);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
           oGoal= (double) oRectangle_Goal.GetValue(Canvas.LeftProperty);
        }

        private void oButton_NewGame_Click(object sender, RoutedEventArgs e) {
            (sender as Button).IsEnabled = false;
            oButton_Start.IsEnabled = true;
            resetChickenPosition();
        }

        private void resetChickenPosition() {
            oImage_ChickenOne.SetValue(Canvas.LeftProperty, 20d);
        }
    }
}
