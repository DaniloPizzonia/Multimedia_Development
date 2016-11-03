using System;
using System.Collections.Generic;
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

namespace DataGenerator {
    /// <summary>
    /// Interaction logic for Window_ShowData.xaml
    /// </summary>
    public partial class Window_ShowData:Window {
        string sPath = Directory.GetCurrentDirectory() + @"\Generierte_Daten\";
        public Window_ShowData() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            var oFiles = Directory.GetFiles(sPath);
            oListBox_Files.ItemsSource = oFiles;
        }
    }
}
