using Microsoft.Win32;
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
        private Employee oEmployee;
        public MainWindow(){
            InitializeComponent();
            oEmployee = new Employee { FirstName = "Danilo", LastName = "Pizzonia", Title = "" };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            oGridData.DataContext = oEmployee;
        }

        private void oButtonUploadImage_Click(object sender, RoutedEventArgs e){
            OpenFileDialog oFileDialog = new OpenFileDialog();
            oFileDialog.Title = "Select a picture";
            oFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            try{
                if (oFileDialog.ShowDialog() == true){
                    oImageProfile.Source = new BitmapImage(new Uri(oFileDialog.FileName));
                }
            } catch(Exception ex){
                MessageBox.Show("An exception has catched up: " + ex.Message,
                    "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void oButtonSave_Click(object sender, RoutedEventArgs e) {
            oEmployee.LastName = oTextBoxNachname.Text;
            oEmployee.FirstName = oTextBoxVorname.Text;
            oEmployee.Title = oComboBoxAnrede.Text;
            
            MessageBox.Show("Eroflgreich gespeichert! " + oEmployee.Title + " " + oEmployee.FirstName + " " + oEmployee.LastName);
        }

        private void oButtonCancel_Click(object sender, RoutedEventArgs e) {
            oEmployee.Title = "";
            oTextBoxNachname.Text = oEmployee.LastName = "";
            oTextBoxVorname.Text = oEmployee.FirstName = "";
            
            MessageBox.Show("Einagben erfolgreich verworfen!");
        }

    }
}
