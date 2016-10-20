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

namespace EinHandler {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void oElipse_MouseUp(object sender, MouseButtonEventArgs e) {
            Ellipse oEllipse = sender as Ellipse;

            var sEllipseName = oEllipse.Name;
            var Color = sEllipseName.Substring(8);
            
            if (oEllipse.Stroke == oEllipse.Fill) {
                oEllipse.Stroke = Brushes.Black;
            } else{
                oEllipse.Stroke = oEllipse.Fill;
            }
            //MessageBox.Show(Color);
        }

        private void oTextBox_Ellipse_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter){
                var sText = "oElipse_" +  oTextBox_Ellipse.Text;

                Ellipse oEllipse = oGrid_Layout.FindName(sText) as Ellipse;

                if (oEllipse != null) {
                    oEllipse.Stroke = oEllipse.Fill;
                }
                //MessageBox.Show(sText);
            }
        }
    }
}
