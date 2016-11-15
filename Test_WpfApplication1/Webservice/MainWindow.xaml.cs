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
using Webservice.ServiceReference1;

namespace Webservice {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window {
        BLZServicePortTypeClient oWebService = new BLZServicePortTypeClient("BLZServiceSOAP11port_http");
        public MainWindow() {
            InitializeComponent();
        }

        private async void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var oResult = await oWebService.getBankAsync((sender as ComboBox).SelectedItem.ToString());
            oStackpanel_Webservices.DataContext = oResult;
        }
    }
}
