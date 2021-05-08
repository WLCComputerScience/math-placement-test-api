using System;
using System.Collections.Generic;
using System.Text;
using MathPlacementTest.Data;

namespace MathPlacementTest.Services
{
    public interface IStudentDetailsDataFetcher
    {
        public Student GetStudent(int studentId);
        //public Test GetTestId(int studentId);
        public IEnumerable<StudentAnswers> GetStudentAnswers(int studentId);
    }
}
