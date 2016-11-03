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

namespace DataGenerator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window {
        List<string> lFirstName_w, lFirstName_m, lFamilyName;
        List<Person> lPersons;
        int iObjects, iPercFemale;
        string sFileName;
        Random rnd = new Random();
        string sPath = Directory.GetCurrentDirectory() + @"\Generierte_Daten\";
        
        public MainWindow() {
            InitializeComponent();
            lFirstName_w = Save.readXML<List<string>>("FirstName_m.xml");
            lFirstName_m = Save.readXML<List<string>>("FirstName_w.xml");
            lFamilyName = Save.readXML<List<string>>("FamName.xml");
        }
        private void oButton_GenerateData_Click(object sender, RoutedEventArgs e) {
            string sMsg = "";
            try {
                sMsg = "Anzahl der Objekte ist fehlerhaft(format)";
                iObjects = Convert.ToInt32(oTextBox_Objects.Text);
                sMsg = "Prozent Weiblich ist fehlerhaft(muss Ganzzahl sein!)";
                iPercFemale = Convert.ToInt32(oTextBox_Female.Text);
            } catch(Exception) {
                MessageBox.Show(sMsg, "FATAL ERROR");
            }
            if(oTextBox_Filename.Text == "") {
                MessageBox.Show("Bitte Dateinamen eingeben!", "HINWEIS");
                return;
            }
            if(iObjects > 0 && sMsg != null) {
                generateData(iObjects);
            }
        }

        private void oButton_ShowData_Click(object sender, RoutedEventArgs e) {
            var oWindows = new Window_ShowData();
            oWindows.Show();
        }

        private void generateData(int iObjects) {
            int iFemaleCount = (iObjects * iPercFemale) / 100;
            lPersons = new List<Person>();
            var oPerson = new Person();
            lPersons.Add(oPerson);

            for(int i = 0; i < iObjects; i++) {
                oPerson.LastName = lFamilyName[rnd.Next(lFamilyName.Count)];
                lPersons.Add(oPerson);
                if(iFemaleCount > 0) {
                    iFemaleCount--;
                    oPerson.Female = true;
                    oPerson.FirstName = lFirstName_w[rnd.Next(lFirstName_w.Count)];
                } else {
                    oPerson.Female = false;
                    oPerson.FirstName = lFirstName_m[rnd.Next(lFirstName_m.Count)];
                }
                oPerson.Birthday = new DateTime(rnd.Next(DateTime.Today.Year - 99, DateTime.Today.Year - 16), rnd.Next(1, 13), rnd.Next(1, 18));
            }
            sFileName = sPath + oTextBox_Filename.Text + ".xml";
            Save.saveXML<List<Person>>(lPersons, sFileName);
        }
    }
}
