using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Media;
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
        List<Chicken> lChicken;
        double oGoal;
        static string sSoundPath = Environment.CurrentDirectory;
        SoundPlayer oSoundPlayer = new SoundPlayer(sSoundPath + @"\Media\wave.wav");
         
        public MainWindow() {
            InitializeComponent();
            lChicken = App._gameData.lChicken;
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
                    MessageBox.Show(sMessage += lChicken[i].getName);
                    speechOutput(sMessage);
                }
            }
        }
        private void speechOutput(string message) {
            SpeechSynthesizer oSpeech = new SpeechSynthesizer();
            oSpeech.SpeakAsync(new Prompt(message));
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
            oGoal= oCanvas_Road.ActualWidth - (double) oRectangle_Goal.GetValue(Canvas.RightProperty);

            for(int i = 0; i < lChicken.Count; i++) {
                lChicken[i].getImageChicken = oCanvas_Road.FindName("oImage_Chicken" + i) as Image;
                lChicken[i].getImageChicken.ToolTip = lChicken[i].getName;
            }
            oComboBox_Player0.ItemsSource = App._gameData.lPlayer;
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
            App._gameData.lChicken[0].getNumberRuns = 20;
            Save.saveObject<Game>(App._gameData, "GameData.txt");
        }

        private void oCanvas_Road_SizeChanged(object sender, SizeChangedEventArgs e) {
            oGoal = oCanvas_Road.ActualWidth - (double)oRectangle_Goal.GetValue(Canvas.RightProperty);
        }

        private void oButton_Add_Click(object sender, RoutedEventArgs e) {
            var sPlayerName = oTextBox_AddNewPlayer.Text;
            if(sPlayerName == "") {
                MessageBox.Show("Bitte Name eingeben");
            }  else {
                var oIsPlayerAvailable = (from s in App._gameData.lPlayer
                            where s.getSetName == sPlayerName
                            select s ).FirstOrDefault();
                if(oIsPlayerAvailable == null) {
                    var oPlayer = new Player(sPlayerName, false);
                    App._gameData.lPlayer.Add(oPlayer);
                    oTextBox_AddNewPlayer.Text = "";
                    MessageBox.Show("Spieler " + sPlayerName + " wurde erfolgreich hinzugefügt!");
                } else {
                    MessageBox.Show("Spieler " + sPlayerName + " existiert schon, bitte neuen Name eingeben!");
                }
                
            }
        }
        private bool isPlayerAvailable(string sPlayerName) {
            var bReturn = true;
            for(int i = 0; i < App._gameData.lPlayer.Count; i++) {
                if(App._gameData.lPlayer[i].getSetName == sPlayerName) {
                    bReturn = false;
                }
            }
            return bReturn;
        }
    }
}
