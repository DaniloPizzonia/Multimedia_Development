using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeApplication {
    [Serializable]
    public class User {

        /// <summary>
        /// Getter and Setter for this class
        /// </summary>
        public List<Pipe> lPipes { get; set; }
        public List<Tobacco> lTobaccos { get; set; }
        public string Name { get; set; }
        public int PipesCounter { get; set; }
        public int TobaccoCounter { get; set; }
        /// <summary>
        /// Contructors with some overloads
        /// </summary>
        public User() {
            this.lPipes = new List<Pipe>();
            this.lTobaccos = new List<Tobacco>();
        }
        public User(string sName, int iPipeCounter, int iTobaccoCounter) {
            this.Name = sName;
            this.PipesCounter = iPipeCounter;
            this.TobaccoCounter = iTobaccoCounter;
            this.lPipes = new List<Pipe>();
            this.lTobaccos = new List<Tobacco>();
        }
    }
}
