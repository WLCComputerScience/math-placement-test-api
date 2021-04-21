using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Data
{
    public class StudentAnswer
    {
        public long TestQuestionId { get; set; }
        public long StudentId { get; set; }
        public long QuestionId { get; set; }
        public string StudentAnswers { get; set; }
        public int TimeRemaining { get; set; }
    }
}
