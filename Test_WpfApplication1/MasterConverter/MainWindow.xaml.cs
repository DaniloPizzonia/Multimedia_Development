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
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            imageContainer_left.Source = new BitmapImage(new Uri(@"/Images/Pipe.jpg", UriKind.Relative));
            imageContainer_right.Source = new BitmapImage(new Uri(@"/Images/Pipe.jpg", UriKind.Relative));

            

            //fillRect(oRect_3, 0);
            //fillRect(oRect_3_Copy, 1);
        }

        private void oComboBox_i18n_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            _languageSettings = Properties.Settings.Default.sprache = oComboBox_i18n.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void oButto_restLanguage_Click(object sender, RoutedEventArgs e) {
            Process.Start(Application.ResourceAssembly.Location);
            App.Current.Shutdown();
        }

        private void leftImage() {

        }

        private void textBox_InputChanged(object sender, TextChangedEventArgs e) {
            string userInput = textBox_input.Text;
            int fetchedUserInput = 0;
            try {
                fetchedUserInput = Convert.ToInt32(userInput);
            } catch(Exception) {
                MessageBox.Show("pls enter a number");
                return;
            }           
            
            //MessageBox.Show(userInput);
            MessageBox.Show(fetchedUserInput.ToString());
            swapImages(fetchedUserInput);
        }

        private void swapImages(int input) {
            swapLeft();
            swapRight();
        }

        private void swapLeft() {
            // implement the logic for swaping image 1-5
        }

        private void swapRight() {
            // implement logic to swap image 1-9
        }

        private void oRect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            int iIndex = Convert.ToInt32((sender as Rectangle).Name[6]) - 48;
            oComboBox_i18n.SelectedIndex = iIndex;
        }
    }
}
