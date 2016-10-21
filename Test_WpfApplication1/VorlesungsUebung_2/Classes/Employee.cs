using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorlesungsUebung_2 {
    [Serializable]
    public class Employee {

        public int age { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string title { get; set; }
        public string profileUri { get; set; }
    }
}
