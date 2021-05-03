using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public class InsertStudentResultParams
    {
        public long StudentId { get; set; }
        public long QuestionId { get; set; }
        public int TimeRemaining { get; set; }
        public string Answer { get; set; }
    }
}
