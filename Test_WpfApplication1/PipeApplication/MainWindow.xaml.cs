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

namespace PipeApplication {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window {

        User oUser;
        string sPath = Directory.GetCurrentDirectory() + @"\UserData\";

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if(oUser == null) {
                if(Save.readXML<User>(sPath + "user.xml") == null) {
                    oUser = new User("Default Name", 0, 0);
                } else {
                    oUser = Save.readXML<User>(sPath + "user.xml");
                }
            }
            oTextBlock_Pipe.Text = "Pipes " + oUser.PipesCounter;
            oTextBlock_Tobacco.Text = "Tobacco " + oUser.TobaccoCounter;

            iniPipesBinding();
            iniTobaccoBinding();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            noItemsExist();
            Save.saveXML<User>(oUser, sPath + "user.xml");
        }

        /// <summary>
        /// When user has no items ins list an default item
        /// will be added on each List for testing
        /// </summary>
        private void noItemsExist() {
            if(oUser.lPipes.Count == 0) {
                Pipe oDefaultPipe = new Pipe();
                oUser.lPipes.Add(oDefaultPipe);
            }

            if(oUser.lTobaccos.Count == 0) {
                Tobacco oDefaultTobacco = new Tobacco();
                oUser.lTobaccos.Add(oDefaultTobacco);
            }
        }

        /// <summary>
        /// is used for binding the Pipes in the Listbox 
        /// </summary>
        public void iniPipesBinding() {
            oListBox_Pipes.ItemsSource = null;
            oListBox_Pipes.ItemsSource = oUser.lPipes;
            oStackPanel_Details.DataContext = oUser;
        }
        /// <summary>
        /// is used for binding the Tobaccos in the Listbox 
        /// </summary>
        public void iniTobaccoBinding() {
            oListBox_Tobacco.ItemsSource = null;
            oListBox_Tobacco.ItemsSource = oUser.lTobaccos;
            oStackPanel_DetailsTobacco.DataContext = oUser;
        }

        /// <summary>
        /// Filter for Tobaccos - create filter query an sets to the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oTextBox_FilterBarTobacco_TextChanged(object sender, TextChangedEventArgs e) {
            var qResult = from p in oUser.lPipes
            where p.Name.StartsWith(oTextBox_FilterBarTobacco.Text, StringComparison.InvariantCultureIgnoreCase)
                      select p;
            oListBox_Tobacco.ItemsSource = null;     // reset the ListBox entries
            oListBox_Tobacco.ItemsSource = qResult;  // set the filter query results on the listbox
        }

        /// <summary>
        /// Filter for Tobaccos - create filter query an sets to the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oTextBox_FilterBarPipes_TextChanged(object sender, TextChangedEventArgs e) {
            var qResult = from p in oUser.lPipes
                      where p.Name.StartsWith(oTextBox_FilterBarPipes.Text, StringComparison.InvariantCultureIgnoreCase)
                      select p;

            oListBox_Pipes.ItemsSource = null;    // resets the ListBox entries
            oListBox_Pipes.ItemsSource = qResult; // set the filter query results on the listbox
        }

        /// <summary>
        /// Add a new Pipe entry to the pipe list box 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Pipe_Click(object sender, RoutedEventArgs e) {
            
            MessageBoxResult oResult = MessageBox.Show("Eine neue Pfeife wird angelegt, wenn Sie auf ok klicken", "Pfeife anlegen", MessageBoxButton.YesNo, MessageBoxImage.Question);
            var iClickedIndex = oListBox_Pipes.SelectedIndex;

            // IDEA: open a new window to edit the pipe befor add to list
            if(oResult == MessageBoxResult.Yes) {
                var oWindow = new Window_ShowEdit(oUser, iClickedIndex, this);
                    oWindow.Owner = this;

                this.Visibility = Visibility.Hidden;
                oWindow.ShowDialog();
            }
        }
    }
}
