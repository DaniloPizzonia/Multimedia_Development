using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MasterConverter.Classes {
    public class Converter {
        public Converter() {}

        public int userInput { get; set; }

        public int linkeSpalteDec { get; set; }
        public int linkeSpalteBaby{ get; set; }

        public int ganzLinkeSpalteDec { get; set; }
        public int ganzLinkeSpalteBaby { get; set; }

        public int mittlereSpalteDec { get; set; }
        public int mittlereSpalteBaby { get; set; }

        public int rechteSpalteDecBaby { get; set; }


        public int selectedSpalteBaby { get; set; }
        public int selectedSpalteDec { get; set; }


        public string modHigh(int userInitalInput) {
            // x 3600
            this.userInput = userInitalInput;
            
            int high = 3600;
            int veryHigh = high * 60;

            var multiplier = this.userInput / veryHigh;
            this.ganzLinkeSpalteBaby = multiplier;
            this.ganzLinkeSpalteDec = multiplier * veryHigh;
            MessageBox.Show(this.ganzLinkeSpalteBaby + " " + this.ganzLinkeSpalteDec);
            this.userInput -= veryHigh;

            multiplier = this.userInput / high;

            //  ergInDec is the babylonische dec zahl linke spalte => 2 * 3600
            // multiplier ist die anzahl der babylonischen in dem fall bei 2 => ||
            var ergInDec = multiplier * high;

            this.linkeSpalteBaby = multiplier;
            this.linkeSpalteDec = ergInDec;

            return this.modMid();
        }

        public string modMid() {
            // x 60
            var tempErg = this.userInput - this.linkeSpalteDec;

            int mid = 60;
            var multiplier = tempErg / mid;

            this.mittlereSpalteDec = tempErg;
            this.mittlereSpalteBaby = multiplier;

            // + rest
            this.rechteSpalteDecBaby = tempErg % mid;

            string sAll = "ganz linke Spalte Dec: " + this.ganzLinkeSpalteDec + " " + " ganz linke Spalte Baby: " + this.ganzLinkeSpalteBaby +
                    "linke Spalte Dec: " + this.linkeSpalteDec + " " + " linke Spalte Baby: " + this.linkeSpalteBaby +
                    "| mittlere Spalte Dec: " + this.mittlereSpalteDec + " mittlere Spalte Baby: " + this.mittlereSpalteBaby +
                    "| rechte Spalte Dec: " + this.rechteSpalteDecBaby;
            string mult = this.linkeSpalteBaby +
                   "| " + this.mittlereSpalteBaby +
                   "| " + this.rechteSpalteDecBaby;
            MessageBox.Show(sAll);
            return mult;
        } 

    }
}
