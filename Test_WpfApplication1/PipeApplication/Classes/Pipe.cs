using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeApplication {
    public class Pipe {
        // test contructor
        public Pipe() {
            this.Description = "test pipe description";
            this.Name = "Test Pipe One";
            this.PipeMaker = "Danilo";
            this.Price = 100;
            this.PurchaseDate = DateTime.Today;
            this.ReservedForFlavor = "Virginia";
            this.SmokedBowls = 0;
            this.Comment = "Enter a Comment";
            this.Pieces = 0;
            this.profileUri = "";
        }

        public string Name { get; set; }
        public string PipeMaker { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int SmokedBowls { get; set; }
        public int Price { get; set; }
        public string ReservedForFlavor { get; set; }
        public string Comment { get; set; }
        public int Pieces { get; set; }
        public string profileUri { get; set; }
    }
}
