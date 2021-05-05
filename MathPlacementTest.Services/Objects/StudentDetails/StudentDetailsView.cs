using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentDetailsView
    {
        public StudentInfo student { get; set; }
        public int TestId { get; set; }
        public StudentAnswers studentAnswers { get; set; }
    }
}
