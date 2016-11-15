using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Adventskalender {
    public class GetContent:IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var sQuestion = (from q in MainWindow._lQuestions
                             where q.QuestionsId == (int)value
                             select q).FirstOrDefault();
            if(sQuestion != null) {
                var sAnswer = (from a in sQuestion.QuestionTextAnswers
                                where a.isRight
                                select a.answerText).FirstOrDefault();
                return sQuestion.QuestionText + "\nANTWORT IST " + sAnswer;
            } else {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class BoolConverter:IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            bool isRight = (bool)value;
            if(isRight) {
                return "Richtig";
            } else {
                return "Falsch";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
