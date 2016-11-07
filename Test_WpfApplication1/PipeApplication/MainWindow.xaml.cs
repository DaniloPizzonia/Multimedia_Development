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

            Pipe oDefaultPipe = new Pipe();
            if(oUser.lPipes.Count == 0) {
                oUser.lPipes.Add(oDefaultPipe);
            }
            Tobacco oDefaultTobacco = new Tobacco();
            if(oUser.lTobaccos.Count == 0) {
                oUser.lTobaccos.Add(oDefaultTobacco);
            }
            
            Save.saveXML<User>(oUser, sPath + "user.xml");
        }
        /// <summary>
        /// is used for binding the Pipes in the Listbox 
        /// </summary>
        private void iniPipesBinding() {
            oListBox_Pipes.ItemsSource = null;
            oListBox_Pipes.ItemsSource = oUser.lPipes;
            oStackPanel_Details.DataContext = oUser;
        }
        /// <summary>
        /// is used for binding the Tobaccos in the Listbox 
        /// </summary>
        private void iniTobaccoBinding() {
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
            var erg = from p in oUser.lPipes
            where p.Name.StartsWith(oTextBox_FilterBarTobacco.Text, StringComparison.InvariantCultureIgnoreCase)
                      select p;
            oListBox_Tobacco.ItemsSource = null;
            oListBox_Tobacco.ItemsSource = erg;
        }

        /// <summary>
        /// Filter for Tobaccos - create filter query an sets to the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oTextBox_FilterBarPipes_TextChanged(object sender, TextChangedEventArgs e) {
            var erg = from p in oUser.lPipes
                      where p.Name.StartsWith(oTextBox_FilterBarPipes.Text, StringComparison.InvariantCultureIgnoreCase)
                      select p;
            oListBox_Pipes.ItemsSource = null;
            oListBox_Pipes.ItemsSource = erg;
        }
    }
}
