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

namespace Eingabeformular {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow(){
            InitializeComponent();
        }

        private void oButtonUploadImage_Click(object sender, RoutedEventArgs e){
            try {
                var sValue = this.addition(12, 13);
                MessageBox.Show("" + sValue);
            } catch(Exception error) {
                MessageBox.Show("Error has Occured: {0}",  error.ToString());
            }
           
        }
        private int addition(int a, int b) {
            return a + b;
        }
        
    }
}
