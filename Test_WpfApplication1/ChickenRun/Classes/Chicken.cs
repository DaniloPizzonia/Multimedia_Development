using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChickenRun {
    [Serializable]
    public class Chicken {
        public Chicken() { }
        public Chicken(string sName) {
            getName = sName;
        }

        public string getName { get; set; }        
        public int getNumberRuns { get; set; }
        public int getNumberWins { get; set; }
        [NonSerialized]
        public bool imageChanged;
        [NonSerialized]
        public Image getImageChicken;
    }
}
