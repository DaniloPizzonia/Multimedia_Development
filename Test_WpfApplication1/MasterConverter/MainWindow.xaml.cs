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
            //oTextBox_Date.Text = DateTime.Now.ToShortDateString();

            fillRect(oRect_0, 0);
            fillRect(oRect_1, 1);
        }

        private void oComboBox_i18n_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            _languageSettings = Properties.Settings.Default.sprache = oComboBox_i18n.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void oButto_restLanguage_Click(object sender, RoutedEventArgs e) {
            Process.Start(Application.ResourceAssembly.Location);
            App.Current.Shutdown();
        }
        private void fillRect(Rectangle rec, int nr) {
            string sPathImages = Directory.GetCurrentDirectory() + @"\Images\";
            ImageBrush oImageBrush = new ImageBrush();
            //oImageBrush.ImageSource = new BitmapImage(new Uri(sPathImages + "/profilePic.jpg"));
            oImageBrush.Stretch = Stretch.UniformToFill;
            oImageBrush.Viewport = new Rect(0.0, 0.0, 1.0, 1.0);
            double iXPos, iYPos, iWidth, iHeigth;
            iXPos = nr * 0.166;
            iYPos = 0;
            iWidth = 0.166;
            iHeigth = 0.25;
            oImageBrush.Viewbox = new Rect(iXPos, iYPos,iWidth,iHeigth);
            rec.Fill = oImageBrush;
        }

        private void oRect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            int iIndex = Convert.ToInt32((sender as Rectangle).Name[6]) - 48;
            oComboBox_i18n.SelectedIndex = iIndex;
        }
    }
}
