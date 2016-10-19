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

namespace FirstTryApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void oButton_CreateProject_Click(object sender, RoutedEventArgs e)
        {
            var oInputField = oTextBox_ProjectName;
            var sInputText = oInputField.Text;
            var sMsgBoxString = "Returned this value: ";

            try
            {
                int iQuersumme = 0;
                for (int i = 0; i < sInputText.Length; i++){
                    iQuersumme += sInputText[i] - 48; // Convert.ToInt32(sInputText[i].ToString());
                }
                int iValue = Convert.ToInt32(sInputText);
                // MessageBox.Show(sMsgBoxString + iValue);
                MessageBox.Show("Die Quersumme aller eingegeben Zahlen ist: " + iQuersumme); 
            }
            catch (Exception){
                MessageBox.Show("Die Eingabe " + sInputText + " ist falsch!",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Error, error.ToString);
    
            }
            
        }

        private void oTextBox_ProjectName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
