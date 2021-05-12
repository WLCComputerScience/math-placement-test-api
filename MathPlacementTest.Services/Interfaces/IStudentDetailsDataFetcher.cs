using System;
using System.Collections.Generic;
using System.Text;
using MathPlacementTest.Data;

namespace MathPlacementTest.Services
{
    public interface IStudentDetailsDataFetcher
    {
        public Student GetStudent(GetStudentParams getStudentParams);
        public string GetTestName(GetStudentParams getStudentParams);
        public IEnumerable<StudentAnswers> GetStudentAnswers(GetStudentParams getStudentParams);
    }
}
