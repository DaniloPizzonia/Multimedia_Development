using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenRun {
    [Serializable]
    public class Player {
        public string getSetName { get; set; }
        public double getSetMoneyAmount { get; set; }
        public int getSetWins { get; set; }
        public int getSetRuns { get; set; }
        public bool isNpc { get; set; }

        public Player(string sName, bool isNpc) {
            getSetName = sName;
            this.isNpc = isNpc;
            getSetMoneyAmount = 4000;
        }
    }
}
