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
        List<Chicken> lChicken = new List<Chicken>();
        double oGoal;
        
        public MainWindow() {
            InitializeComponent();
            oTimer.Interval = TimeSpan.FromSeconds(0.1);
            oTimer.Tick += TimerTick;
        }

        private void TimerTick(object sender, EventArgs e) {
            List<Chicken> lWinner = new List<Chicken>();
            string sMessage = "The winner is: ";
            for(int i = 0; i < lChicken.Count; i++) {
                moveChicken(lChicken[i]);
                Image oImage = oCanvas_Road.FindName("oImage_Chicken" + i) as Image;
                if((double)oImage.GetValue(Canvas.LeftProperty) >= oGoal) {
                    lWinner.Add(lChicken[i]);

                }
                if(lWinner.Count >0) {
                    oTimer.Stop();
                    newGame();
                    MessageBox.Show(sMessage + lChicken[i].getName);
                }
            }
        }

        private void newGame() {
            oButton_NewGame.IsEnabled = true;
        }

        private void oButton_Start_Click(object sender, RoutedEventArgs e) {
            oTimer.Start();
            (sender as Button).IsEnabled = false;
        }

        private void moveChicken(Chicken oChicken) {
            var dStep = oRandom.Next(0, 20);
            double dPosX = (double)oChicken.getImageChicken.GetValue(Canvas.LeftProperty) + dStep;
            oChicken.getImageChicken.SetValue(Canvas.LeftProperty, dPosX);
            walkAnimation(oChicken);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
           oGoal= (double) oRectangle_Goal.GetValue(Canvas.LeftProperty);
            lChicken = Save.readDataFile <List<Chicken>>("storage.txt");
            if(lChicken == null) {
                lChicken = new List<Chicken>();
                for(int i = 0; i < 4; i++) {
                    Image oImage = oCanvas_Road.FindName("oImage_Chicken" + i) as Image;
                    var oChicken = new Chicken(i, oImage);
                    oImage.ToolTip = oChicken.getName;
                    lChicken.Add(oChicken);
                }
            } else {
                for(int i = 0; i < lChicken.Count; i++) {
                    lChicken[i].getImageChicken = oCanvas_Road.FindName("oImage_Chicken" + i) as Image;
                    lChicken[i].getImageChicken.ToolTip = lChicken[i].getName;
                }
            }
            
        }

        private void oButton_NewGame_Click(object sender, RoutedEventArgs e) {
            (sender as Button).IsEnabled = false;
            oButton_Start.IsEnabled = true;
            resetChickenPosition();
        }

        private void resetChickenPosition() {
            for(int i = 0; i < lChicken.Count; i++) {
                Image oImage = oCanvas_Road.FindName("oImage_Chicken" + i) as Image;
                oImage.SetValue(Canvas.LeftProperty, 20d);
            }
        }
        
        private void walkAnimation(Chicken oChicken) {
            int iImageNumber = oChicken.imageChanged ? 1 : 0;
            oChicken.imageChanged = !oChicken.imageChanged;
            BitmapImage oWalkImage = new BitmapImage(
                new Uri(String.Format(
                "Images/{0}_{1}.jpg", oChicken.getName ,iImageNumber),
                UriKind.Relative
            ));
            oChicken.getImageChicken.Source = oWalkImage;
        }

        private void Window_Closed(object sender, EventArgs e) {
            Save.saveObject<List<Chicken>>(lChicken, "storage.txt");
        }
    }
}
