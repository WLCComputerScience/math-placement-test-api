﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services.Objects.Student
{
    public class StudentQuestionaireInfoParams
    {
        public List<string> CoursesTaken { get; set; }

        public string AdvancedCourse { get; set; }

        public string GradeInAdvancedCourse { get; set; }
        public string DesiredClass { get; set; }

        public bool HadMathInLastYear { get; set; }
    }
}