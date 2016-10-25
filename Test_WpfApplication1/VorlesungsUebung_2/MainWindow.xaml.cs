using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VorlesungsUebung_2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        List<Employee> lKontakte = new List<Employee>();
        public MainWindow(){
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Save oSave = new Save();
            oSave.saveObject(lKontakte, "test.txt");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Save oSave = new Save();
            lKontakte = oSave.readDataFile<List<Employee>>("test.txt");
            oListBox_Kontakte.ItemsSource = lKontakte;
        }

        private void initListBox() {
            oListBox_Kontakte.ItemsSource = null;
            oListBox_Kontakte.ItemsSource = lKontakte;
        }

        private void Add_Click(object sender, RoutedEventArgs e) {
            if(lKontakte != null) {
                addDummy();
            } else {
                lKontakte = new List<Employee>();
                addDummy();
            }
            
            initListBox();
        }

        private void Del_Click(object sender, RoutedEventArgs e) {
            var oSelectedItem = oListBox_Kontakte.SelectedItem;
            if (oSelectedItem == null) {
                MessageBox.Show("Bitte erst ein Kontakt selektieren!");
            }
            lKontakte.Remove(oSelectedItem as Employee);
            initListBox();
        }

        private void oButton_AddImage_Click(object sender, RoutedEventArgs e) {
            var oKontakte = oListBox_Kontakte.SelectedItem as Employee;
            OpenFileDialog oFileDialog = new OpenFileDialog();
            oFileDialog.Title = "Select a picture";
            oFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            try {
                if (oFileDialog.ShowDialog() == true) {
                    var sFileName = oFileDialog.FileName;
                    var oProfileUri = new Uri(sFileName, UriKind.RelativeOrAbsolute);
                    oKontakte.profileUri = sFileName;
                    oImage_ProfilPicture.Source = new BitmapImage(oProfileUri);
                }
            }
            catch (Exception ex) {
                oKontakte.profileUri = "profilePic.jpg";
                MessageBox.Show("An exception has catched up: " + ex.Message,
                    "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void addDummy() {
            lKontakte.Add(new Employee { firstName = "Bitte Eintragen", lastName = "", title = "", profileUri = "" });
        }

        private void oListBox_Kontakte_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            BitmapImage oImage = new BitmapImage();
            var oKontakte = oListBox_Kontakte.SelectedItem as Employee;
            try {
                if (oKontakte != null) {
                    if (oKontakte.profileUri == "") {
                        oKontakte.profileUri = "Images/profilePic.jpg";
                    }
                    using (FileStream oStream = File.OpenRead(oKontakte.profileUri)) {
                        oImage.BeginInit();
                        oImage.StreamSource = oStream;
                        oImage.CacheOption = BitmapCacheOption.OnLoad;
                        oImage.EndInit();
                    }
                }
                
            } catch(Exception ex) {
               
                MessageBox.Show(ex.Message, "Error Report");
            }
            oImage_ProfilPicture.Source = oImage;
        }

    }

}
