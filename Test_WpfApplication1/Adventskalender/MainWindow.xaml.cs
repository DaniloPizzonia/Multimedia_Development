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

namespace Adventskalender {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window {
        public MainWindow() {
            InitializeComponent();
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
                    oItemEl.Fill = new SolidColorBrush(Color.FromArgb((byte)rnd.Next(256),
                                                                      (byte)rnd.Next(256),
                                                                      (byte)rnd.Next(256),
                                                                      (byte)rnd.Next(256)));
                }
            }
        }

        private void oEllipse_Door_MouseUp(object sender, MouseButtonEventArgs e) {
            oGrid_ScreenGoodies.Visibility = Visibility.Visible;
        }

        private void oButton_Collapse_Click(object sender, RoutedEventArgs e) {
            oGrid_ScreenGoodies.Visibility = Visibility.Collapsed;
        }
    }
}
