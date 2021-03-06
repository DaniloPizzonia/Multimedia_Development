﻿using System;
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
            this.ReservedForFlavor = "";
            this.SmokedBowls = 0;
            this.Comment = "Enter a Comment";
            this.Pieces = 0;
            this.profileUri = "";
        }

        public string Name { get; set; }
        public string PipeMaker { get; set; }
        public string Description { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int SmokedBowls { get; set; }
        public double Price { get; set; }
        public string ReservedForFlavor { get; set; }
        public string Comment { get; set; }
        public int Pieces { get; set; }
        public string profileUri { get; set; }
        public string State { get; set; }
        public int Rating { get; set; }
        public string UniCode1 { get; set; }
        public string UniCode2 { get; set; }
        public string UniCode3 { get; set; }
        public string UniCode4 { get; set; }
        public string UniCode5 { get; set; }
    }
}
