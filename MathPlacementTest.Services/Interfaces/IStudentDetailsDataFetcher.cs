using System;
using System.Collections.Generic;
using System.Text;
using MathPlacementTest.Data;

namespace MathPlacementTest.Services
{
    public interface IStudentDetailsDataFetcher
    {
        public Student GetStudent(int studentId);
        public string GetTestName(int studentId);
        public IEnumerable<StudentAnswers> GetStudentAnswers(int studentId);
    }
}
