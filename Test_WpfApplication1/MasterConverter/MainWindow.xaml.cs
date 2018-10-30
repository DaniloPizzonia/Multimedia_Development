using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace MasterConverter {
    
    public partial class MainWindow:Window {
        string sPathImages = Directory.GetCurrentDirectory() + @"\Images\";
        string _languageSettings = Properties.Settings.Default.sprache;
        public enum Culture {
            en, de
        };
        public MainWindow() {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_languageSettings);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(_languageSettings);
            InitializeComponent();
    }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            oComboBox_i18n.ItemsSource = Enum.GetValues(typeof(Culture));
        }

        private void oComboBox_i18n_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            _languageSettings = Properties.Settings.Default.sprache = oComboBox_i18n.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void oButto_restLanguage_Click(object sender, RoutedEventArgs e) {
            Process.Start(Application.ResourceAssembly.Location);
            App.Current.Shutdown();
        }

        private void textBox_InputChanged(object sender, TextChangedEventArgs e) {
            string userInput = textBox_input.Text;
            int fetchedUserInput = 0;
            try {
                fetchedUserInput = Convert.ToInt32(userInput);

                if(fetchedUserInput < 0) {
                    // handle input and stop user to enter a negatove value
                } else if(fetchedUserInput > 59) {
                    if(fetchedUserInput == 60) {
                        imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/right/r_1.png", UriKind.Relative));
                        imageContainer_right.Source = null;
                    } else {
                        // handle input and stop user to enter a higher value than expected
                    }
                } else {
                    swapImages(fetchedUserInput);
                }
            } catch(Exception) {
                //MessageBox.Show("pls enter a number");
                return;
            }           
        }

        private void swapImages(float input) {
            float devider= input / 10;

            int vorkommastelle = (int) devider;
            float nachkommastelle = (devider - (float) vorkommastelle) *10;
            double nachkommastelleRounded = Math.Round(nachkommastelle);
            swapLeft(vorkommastelle);
            swapRight(nachkommastelleRounded);
        }

        private void swapLeft(int num) {
            switch(num) {
                case 0:
                    imageContainer_left.Source = null;
                    break;
                case 1:
                    imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_1.png", UriKind.Relative));
                    break;
                case 2:
                    imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_2.png", UriKind.Relative));
                    break;
                case 3:
                    imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_3.png", UriKind.Relative));
                    break;
                case 4:
                    imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_4.png", UriKind.Relative));
                    break;
                case 5:
                    imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_5.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }

        private void swapRight(double num) {
            int numm = (int) num;
            switch(numm) {
                case 0:
                    imageContainer_right.Source = null;
                    break;
                case 1:
                    imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_1.png", UriKind.Relative));
                    break;
                case 2:
                    imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_2.png", UriKind.Relative));
                    break;
                case 3:
                    imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_3.png", UriKind.Relative));
                    break;
                case 4:
                    imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_4.png", UriKind.Relative));
                    break;
                case 5:
                    imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_5.png", UriKind.Relative));
                    break;
                case 6:
                    imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_6.png", UriKind.Relative));
                    break;
                case 7:
                    imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_7.png", UriKind.Relative));
                    break;
                case 8:
                    imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_8.png", UriKind.Relative));
                    break;
                case 9:
                    imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_9.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }

    }
}
