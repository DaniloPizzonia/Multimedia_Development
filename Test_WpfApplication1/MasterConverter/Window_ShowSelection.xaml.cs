using MasterConverter;
using MasterConverter.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MasterConverter {
    /// <summary>
    /// Interaction logic for Window_ShowEdit.xaml
    /// </summary>
    public partial class Window_ShowSelection : Window {

        MainWindow oParentWindow;
        Converter oConverter;
        bool? isToggleCheckedLow;
        int counterLow;

        bool? isToggleCheckedHigh;
        int counterHigh;

        public Window_ShowSelection(MainWindow oParentWindowCommit, Converter myConverter) {
            // initiilize variables for using 
            oParentWindow = oParentWindowCommit;
            oConverter = myConverter;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }

        private void Window_Closed(object sender, EventArgs e) {
            this.Owner.Visibility = Visibility.Visible;
        }

        private void oButton_SavePipe_Click(object sender, RoutedEventArgs e) {
            this.Owner.Visibility = Visibility.Visible;
            this.Close();
        }

        private void HandleCheck(object sender, RoutedEventArgs e) {
            //text2.Text = "Button is Checked";
            ToggleButton bla = ((ToggleButton)sender);
            var value = Convert.ToInt32(Regex.Match(bla.Name, @"\d+").Value);
            isToggleCheckedLow = bla.IsChecked;

            counterLow += 1;

            if((bool)isToggleCheckedLow && counterLow > 1) {
                bla.IsChecked = false;
                counterLow = 1;
                return;
            }
            oConverter.selectedSpalteBaby = value;
            MessageBox.Show(value.ToString());
        }

        private void HandleCheckHigh(object sender, RoutedEventArgs e) {
            //text2.Text = "Button is Checked";
            ToggleButton bla = ((ToggleButton)sender);
            var value = Convert.ToInt32(Regex.Match(bla.Name, @"\d+").Value);
            isToggleCheckedHigh = bla.IsChecked;

            counterHigh += 1;

            if((bool)isToggleCheckedHigh && counterHigh > 1) {
                bla.IsChecked = false;
                counterHigh = 1;
                return;
            }
            oConverter.selectedSpalteBaby = value;
            MessageBox.Show(value.ToString());
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e) {
            //text2.Text = "Button is unchecked.";
            if(counterLow == 1) {
                counterLow -= 1;
            }
        }

        private void HandleUncheckedHigh(object sender, RoutedEventArgs e) {
            if(counterHigh == 1) {
                counterHigh -= 1;
            }
        }
    }
}
