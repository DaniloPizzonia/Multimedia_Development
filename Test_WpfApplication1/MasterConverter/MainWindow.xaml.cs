using MasterConverter.Classes;
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
        private Converter myConverter = new Converter();
        public Helper myhelper = new Helper();
        public int bttn1 { get; set; }
        public int bttn2 { get; set; }
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
            textBox_input.MaxLength = 6;
        }

        private void oComboBox_i18n_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            _languageSettings = Properties.Settings.Default.sprache = oComboBox_i18n.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void oButto_restLanguage_Click(object sender, RoutedEventArgs e) {
            Process.Start(Application.ResourceAssembly.Location);
            App.Current.Shutdown();
        }
        private void oButto_intKonvertierer(object sender, RoutedEventArgs e) {
            //var oWindow = new Window_ShowSelection(this, myConverter, myhelper);
            //oWindow.Owner = this;
            //this.Visibility = Visibility.Hidden;
            //oWindow.ShowDialog();
            //Converter myConverter = new Converter();
            //var return2 = this.myConverter.modHigh(6661);

            myConverter.cleanProps();

            swapImages(myConverter.linkeSpalteBaby, left_imageContainer_left, left_imageContainer_right);
            swapImages(myConverter.mittlereSpalteBaby, middle_imageContainer_left, middle_imageContainer_right);
            swapImages(myConverter.rechteSpalteDecBaby, right_imageContainer_left, right_imageContainer_right);
            //System.Windows.MessageBox.Show(return2);
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(oTabItem_babtoDec.IsSelected) {
                myConverter.cleanProps();
                cleanTextBoxBabToDec();
            }
        }

        private void textBox_InputChanged(object sender, TextChangedEventArgs e) {
            string userInput = textBox_input.Text;
            int fetchedUserInput = 0;
            try {
                fetchedUserInput = Convert.ToInt32(userInput);

                if(fetchedUserInput < 0) {
                    // handle input and stop user to enter a negatove value

                    MessageBox.Show("Do not enter negative values!");
                    textBox_input.Text = "";
                    return;
                } else { 
                    // swapImages(fetchedUserInput, right_imageContainer_left);

                    var return2 = this.myConverter.modHigh(fetchedUserInput);

                    swapImages(myConverter.ganzLinkeSpalteBaby, ganzleft_imageContainer_left, ganzleft_imageContainer_right);
                    swapImages(myConverter.linkeSpalteBaby, left_imageContainer_left, left_imageContainer_right);
                    swapImages(myConverter.mittlereSpalteBaby, middle_imageContainer_left, middle_imageContainer_right);
                    swapImages(myConverter.rechteSpalteDecBaby, right_imageContainer_left, right_imageContainer_right);
                }
            } catch(Exception) {
                if(userInput == "") {
                    cleanImageBoxes(2);
                }
                return;
            }           
        }

        private void oEventClick(object sender, RoutedEventArgs e) {

          

            // invoke here the popup and fetch the result from the popup and insert it L/R
            var oBsender = (sender as Button);
            var oImage = (oBsender.Content as Image).Source;
            var oStackPanel = oBsender.Parent as StackPanel;
            Console.WriteLine(oStackPanel.Name);
            IEnumerable<Button> aButton = (oStackPanel.Children as UIElementCollection).OfType<Button>();


            List<Button> selectedPanelWithButtons = new List<Button>();
            switch(oStackPanel.Name) {
                case "SP_veryHigh":
                    if(myhelper.lButtonsVeryHigh.Count < 2) {
                        //addButtonsFromStackPanel(aButton, myhelper);
                        foreach(Button oButton in aButton) {
                            myhelper.lButtonsVeryHigh.Add(oButton);
                            Console.WriteLine(oButton.Name);
                        }
                        
                        // insert here the URI after left the popup
                        //(oBsender.Content as Image).Source = new BitmapImage(new Uri(@"/Images/left/l_1.png", UriKind.Relative));
                    }
                    selectedPanelWithButtons = myhelper.lButtonsVeryHigh;
                    break;
                case "SP_high":
                    if(myhelper.lButtonsHigh.Count < 2) {
                        foreach(Button oButton in aButton) {
                            myhelper.lButtonsHigh.Add(oButton);
                            Console.WriteLine(oButton.Name);
                        }
                        
                    }
                    selectedPanelWithButtons = myhelper.lButtonsHigh;
                    break;
                case "SP_medium":
                    if(myhelper.lButtonsMedium.Count < 2) {
                        foreach(Button oButton in aButton) {
                            myhelper.lButtonsMedium.Add(oButton);
                            Console.WriteLine(oButton.Name);
                        }
                        
                    }
                    selectedPanelWithButtons = myhelper.lButtonsMedium;
                    break;
                case "SP_low":
                    if(myhelper.lButtonslow.Count < 2) {
                        foreach(Button oButton in aButton) {
                            myhelper.lButtonslow.Add(oButton);
                            Console.WriteLine(oButton.Name);
                        }
                        
                    }
                    selectedPanelWithButtons = myhelper.lButtonslow;
                    break;
                default:
                    break;
            }

            

            var oWindow = new Window_ShowSelection(this, myConverter, selectedPanelWithButtons);
            oWindow.Owner = this;
            this.Visibility = Visibility.Hidden;
            oWindow.ShowDialog();
            //(oBsender.Content as Image).Source = new BitmapImage(new Uri(@"/Images/left/l_1.png", UriKind.Relative));
        }

        private void addButtonsFromStackPanel(IEnumerable<Button> aButton, Helper myhelper) {
            foreach(Button oButton in aButton) {
                myhelper.lButtonslow.Add(oButton);
                Console.WriteLine(oButton.Name);
            }
        }

        private void cleanImageBoxes(int amount) {
            switch(amount) {
                case 0:
                    right_imageContainer_left.Source = null;
                    right_imageContainer_right.Source = null;

                    left_imageContainer_left.Source = null;
                    left_imageContainer_right.Source = null;

                    middle_imageContainer_left.Source = null;
                    middle_imageContainer_right.Source = null;
                    break;
                case 1:
                    right_imageContainer_right.Source = null;
                    left_imageContainer_right.Source = null;
                    middle_imageContainer_right.Source = null;
                    break;
                case 2:
                    right_imageContainer_right.Source = null;
                    left_imageContainer_right.Source = null;
                    middle_imageContainer_right.Source = null;
                    break;
                default:
                    break;
            }
        }

        private void cleanTextBoxBabToDec() {
            textBox_output.Text = "";
            _veryHigh_imageContainer_left.Source = null;
            _veryHigh_imageContainer_right.Source = null;
            _high_imageContainer_left.Source = null;
            _high_imageContainer_right.Source = null;
            _medium_imageContainer_left.Source = null;
            _medium_imageContainer_right.Source = null;
            _low_imageContainer_left.Source = null;
            _low_imageContainer_right.Source = null;
        }

        private void swapImages(float input, Image imageContainerLeft, Image imageContainerRight) {
            float devider= input / 10;
            int vorkommastelle = (int) devider;
            float nachkommastelle = (devider - (float) vorkommastelle) *10;
            double nachkommastelleRounded = Math.Round(nachkommastelle);
           swapLeft(vorkommastelle, imageContainerLeft);
           swapRight(nachkommastelleRounded, imageContainerRight);
        }

        private void swapLeft(int num, Image imageContainer) {
            switch(num) {
                case 0:
                    imageContainer.Source = null;
                    break;
                case 1:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/left/l_1.png", UriKind.Relative));
                    break;
                case 2:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/left/l_2.png", UriKind.Relative));
                    break;
                case 3:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/left/l_3.png", UriKind.Relative));
                    break;
                case 4:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/left/l_4.png", UriKind.Relative));
                    break;
                case 5:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/left/l_5.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }

        private void swapRight(double num, Image imageContainer) {
            int numm = (int) num;
            switch(numm) {
                case 0:
                    imageContainer.Source = null;
                    break;
                case 1:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_1.png", UriKind.Relative));
                    break;
                case 2:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_2.png", UriKind.Relative));
                    break;
                case 3:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_3.png", UriKind.Relative));
                    break;
                case 4:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_4.png", UriKind.Relative));
                    break;
                case 5:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_5.png", UriKind.Relative));
                    break;
                case 6:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_6.png", UriKind.Relative));
                    break;
                case 7:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_7.png", UriKind.Relative));
                    break;
                case 8:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_8.png", UriKind.Relative));
                    break;
                case 9:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_9.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }

    }
}
