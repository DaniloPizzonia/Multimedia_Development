using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ChickenRun {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public static Game _gameData;

        private void Application_Startup(object sender, StartupEventArgs e) {
            _gameData = Save.readDataFile<Game>("GameData.txt");
            if(_gameData == null){
                _gameData = new Game();
            }
        }
    }
}
