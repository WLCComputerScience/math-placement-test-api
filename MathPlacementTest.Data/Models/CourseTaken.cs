using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MathPlacementTest.Data
{
    public class CourseTaken
    {
        [Key]
        public long CoursesTakenId { get; set; }
        public long StudentId { get; set; }
        public long PastCourseId { get; set; }
    }
}
