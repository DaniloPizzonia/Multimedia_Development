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
        Pipe oClickedPipe;
        MainWindow oParentWindow;

        bool bPipeEditAddMode; // editMode := true; addMode := false;
        string sPathImages = Directory.GetCurrentDirectory() + @"\Images\";
        int iClickedIndex;
        public Window_ShowEdit(User oUserCommit, int iIndexCommit, MainWindow oParentWindowCommit, bool bPipeMode) {
            // initiilize variables for using 
            oUser = oUserCommit; iClickedIndex = iIndexCommit; oParentWindow = oParentWindowCommit; bPipeEditAddMode = bPipeMode;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            oPipe = new Pipe();
            if(bPipeEditAddMode == true) {
                oClickedPipe = oUser.lPipes[iClickedIndex];
                oTextBox_PipeName.Text = oClickedPipe.Name;
                oTextBox_PipeMaker.Text = oClickedPipe.PipeMaker;
                oTextBox_Tabakrichtung.Text = oClickedPipe.ReservedForFlavor;
                oTextBox_Description.Text = oClickedPipe.Description;
                oSlider_PipeAmount.Value = oClickedPipe.Pieces;
                oTextBox_Price.Text = oClickedPipe.Price.ToString();
                oTextBlock_Rating_1.Text = oClickedPipe.UniCode1;
                oTextBlock_Rating_2.Text = oClickedPipe.UniCode2;
                oTextBlock_Rating_3.Text = oClickedPipe.UniCode3;
                oTextBlock_Rating_4.Text = oClickedPipe.UniCode4;
                oTextBlock_Rating_5.Text = oClickedPipe.UniCode5;
                oTextBlock_Title.Text = "Pfeife Bearbeiten";
                BitmapImage oImage = new BitmapImage();
                try {
                    var uriPipe = oClickedPipe.profileUri;
                    if(uriPipe == "") {
                        try {
                            uriPipe = sPathImages + "profilePic.jpg";
                        } catch(Exception) {
                            uriPipe = "";
                        }
                    }
                    using(FileStream oStream = File.OpenRead(uriPipe)) {
                        oImage.BeginInit();
                        oImage.StreamSource = oStream;
                        oImage.CacheOption = BitmapCacheOption.OnLoad;
                        oImage.EndInit();
                    }
                } catch(Exception ex) {
                    MessageBox.Show(ex.Message, "Error");
                    //return;
                }
                oImage_PipePicture.Source = oImage;
            } else {
                oTextBlock_Rating_1.Text = "\u2606"; oTextBlock_Rating_2.Text = "\u2606"; oTextBlock_Rating_3.Text = "\u2606"; oTextBlock_Rating_4.Text = "\u2606"; oTextBlock_Rating_5.Text = "\u2606";
            }
        }

        private void Window_Closed(object sender, EventArgs e) {
            this.Owner.Visibility = Visibility.Visible;
        }
        
        private void oButton_SavePipe_Click(object sender, RoutedEventArgs e) {
            // strings for messageBox
            string sMassage = "Wollen Sie die Pfeife wirklich speichern?", sCaption="Speichern";
            MessageBoxResult eResult = MessageBox.Show(sMassage, sCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(bPipeEditAddMode == false) {
                oClickedPipe = oPipe;
            }
            if(eResult == MessageBoxResult.Yes) {
                if(oTextBox_PipeName.Text == "") {
                    MessageBox.Show("Bitte Name eingeben!");
                    return;
                } else {
                    oClickedPipe.Name = oTextBox_PipeName.Text;
                }
                
                oClickedPipe.PipeMaker = oTextBox_PipeMaker.Text;
                oClickedPipe.ReservedForFlavor = oTextBox_Tabakrichtung.Text;
                oClickedPipe.Description = oTextBox_Description.Text;
                oClickedPipe.Pieces = Convert.ToInt32(oSlider_PipeAmount.Value);
                try {
                    oClickedPipe.Price = Convert.ToDouble(oTextBox_Price.Text);
                } catch(Exception ex) {
                    MessageBox.Show("Bitte eine numerische Zahl eingeben", "Preis Fehler!!!");
                    return;
                }
                oClickedPipe.PurchaseDate = oDatePicker_PurchaseDate.SelectedDate;
                oClickedPipe.State = oComboBox_State.SelectionBoxItem.ToString();
                if(bPipeEditAddMode == true) {
                    oParentWindow.iniPipesBinding();
                    int iIndex = oUser.lPipes.Count - 1;
                    oParentWindow.oListBox_Pipes.SelectedIndex = iClickedIndex;
                    oParentWindow.iniDashboard();
                } else {
                    oUser.lPipes.Add(oClickedPipe);
                    oParentWindow.iniPipesBinding();
                    int iIndex = oUser.lPipes.Count - 1;
                    oParentWindow.oListBox_Pipes.SelectedIndex = iIndex;
                    oParentWindow.iniDashboard();
                }
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
                    if(bPipeEditAddMode == false) {
                        oPipe.profileUri = sFileName;           // saves the filename in pipe to search for the right pic in relative folder
                    } else {
                        oClickedPipe.profileUri = sFileName;    // -,,-
                    }
                    
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

        private void oTextBlock_Rating_MouseUp(object sender, MouseButtonEventArgs e) {
            var oTextBlock = (sender as TextBlock);
            string sStarName = oTextBlock.Name;
            int iStarIndex = 0;
            const int iMaxStars = 6;
            try {
                iStarIndex = Convert.ToInt32(sStarName.Substring(sStarName.LastIndexOf("_") + 1));
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
            if(bPipeEditAddMode == false) {
                oClickedPipe = oPipe;
            }

            oClickedPipe.Rating = iStarIndex;
            List<TextBlock> lRating = new List<TextBlock>();
            for(int i = 0; i < iStarIndex + 1; i++) {
                if(i!=0) {
                    var s = oStackPanel_Rating.FindName("oTextBlock_Rating_" + i);
                    lRating.Add(s as TextBlock);
                    switch(i) {
                        case 1:
                            oClickedPipe.UniCode1 = "\u2605";
                            break;
                        case 2:
                            oClickedPipe.UniCode2 = "\u2605";
                            break;
                        case 3:
                            oClickedPipe.UniCode3 = "\u2605";
                            break;
                        case 4:
                            oClickedPipe.UniCode4 = "\u2605";
                            break;
                        case 5:
                            oClickedPipe.UniCode5 = "\u2605";
                            break;
                        default:
                            break;
                    }
                }
            }
            List<TextBlock> lRatingBlank = new List<TextBlock>();
            for(int i = iStarIndex + 1; i < iMaxStars; i++) {
                var s = oStackPanel_Rating.FindName("oTextBlock_Rating_" + i);
                lRatingBlank.Add(s as TextBlock);
                switch(i) {
                    case 1:
                        oClickedPipe.UniCode1 = "\u2606";
                        break;
                    case 2:
                        oClickedPipe.UniCode2 = "\u2606";
                        break;
                    case 3:
                        oClickedPipe.UniCode3 = "\u2606";
                        break;
                    case 4:
                        oClickedPipe.UniCode4 = "\u2606";
                        break;
                    case 5:
                        oClickedPipe.UniCode5 = "\u2606";
                        break;
                    default:
                        break;
                }
            }

            foreach(var oStar in lRating) {
                oStar.Text = "\u2605";
            }
            foreach(var oStarBlank in lRatingBlank) {
                oStarBlank.Text = "\u2606";
            }
        }
    }
}
