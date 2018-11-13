using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MasterConverter.Classes {
    public class Helper {
        public Helper() {
            lButtonsVeryHigh = new List<Button>();
            lButtonsHigh = new List<Button>();
            lButtonsMedium = new List<Button>();
            lButtonslow = new List<Button>();
        }
        public List<Button> lButtonsVeryHigh { get; set; }
        public List<Button> lButtonsHigh { get; set; }
        public List<Button> lButtonsMedium { get; set; }
        public List<Button> lButtonslow { get; set; }

    }
}
