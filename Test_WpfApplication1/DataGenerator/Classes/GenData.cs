using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator {
    public class GenData {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PercentFemale { get; set; }
        public int CountObjects { get; set; }
        public DateTime TimeStamp_Generated { get; set; }
        public List<Person> lPersons { get; set; }

        public GenData() {
            this.lPersons = new List<Person>();
        }
    }
}
