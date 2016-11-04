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
        GenData oData;
        public Window_ShowData() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            var oFiles = Directory.GetFiles(sPath);
            oListBox_Files.ItemsSource = oFiles;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            this.Owner.Visibility = Visibility.Visible;
        }

        private void oListBox_Files_SelectionChanged(object sender, SelectionChangedEventArgs e) {
           string sFilePath =  ((sender as ListBox).SelectedItem.ToString());
            oData = Save.readXML<GenData>(sFilePath);
            oListBox_Persons.ItemsSource = oData.lPersons;
            oStackPanel_Details.DataContext = oData;
        }

        private void oListBox_Persons_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void oTextBox_Filter_TextChanged(object sender, TextChangedEventArgs e) {
            var erg = from p in oData.lPersons
                      where p.LastName.StartsWith(oTextBox_Filter.Text, StringComparison.InvariantCultureIgnoreCase)
                      select p;
            oListBox_Persons.ItemsSource = null;
            oListBox_Persons.ItemsSource = erg;
        }
    }
}
