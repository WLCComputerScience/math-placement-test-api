using System;
using System.Collections.Generic;
using System.Text;
using MathPlacementTest.Services.Objects.Courses;

namespace MathPlacementTest.Services.Objects.Student
{
    public class StudentQuestionaireInfoParams
    {
        public IEnumerable<PastCourse> CoursesTaken { get; set; }

        public string AdvancedCourse { get; set; }

        public string GradeInAdvancedCourse { get; set; }
        public string DesiredClass { get; set; }

        public bool HadMathInLastYear { get; set; }
    }
}
