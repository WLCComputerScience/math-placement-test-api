using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MathPlacementTest
{
    public class Student
    {
        [Key]
        public long StudentId { get; set; }
        public int WLCId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime InsertedOn { get; set; }
        public string ClassChosen { get; set; }
        public bool MathInLastYear { get; set; }
        public string DesiredClass { get; set; }
        public string MostAdvancedClassGrade { get; set; }
        public string MostAdvancedClass { get; set; }
    }
}
