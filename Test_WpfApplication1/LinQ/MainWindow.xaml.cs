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

namespace LinQ {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            var lListeA = new List<int> { 0,2,2,4,5,6,7,8,9};
            var lListB = new List<int> {1,3,5,7,8 };
            var qResult = (from a in lListeA
                           from b in lListB
                           where a.CompareTo(b) < 0
                           select new { a, b }).Distinct();
            oListBox_Vergleiche.ItemsSource = qResult; 
        }
    }
}
