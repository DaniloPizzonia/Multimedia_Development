using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventskalender {
    public class User {
        public User() {
            openDoors = new List<int>();
            usedQuestions = new List<UsedQuestion>();
        }
        
        public List<int> openDoors { get; set; }
        public List<UsedQuestion> usedQuestions { get; set; }
    }
    public class UsedQuestion {
        public int QuestionId { get; set; }
        public bool isRight { get; set; }
    }
}
