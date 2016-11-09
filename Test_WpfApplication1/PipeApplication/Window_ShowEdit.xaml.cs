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
using System.Windows.Shapes;

namespace PipeApplication {
    /// <summary>
    /// Interaction logic for Window_ShowEdit.xaml
    /// </summary>
    public partial class Window_ShowEdit:Window {
        User oUser;
        Pipe oPipe;
        MainWindow oParentWindow;
        string sPathImages = Directory.GetCurrentDirectory() + @"\Images\";
        int iClickedIndex;
        public Window_ShowEdit(User oUserCommit, int iIndexCommit, MainWindow oParentWindowCommit) {
            // initiilize variables for using 
            oUser = oUserCommit; iClickedIndex = iIndexCommit; oParentWindow = oParentWindowCommit;
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            oPipe = new Pipe();
        }

        private void Window_Closed(object sender, EventArgs e) {
            this.Owner.Visibility = Visibility.Visible;
        }

        
        private void oButton_SavePipe_Click(object sender, RoutedEventArgs e) {
            // strings for messageBox
            string sMassage = "Wollen Sie die Pfeife wirklich speichern?", sCaption="Speichern";
            MessageBoxResult eResult = MessageBox.Show(sMassage, sCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(eResult == MessageBoxResult.Yes) {
                oPipe.Name = oTextBox_PipeName.Text;
                oPipe.PipeMaker = oTextBox_PipeMaker.Text;
                oPipe.ReservedForFlavor = oTextBox_Tabakrichtung.Text;
                oPipe.Description = oTextBox_Description.Text;
                oPipe.Pieces = Convert.ToInt32(oSlider_PipeAmount.Value);
                try {
                    oPipe.Price = Convert.ToDouble(oTextBox_Price.Text);
                } catch(Exception ex) {
                    MessageBox.Show("Bitte eine numerische Zahl eingeben", "Preis Fehler!!!");
                    return;
                }
                oPipe.PurchaseDate = oDatePicker_PurchaseDate.SelectedDate;
                oPipe.State = oComboBox_State.SelectionBoxItem.ToString();
                oUser.lPipes.Add(oPipe);
                oParentWindow.iniPipesBinding();
                int iIndex = oUser.lPipes.Count - 1;
                oParentWindow.oListBox_Pipes.SelectedIndex = iIndex;
                this.Owner.Visibility = Visibility.Visible;
                this.Close();
            }
        }

        private void oButton_AddImage_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog oFileDialog = new OpenFileDialog();
            oFileDialog.Title = "Select a picture";
            oFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            try {
                if(oFileDialog.ShowDialog() == true) {
                    string sFileName = oFileDialog.FileName;
                    oPipe.profileUri = sFileName;               // saves the filename in pipe to search for the right pic in relative folder

                    if(!Directory.Exists(sPathImages)) {        // proofs if a directory exists 
                        Directory.CreateDirectory(sPathImages); // if dir does not excist with the pre defined path create one
                    }
                    string sFilePath = sPathImages + System.IO.Path.GetFileName(sFileName); // Filepath for copy procedure
                    File.Copy(sFileName, sFilePath, true);                                  // copy the image to the right directory

                    Uri uriFile = new Uri(sFileName);                           // create a uriPath by the image path
                    sFileName = System.IO.Path.GetFileName(sFileName);          // filter the raw name of the image
                    string sRelativeImageFilePath = sPathImages + sFileName;    // concat the relative dir wth the image name
                    Uri uriRelative = new Uri(uriFile, sRelativeImageFilePath); // create a relative uri path for BitmapImage
                    oImage_PipePicture.Source = new BitmapImage(uriRelative);   // commit the relative uri(BitmapImage) path to the image source
                }
            } catch(Exception ex) {
                MessageBox.Show("An exception has catched up: " + ex.Message,
                    "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
