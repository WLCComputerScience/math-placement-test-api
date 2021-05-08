using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentDetailsView
    {
        public StudentInfo Student { get; set; }
        public int TestId { get; set; }
        public IEnumerable<StudentAnswers> studentAnswers { get; set; }
    }
}
