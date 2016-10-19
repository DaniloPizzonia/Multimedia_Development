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
            oEmployee = new Employee { FirstName = "Danilo", LastName = "Pizzonia", Title = "Herr" };
            this.DataContext = oEmployee;
        }

        private void oButtonUploadImage_Click(object sender, RoutedEventArgs e){
            var sFirstName = oTextBoxVorname.Text;
            try {
                Convert.ToInt32(sFirstName);
                MessageBox.Show("", sFirstName);
                
            } catch(Exception ex) {
                MessageBox.Show("An Exception has catched up: " + ex.Message,
                    "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }

        private void oButtonSave_Click(object sender, RoutedEventArgs e) {
            var sFirstName = oTextBoxVorname.Text;
            var sLastName = oTextBoxNachname.Text;
            var oComboBox = oComboBoxAnrede.Text;

            // use this variables to bind it into the oProfileName control

            MessageBox.Show("Eroflgreich gespeichert! " + sFirstName + " " + sLastName);
        }

        private void oButtonCancel_Click(object sender, RoutedEventArgs e) {

            MessageBox.Show("Einagben erfolgreich verworfen!");
        }
    }
}
