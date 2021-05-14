using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentDetailsView
    {
        public StudentInfo Student { get; set; }
        public string Title { get; set; }
        public IEnumerable<StudentAnswers> studentAnswers { get; set; }
    }
}
