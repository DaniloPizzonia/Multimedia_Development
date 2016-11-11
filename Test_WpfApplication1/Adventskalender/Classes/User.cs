using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventskalender {
    public class User {
        public User() {
            usedQuestions = new List<UsedQuestion>();
            lDays = new List<Day>();
        }
        
        public List<UsedQuestion> usedQuestions { get; set; }
        public List<Day> lDays { get; set; }
    }
    public class UsedQuestion {
        public int QuestionId { get; set; }
        public bool isRight { get; set; }
    }
}
