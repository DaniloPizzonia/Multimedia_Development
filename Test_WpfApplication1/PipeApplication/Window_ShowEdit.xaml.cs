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
using System.Windows.Shapes;

namespace PipeApplication {
    /// <summary>
    /// Interaction logic for Window_ShowEdit.xaml
    /// </summary>
    public partial class Window_ShowEdit:Window {
        User oUser;
        Pipe oPipe;
        MainWindow oParentWindow;
        int iClickedIndex;
        public Window_ShowEdit(User oUserCommit, int iIndexCommit, MainWindow oParentWindowCommit) {
            // initiilize variables for using 
            oUser = oUserCommit; iClickedIndex = iIndexCommit; oParentWindow = oParentWindowCommit;
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            

        }

        private void Window_Closed(object sender, EventArgs e) {
            this.Owner.Visibility = Visibility.Visible;
        }

        private void oButton_SavePipe_Click(object sender, RoutedEventArgs e) {
            // strings for messageBox
            string sMassage = "Wollen Sie die Pfeife wirklich speichern?", sCaption="Speichern";
            MessageBoxResult eResult = MessageBox.Show(sMassage, sCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(eResult == MessageBoxResult.Yes) {
                oPipe = new Pipe();
                oPipe.Name = oTextBox_PipeName.Text;
                oPipe.PipeMaker = oTextBox_PipeMaker.Text;
                oPipe.ReservedForFlavor = oTextBox_Tabakrichtung.Text;
                oPipe.Description = oTextBox_Description.Text;
                oPipe.Pieces = Convert.ToInt32(oSlider_PipeAmount.Value);
                oUser.lPipes.Add(oPipe);
                oParentWindow.iniPipesBinding();
                int iIndex = oUser.lPipes.Count - 1;
                oParentWindow.oListBox_Pipes.SelectedIndex = iIndex;
                this.Owner.Visibility = Visibility.Visible;
                this.Close();
            }
        }
    }
}
