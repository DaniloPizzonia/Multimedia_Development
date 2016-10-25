using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChickenRun {
    [Serializable]
    class Chicken {
        public Chicken() { }
        public Chicken(int chickenNumber, Image oUiImage) {
            getImageChicken = oUiImage;
            getName = chickenName[chickenNumber];
        }

        public string getName { get; set; }        
        public int getNumberRuns { get; set; }
        public int getNumberWins { get; set; }
        [NonSerialized]
        public bool imageChanged;
        [NonSerialized]
        public Image getImageChicken;

        [NonSerialized]
        List<string> chickenName = new List<string>() {
            "Chicki", "Lulu"
        };

    }
}
