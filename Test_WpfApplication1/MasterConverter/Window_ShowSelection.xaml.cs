using MasterConverter;
using MasterConverter.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MasterConverter {
    /// <summary>
    /// Interaction logic for Window_ShowEdit.xaml
    /// </summary>
    public partial class Window_ShowSelection : Window {

        MainWindow oParentWindow;
        Converter oConverter;
        //Helper oHelper;
        List<Button> myButtonList;
        bool? isToggleCheckedLow;
        int counterLow;
   
        

        bool? isToggleCheckedHigh;
        int counterHigh;

        public Window_ShowSelection(MainWindow oParentWindowCommit, Converter myConverter, List<Button> selectedPanelWithButtons) {
            // initiilize variables for using 
            oParentWindow = oParentWindowCommit;
            oConverter = myConverter;
            myButtonList = selectedPanelWithButtons;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }

        private void Window_Closed(object sender, EventArgs e) {
            this.Owner.Visibility = Visibility.Visible;
        }

        private void oButton_SavePipe_Click(object sender, RoutedEventArgs e) {
            //oParentWindow.bttn1 = 0;
            //oParentWindow.bttn1 = 0;
            if(oConverter.mittlereSpalteBaby == 0) {
                oParentWindow.SP_medium.Visibility = Visibility.Visible;
            } else if(oConverter.linkeSpalteBaby == 0) {
                oParentWindow.SP_high.Visibility = Visibility.Visible;
            } else if(oConverter.ganzLinkeSpalteBaby == 0) {
                oParentWindow.SP_veryHigh.Visibility = Visibility.Visible;
            }

            //Console.WriteLine(oConverter.babToDec(oConverter.ganzLinkeSpalteBaby, oConverter.linkeSpalteBaby, oConverter.mittlereSpalteBaby, oConverter.rechteSpalteDecBaby));
            oParentWindow.textBox_output.Text = oConverter.babToDec(oConverter.ganzLinkeSpalteBaby, oConverter.linkeSpalteBaby, oConverter.mittlereSpalteBaby, oConverter.rechteSpalteDecBaby).ToString();
            this.Owner.Visibility = Visibility.Visible;
            this.Close();

        }

        private void saveValuesBabToDec(string StackpanelName, int value) {
            switch(StackpanelName) {
                case "SP_veryHigh":
                    oConverter.ganzLinkeSpalteBaby = value;
                    break;
                case "SP_high":
                    oConverter.linkeSpalteBaby = value;
                    break;
                case "SP_medium":
                    oConverter.mittlereSpalteBaby = value;
                    break;
                case "SP_low":
                    oConverter.rechteSpalteDecBaby = value;
                    break;
                default:
                    break;

            }
        }

        private void HandleCheck(object sender, RoutedEventArgs e) {
            //text2.Text = "Button is Checked";
            ToggleButton bla = ((ToggleButton)sender);
            int value = Convert.ToInt32(Regex.Match(bla.Name, @"\d+").Value);
            isToggleCheckedLow = bla.IsChecked;
            var sourceImage = ((BitmapFrame)(bla.Content as Image).Source).ToString();
            // Here we call Regex.Match.
            Match match = Regex.Match(sourceImage, @"/Images/(.*)");
            var clickedImageSource = match.ToString();


            var bttn = myButtonList[1];

            setBtnImage(bttn, clickedImageSource);
            var stackpanel_name_from_button = (bttn.Parent as StackPanel).Name;

            oParentWindow.bttn2 = 0;
            oParentWindow.bttn2 = value;
            value = oParentWindow.bttn2 + oParentWindow.bttn1;
            saveValuesBabToDec(stackpanel_name_from_button, value);
            counterLow += 1;

            if((bool)isToggleCheckedLow && counterLow > 1) {
                bla.IsChecked = false;
                counterLow = 1;
                return;
            }

            setPreview(single_imageContainer_right, clickedImageSource);
            oConverter.selectedSpalteBaby = value;
            //MessageBox.Show(value.ToString());
        }

        private void HandleCheckHigh(object sender, RoutedEventArgs e) {
           
           
            ToggleButton bla = ((ToggleButton)sender);
            var value = Convert.ToInt32(Regex.Match(bla.Name, @"\d+").Value);
            isToggleCheckedHigh = bla.IsChecked;

            var sourceImage = ((BitmapFrame)(bla.Content as Image).Source).ToString();
            // Here we call Regex.Match.
            Match match = Regex.Match(sourceImage, @"/Images/(.*)");
            var clickedImageSource = match.ToString();

            var bttn = myButtonList[0];

            setBtnImage(bttn, clickedImageSource);
            var stackpanel_name_from_button = (bttn.Parent as StackPanel).Name;

            oParentWindow.bttn1 = 0;
            oParentWindow.bttn1 = value;
            value = oParentWindow.bttn2 + oParentWindow.bttn1;
            Console.WriteLine(" Bttn1: " + oParentWindow.bttn1);
            saveValuesBabToDec(stackpanel_name_from_button, value);
            counterHigh += 1;

            if((bool)isToggleCheckedHigh && counterHigh > 1) {
                bla.IsChecked = false;
                
                counterHigh = 1;
                return;
            }
            setPreview(single_imageContainer_left, clickedImageSource);
            oConverter.selectedSpalteBaby = value;
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e) {
            if(counterLow == 1) {
                counterLow -= 1;
                resetPreview(single_imageContainer_right);
            }
        }

        private void HandleUncheckedHigh(object sender, RoutedEventArgs e) {
            if(counterHigh == 1) {
                counterHigh -= 1;
                resetPreview(single_imageContainer_left);
            }
        }

        private void setPreview(Image image, string source) {

            image.Source = new BitmapImage(new Uri(@"" + source, UriKind.Relative));
        }
        private void resetPreview(Image image) {
            image.Source = null;
        }

        private void setBtnImage(Button btn, string source) {
            (btn.Content as Image).Source = new BitmapImage(new Uri(@"" + source, UriKind.Relative));
        }

    }
}
