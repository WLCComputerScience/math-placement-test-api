using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class GetStudentResultSummaryService : IGetStudentResultSummary
    {
        private readonly IStudentResultSummaryDataFetcher _studentResultSummaryDataFecther;
        public GetStudentResultSummaryService(IStudentResultSummaryDataFetcher studentResultSummaryDataFetcher)
        {
            _studentResultSummaryDataFecther = studentResultSummaryDataFetcher;
        }
        public GetStudentResultSummaryView GetStudentResultSummary(GetStudentResultSummaryParams studentResultSummaryParams)
        {
            if(studentResultSummaryParams.StudentId == 0 || studentResultSummaryParams.StudentId < 0)
            {
                return null;
            }

            var studentAnswers = _studentResultSummaryDataFecther.GetAllStudentQuestions(studentResultSummaryParams.StudentId);

            //get all questions with correct answers
            //compare studentAnswers with correct answers
            //grab that count

            var studentResultSummaryView = new GetStudentResultSummaryView
            {
                NumCorrect = 12,
                NumQuestions = studentAnswers.Count()
            };

            return studentResultSummaryView;
        }
    }
}
