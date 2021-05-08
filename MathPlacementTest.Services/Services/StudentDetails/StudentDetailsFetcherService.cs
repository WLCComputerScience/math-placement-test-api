using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentDetailsFetcherService : IStudentDetailsFetcherService
    {
        private readonly IStudentDetailsDataFetcher _studentDetailsDataFetcher;

        public StudentDetailsFetcherService(IStudentDetailsDataFetcher studentDetailsDataFetcher)
        {
            _studentDetailsDataFetcher = studentDetailsDataFetcher;
        }

        public StudentDetailsView GetStudentDetails(int studentId)
        {
            if (studentId <= 0)
            {
                return null;
            }

            var student = _studentDetailsDataFetcher.GetStudent(studentId);

            if(student == null)
            {
                return null;
            }

            StudentInfo newStudent = new StudentInfo()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                WLCId = student.WLCId,
                InsertedOn = student.InsertedOn,
                MostAdvancedClass = student.MostAdvancedClass,
                AdvancedClassGrade = student.MostAdvancedClassGrade,
                DesiredClass = student.DesiredClass,
                MathInLastYear = student.MathInLastYear,
                ChosenClass = student.ClassChosen
            };

            var newStudentAnswers = _studentDetailsDataFetcher.GetStudentAnswers(studentId);

            if (newStudentAnswers.Count() == 0)
            {
                return null;
            }

            StudentDetailsView resultView = new StudentDetailsView()
            {
                Student = newStudent,
                TestId = 1,
                studentAnswers = newStudentAnswers
            };

            return resultView;
        }
    }
}
