using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeApplication {
    [Serializable]
    public class Tobacco {
        
        public Tobacco() {
            this.Name = "Default Tobacco";
            this.Rating = 5;
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
        public int Rating { get; set; }
    }
}
