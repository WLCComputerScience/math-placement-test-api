using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MathPlacementTest.Data
{
    public class StudentAnswer
    {
        [Key]
        public long TestQuestionId { get; set; }
        public long StudentId { get; set; }
        public long QuestionId { get; set; }
        public string StudentsAnswer { get; set; }
        public int TimeRemaining { get; set; }
    }
}