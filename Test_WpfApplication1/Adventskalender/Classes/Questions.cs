using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventskalender {
    public class Questions {
        public Questions() {
            QuestionTextAnswers = new List<Answers>();
        }

        public int QuestionsId { get; set; }
        public string QuestionText { get; set; }
        public List<Answers> QuestionTextAnswers { get; set; }
    }

    public class Answers {
        public string answerText { get; set; }
        public bool isRight { get; set; }
    }
}
