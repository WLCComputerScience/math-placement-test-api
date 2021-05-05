using System;
using System.Collections.Generic;
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
            var date = new DateTime(2021, 4, 23);

            StudentInfo newStudent = new StudentInfo()
            {
                FirstName = "Lucas",
                LastName = "Roecker",
                WLCId = 1476996,
                InsertedOn = date,
                MostAdvancedClass = "Calc BC",
                AdvancedClassGrade = "A",
                DesiredClass = "Calc 3",
                MathInLastYear = true,
                ChosenClass = "Calc infinity"
            };

            StudentAnswers newstudentAnswers = new StudentAnswers()
            {
                QuestionId = 1,
                CorrectAnswer = "A",
                StudentAnswer = "B"
            };

            StudentDetailsView resultView = new StudentDetailsView()
            {
                student = newStudent,
                TestId = 1,
                studentAnswers = newstudentAnswers
            };

            return resultView;
        }
    }
}
