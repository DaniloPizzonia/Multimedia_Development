using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeApplication {
    [Serializable]
    public class User {
        public User() {
            this.Name = "Pipe Default";
            this.PipesCounter = 10;
            this.TobaccoCounter = 10;
        }
        public User(string sName, int iPipeCounter, int iTobaccoCounter) {
            this.Name = sName;
            this.PipesCounter = iPipeCounter;
            this.TobaccoCounter = iTobaccoCounter;
        }
        public string Name { get; set; }
        
        public int PipesCounter { get; set; }
        
        public int TobaccoCounter { get; set; }
    }
}
