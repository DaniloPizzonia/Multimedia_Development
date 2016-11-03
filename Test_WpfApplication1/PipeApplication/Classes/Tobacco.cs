using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeApplication {
    public class Tobacco {
        
        public Tobacco() { }
        public Tobacco(string sName) {
            this.Name = sName;
        }

        /// <summary>
        /// Getter and Setter Methods
        /// </summary>
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string BlendType { get; set; }
        public string Content { get; set; }
        public string Cut { get; set; }
        public string Country { get; set; }
        public string Production { get; set; }
        public string Strength { get; set; }
        public int Flavoring { get; set; }
        public int Taste { get; set; }
        public int RoomNote { get; set; }
        public int SmokedBowls { get; set; }
    }
}
