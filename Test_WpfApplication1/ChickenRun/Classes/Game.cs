using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Speech.Synthesis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenRun {
    [Serializable]
    public class Game {
        public double getSetResource { get; set; }
        public List<Chicken> lChicken { get; set; }
        public ObservableCollection<Player> lPlayer { get; set; }
        [NonSerialized]
        List<string> lNpcNames = new List<string>() {
            "Danilo", "Opi Andi"
        };
        [NonSerialized]
        List<string> chickenName = new List<string>() {
            "Chicki", "Lulu"
        };
        public Game() {
            lChicken = new List<Chicken>();
            lPlayer = new ObservableCollection<Player>();
            initPlayer();
            initChicken();
        }

        private void initChicken() {
            for(int i = 0; i < chickenName.Count; i++) {
                var oChicken = new Chicken(chickenName[i]);
                lChicken.Add(oChicken);
            }
        }

        private void initPlayer() {
            for(int i = 0; i < lNpcNames.Count; i++) {
                Player oPlayer = new Player(lNpcNames[i], true);
                lPlayer.Add(oPlayer);
            }
        }

    }
}
