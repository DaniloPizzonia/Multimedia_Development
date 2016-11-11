using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Adventskalender {
    public class Day {
        public int day { get; set; }
        public string categorie { get; set; }
        public string content { get; set; }
        public string clue { get; set; }
        public Ellipse doorName { get; set; }
        public bool doorOpen { get; set; }
    }
}
