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

        public StudentDetailsView GetStudentDetails(GetStudentParams getStudentParams)
        {
            if (getStudentParams.StudentId <= 0)
            {
                return null;
            }

            var student = _studentDetailsDataFetcher.GetStudent(getStudentParams);

            if (student == null)
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

            var newStudentAnswers = _studentDetailsDataFetcher.GetStudentAnswers(getStudentParams);

            var test = _studentDetailsDataFetcher.GetTestName(getStudentParams);

            StudentDetailsView resultView = new StudentDetailsView()
            {
                Student = newStudent,
                Title = test,
                studentAnswers = newStudentAnswers
            };

            return resultView;
        }
    }
}
