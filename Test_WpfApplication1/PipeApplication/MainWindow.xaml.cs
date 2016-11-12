﻿using System;
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
        string sPathUserData = Directory.GetCurrentDirectory() + @"\UserData\";
        string sPathImages = Directory.GetCurrentDirectory() + @"\Images\";
        bool bEditAddMode;
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if(oUser == null) {
                if(Save.readXML<User>(sPathUserData + "user.xml") == null) {
                    oUser = new User("Default Name", 0, 0);
                } else {
                    oUser = Save.readXML<User>(sPathUserData + "user.xml");
                }
            }
            oTextBlock_Pipe.Text = "Pipes " + oUser.PipesCounter;
            oTextBlock_Tobacco.Text = "Tobacco " + oUser.TobaccoCounter;

            iniPipesBinding();
            iniTobaccoBinding();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            noItemsExist();
            Save.saveXML<User>(oUser, sPathUserData + "user.xml");
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
            oListBox_Pipes.SelectedIndex = 0;
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
            var qResult = (from p in oUser.lTobaccos
            where p.Name.StartsWith(oTextBox_FilterBarTobacco.Text, StringComparison.InvariantCultureIgnoreCase)
                      select p).ToList();
            qResult = (from p in qResult orderby p.Name select p).ToList();

            var qContainsResult = (from p in oUser.lTobaccos where p.Name.ToUpper().Contains(oTextBox_FilterBarTobacco.Text.ToUpper()) select p).ToList();
            qResult.AddRange(qContainsResult);
            oListBox_Tobacco.ItemsSource = null;                // reset the ListBox entries
            oListBox_Tobacco.ItemsSource = qResult.Distinct();  // set the filter query results on the listbox
        }

        /// <summary>
        /// Filter for Tobaccos - create filter query an sets to the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oTextBox_FilterBarPipes_TextChanged(object sender, TextChangedEventArgs e) {
            var qResult = (from p in oUser.lPipes
                           where p.Name.StartsWith(oTextBox_FilterBarPipes.Text, StringComparison.InvariantCultureIgnoreCase)
                           select p).ToList();
            qResult = (from p in qResult orderby p.Name select p).ToList();

            var qContainsResult = (from p in oUser.lPipes where p.Name.ToUpper().Contains(oTextBox_FilterBarPipes.Text.ToUpper()) select p).ToList();
            qResult.AddRange(qContainsResult);
            oListBox_Pipes.ItemsSource = null;               // resets the ListBox entries
            oListBox_Pipes.ItemsSource = qResult.Distinct(); // set the filter query results on the listbox
        }

        /// <summary>
        /// Add a new Pipe entry to the pipe list box 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Pipe_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult oResult = MessageBox.Show("Eine neue Pfeife wird angelegt, wenn Sie auf ok klicken", "Pfeife anlegen", MessageBoxButton.YesNo, MessageBoxImage.Question);
            var iClickedIndex = oListBox_Pipes.SelectedIndex;
            
            if(oResult == MessageBoxResult.Yes) {
                bEditAddMode = false;
                var oWindow = new Window_ShowEdit(oUser, iClickedIndex, this, bEditAddMode);
                    oWindow.Owner = this;
                this.Visibility = Visibility.Hidden;
                oWindow.ShowDialog();
            }
        }

        private void oListBox_Pipes_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            BitmapImage oImage = new BitmapImage();
            var oPipeSelected = oListBox_Pipes.SelectedItem as Pipe;
            
            try {
                var uriPipe = oPipeSelected.profileUri;
                if(oPipeSelected != null) {
                    if(uriPipe == "") {
                        uriPipe = sPathImages + "profilePic.jpg";
                    }
                    using(FileStream oStream = File.OpenRead(uriPipe)) {
                        oImage.BeginInit();
                        oImage.StreamSource = oStream;
                        oImage.CacheOption = BitmapCacheOption.OnLoad;
                        oImage.EndInit();
                    }
                }
            } catch(Exception ex) {
                //MessageBox.Show(ex.Message, "Error");
                return;
            }
            oImage_PipePicture.Source = oImage;
        }

        private void Delete_Pipe_Click(object sender, RoutedEventArgs e) {
            bEditAddMode = !bEditAddMode;
            var oPipeSelected = oListBox_Pipes.SelectedItem as Pipe;
            oUser.lPipes.Remove(oPipeSelected);
            oListBox_Pipes.ItemsSource = null;
            oListBox_Pipes.ItemsSource = oUser.lPipes;
            oListBox_Pipes.SelectedIndex = oUser.lPipes.Count - 1;
        }

        private void oButton_EditPipe_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult oResult = MessageBox.Show("Wollen Sie diese Pfeife bearbeiten?", "Pfeife bearbeiten", MessageBoxButton.YesNo, MessageBoxImage.Question);
            var iClickedIndex = oListBox_Pipes.SelectedIndex;

            if(oResult == MessageBoxResult.Yes) {
                bEditAddMode = true;
                var oWindow = new Window_ShowEdit(oUser, iClickedIndex, this, bEditAddMode);
                oWindow.Owner = this;
                this.Visibility = Visibility.Hidden;
                oWindow.ShowDialog();
            }
        }

        private void oListBox_Tobacco_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            BitmapImage oImage = new BitmapImage();
            var oTobaccoSelected = oListBox_Tobacco.SelectedItem as Tobacco;

            try {
                var uriTobacco = oTobaccoSelected.profileUri;
                if(oTobaccoSelected != null) {
                    if(uriTobacco == "" || uriTobacco == null) {
                        uriTobacco = sPathImages + "profilePic.jpg";
                    }
                    using(FileStream oStream = File.OpenRead(uriTobacco)) {
                        oImage.BeginInit();
                        oImage.StreamSource = oStream;
                        oImage.CacheOption = BitmapCacheOption.OnLoad;
                        oImage.EndInit();
                    }
                }
            } catch(Exception ex) {
                //MessageBox.Show(ex.Message, "Error");
                return;
            }
            oImage_TobaccoPicture.Source = oImage;
        }

        private void Add_Tobacco_Click(object sender, RoutedEventArgs e) {

        }

        private void Delete_Tobacco_Click(object sender, RoutedEventArgs e) {

        }

        private void oButton_EditTobacco_Click(object sender, RoutedEventArgs e) {

        }
    }
}
