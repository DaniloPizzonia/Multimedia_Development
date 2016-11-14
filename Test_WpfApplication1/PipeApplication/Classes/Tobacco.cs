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
            this.profileUri = "";
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
        public string Strength { get; set; }
        public string profileUri { get; set; }
        public string Flavoring { get; set; }
        public string Note { get; set; }
        public int Taste { get; set; }
        public int RoomNote { get; set; }
        public int SmokedBowls { get; set; }
        public int Rating { get; set; }
        public string UniCode1 { get; set; }
        public string UniCode2 { get; set; }
        public string UniCode3 { get; set; }
        public string UniCode4 { get; set; }
        public string UniCode5 { get; set; }
        public int TobaccoAmount { get; set; }
        public double Price { get; set; }

        public int getTotalGramms { get; set; }
    }
}
