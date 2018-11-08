﻿using MasterConverter.Classes;
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
            //Converter myConverter = new Converter();
            var return2 = this.myConverter.modHigh(6661);
            

            swapImages(myConverter.linkeSpalteBaby, left_imageContainer_left, left_imageContainer_right);
            swapImages(myConverter.mittlereSpalteBaby, middle_imageContainer_left, middle_imageContainer_right);
            swapImages(myConverter.rechteSpalteDecBaby, right_imageContainer_left, right_imageContainer_right);
            System.Windows.MessageBox.Show(return2);
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
                    //left_imageContainer_left.Source = null;
                    //middle_imageContainer_left.Source = null;
                    break;
                case 1:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/left/l_1.png", UriKind.Relative));
                    //left_imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_1.png", UriKind.Relative));
                    //middle_imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_1.png", UriKind.Relative));
                    break;
                case 2:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/left/l_2.png", UriKind.Relative));
                    //left_imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_2.png", UriKind.Relative));
                    //middle_imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_2.png", UriKind.Relative));
                    break;
                case 3:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/left/l_3.png", UriKind.Relative));
                    //left_imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_3.png", UriKind.Relative));
                    //middle_imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_3.png", UriKind.Relative));
                    break;
                case 4:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/left/l_4.png", UriKind.Relative));
                    //left_imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_4.png", UriKind.Relative));
                    //middle_imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_4.png", UriKind.Relative));
                    break;
                case 5:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/left/l_5.png", UriKind.Relative));
                    //left_imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_5.png", UriKind.Relative));
                    //middle_imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/left/l_5.png", UriKind.Relative));
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
                    // left_imageContainer_right.Source = null;
                    //middle_imageContainer_right.Source = null;
                    break;
                case 1:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_1.png", UriKind.Relative));
                    //left_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_1.png", UriKind.Relative));
                    //middle_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_1.png", UriKind.Relative));
                    break;
                case 2:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_2.png", UriKind.Relative));
                    // left_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_2.png", UriKind.Relative));
                    // middle_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_2.png", UriKind.Relative));
                    break;
                case 3:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_3.png", UriKind.Relative));
                    // left_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_3.png", UriKind.Relative));
                    //middle_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_3.png", UriKind.Relative));
                    break;
                case 4:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_4.png", UriKind.Relative));
                    // left_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_4.png", UriKind.Relative));
                    //middle_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_4.png", UriKind.Relative));
                    break;
                case 5:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_5.png", UriKind.Relative));
                    // left_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_5.png", UriKind.Relative));
                    //middle_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_5.png", UriKind.Relative));
                    break;
                case 6:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_6.png", UriKind.Relative));
                    //left_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_6.png", UriKind.Relative));
                    //middle_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_6.png", UriKind.Relative));
                    break;
                case 7:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_7.png", UriKind.Relative));
                    // left_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_7.png", UriKind.Relative));
                    // middle_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_7.png", UriKind.Relative));
                    break;
                case 8:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_8.png", UriKind.Relative));
                    //left_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_8.png", UriKind.Relative));
                    //middle_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_8.png", UriKind.Relative));
                    break;
                case 9:
                    imageContainer.Source = new BitmapImage(new Uri(@"/Images/right/r_9.png", UriKind.Relative));
                    // left_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_9.png", UriKind.Relative));
                    // middle_imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/right/r_9.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }

    }
}
