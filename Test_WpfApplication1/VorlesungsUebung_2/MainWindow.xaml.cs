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

namespace VorlesungsUebung_2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private Employee oEmployee;
        List<Employee> lKontakte = new List<Employee>();
        public MainWindow(){
            InitializeComponent();
            oEmployee = new Employee { firstName = "Danilo", lastName = "Pizzonia", title = "" };
            lKontakte.Add(oEmployee);
            lKontakte.Add(new Employee { firstName = "Andi", lastName = "Skibärt", title = "" });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            //oGrid_Layout.DataContext = oEmployee;
            oListBox_Kontakte.ItemsSource = lKontakte;
        }

        private void Add_Click(object sender, RoutedEventArgs e) {
            lKontakte.Add(new Employee { firstName = "´Test", lastName = "Skibärt", title = "" });
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
        private void initListBox() {
            oListBox_Kontakte.ItemsSource = null;
            oListBox_Kontakte.ItemsSource = lKontakte;
        }
    }
}
