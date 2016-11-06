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
        List<Pipe> lPipes = new List<Pipe>();
        List<User> lUser = new List<User>();
        string sPath = Directory.GetCurrentDirectory() + @"\UserData\";
        
        User oUser;
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            if(oUser == null) {
                oUser = Save.readXML<User>(sPath + "user.xml");
            } else {
                // when no file exists
                oUser = new User("Default Name", 0, 0);
            }
            oTextBlock_Pipe.Text = "Pipes " + oUser.PipesCounter;
            oTextBlock_Tobacco.Text = "Tobacco " + oUser.TobaccoCounter;
            oListBox_Pipes.ItemsSource = null;
            oListBox_Pipes.ItemsSource = oUser.lPipes;
            oStackPanel_Details.DataContext = oUser;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Pipe oDefaultPipe = new Pipe();
            if(oUser.lPipes.Count == 0) {
                oUser.lPipes.Add(oDefaultPipe);
            }
            
            Save.saveXML<User>(oUser, sPath + "user.xml");
        }
    }
}
