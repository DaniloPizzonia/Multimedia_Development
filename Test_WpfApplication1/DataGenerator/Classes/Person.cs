using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator {
    public class Person {
        public string LastName { get; set; }
        public string  FirstName { get; set; }
        public bool Female { get; set; } // true = female
        public DateTime Birthday { get; set; }
    }
}
