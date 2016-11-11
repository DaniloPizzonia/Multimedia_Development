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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Adventskalender {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow:Window {
        List<Questions> lQuestions;
        User oUser;
        UsedQuestion oUsedQuestion;
        int questionNumber;
        public MainWindow() {
            InitializeComponent();
            lQuestions = Save.readXML<List<Questions>>("storage.xml");
            if(lQuestions == null) {
                lQuestions = new List<Questions>();
            }
            oUser = Save.readXML<User>("User.xml");
            if(oUser == null) {
                oUser = new User();
            }
        }

        private void oCanvas_Image_MouseDown(object sender, MouseButtonEventArgs e) {
            if(e.OriginalSource.GetType() != typeof(Ellipse)) {
                this.DragMove();
            }
            
        }

        private void oButton_Close_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
        Random rnd = new Random();
        private void Window_Loaded(object sender, RoutedEventArgs e) {

            foreach(var oItem in oCanvas_Image.Children) {
                var oItemEl = (oItem as Ellipse);
                
                if(oItem.GetType().ToString().Contains("Ellipse") 
                && oItemEl.Name == "") {
                    ColorAnimation oColorAnimation = new ColorAnimation();
                    oColorAnimation.From = Colors.Transparent;
                    oColorAnimation.To = Color.FromArgb((byte)rnd.Next(256),
                                                        (byte)rnd.Next(256),
                                                        (byte)rnd.Next(256),
                                                        (byte)rnd.Next(256));
                    oColorAnimation.Duration = TimeSpan.FromSeconds(rnd.Next(1, 6));
                    oColorAnimation.AutoReverse = true;
                    oColorAnimation.RepeatBehavior = RepeatBehavior.Forever;

                    SolidColorBrush  oSolidColorBursh = new SolidColorBrush();

                    oItemEl.Fill = oSolidColorBursh;
                    oSolidColorBursh.BeginAnimation(SolidColorBrush.ColorProperty, oColorAnimation);

                }
            }
        }

        private void oEllipse_Door_MouseUp(object sender, MouseButtonEventArgs e) {
            
            bool bContains = true;
            const int iReset = -1;
            int iId = iReset;
            do {
                questionNumber = rnd.Next(lQuestions.Count);
                iId = lQuestions[questionNumber].QuestionsId;
                var qSmth = (from g in oUser.usedQuestions where g.QuestionId == iId select g).FirstOrDefault();
                if(qSmth == null ) {
                    bContains = false;
                } else {
                    if(oUser.usedQuestions.Count == lQuestions.Count) {
                        bContains = false;
                        iId = iReset;
                        MessageBox.Show("Alle Fragen wurden gestellt");                    }
                }
            } while(bContains);
            if(iId > iReset) {
                oUsedQuestion = new UsedQuestion { QuestionId = iId, isRight = false };
                    oUser.usedQuestions.Add(oUsedQuestion);
                //Storyboard sb = FindResource("") as Storyboard; sb.Begin();
                
                oStackPanel_Quiz.DataContext = lQuestions[questionNumber];
                oGrid_ScreenGoodies.Visibility = Visibility.Visible;
            }
           
        }

        private void oButton_Collapse_Click(object sender, RoutedEventArgs e) {
            oGrid_ScreenGoodies.Visibility = Visibility.Collapsed;
        }

        private void ListBox_Answers_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            string result = "";
            if(((sender as ListBox).SelectedItem) == null) {
                return;
            }
            if(((sender as ListBox).SelectedItem as Answers).isRight) {
                oUsedQuestion.isRight = true;
                result = "Hurrraaaa";
            } else {
                result = "buuuh";
            }
            MessageBox.Show(result, "Die Leistung war...");
            oButton_Collapse_Click(null, null);
        }

        private void Window_Closed(object sender, EventArgs e) {
            Save.saveXML<User>( oUser,"User.xml");
        }
    }
}
