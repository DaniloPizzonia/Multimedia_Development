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

namespace PipeApplication {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window {
        List<Pipe> lPipes = new List<Pipe>();
        List<User> lUser = new List<User>();

        User oUser;
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            oUser = new User("Danilo", 45, 120);
            oTextBlock_Pipe.Text ="Pipes " + oUser.PipesCounter;
            oTextBlock_Tobacco.Text = "Tobacco " + oUser.TobaccoCounter;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Save.saveObject<List<User>>(lUser, "storage.dat");
        }
    }
}
