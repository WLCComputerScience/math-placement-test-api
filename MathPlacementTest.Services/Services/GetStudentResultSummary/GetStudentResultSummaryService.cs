using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public class GetStudentResultSummaryService : IGetStudentResultSummary
    {
        private readonly StudentResultFetcherService _studentResultFetcherService;
        public GetStudentResultSummaryService(StudentResultFetcherService studentResultFetcherService)
        {
            _studentResultFetcherService = studentResultFetcherService;
        }
        public GetStudentResultSummaryView GetStudentResultSummary(GetStudentResultSummaryParams studentResultSummaryParams)
        {
            if(studentResultSummaryParams.StudentId == 0 || studentResultSummaryParams.StudentId < 0)
            {
                return null;
            }

            //get number of questions and number correct

            var studentResultParams = new StudentResultParams
            {
                StudentId = studentResultSummaryParams.StudentId
            };

            var numCorrect = _studentResultFetcherService.GetStudentResults(studentResultParams).NumberCorrect;

            //var numQuestions;

            return null;
        }
    }
}
