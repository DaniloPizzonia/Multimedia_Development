using MasterConverter;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Shapes;

namespace MasterConverter {
    /// <summary>
    /// Interaction logic for Window_ShowEdit.xaml
    /// </summary>
    public partial class Window_ShowSelection : Window {

        MainWindow oParentWindow;

        public Window_ShowSelection() {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }

        private void Window_Closed(object sender, EventArgs e) {
            this.Owner.Visibility = Visibility.Visible;
        }

        private void oButton_SavePipe_Click(object sender, RoutedEventArgs e) {
            this.Owner.Visibility = Visibility.Visible;
            this.Close();
        }

        private void HandleCheck(object sender, RoutedEventArgs e) {
            //text2.Text = "Button is Checked";
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e) {
            //text2.Text = "Button is unchecked.";
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            // this.MyImageSource = new BitmapImage(new Uri(@"/Images/left/l_1.png", UriKind.Relative)); //you change source of the Image
        }
    }
}
