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

            var questionIds = new List<long>();

            var counter = 0;

            var correctAnswers = _studentResultSummaryDataFecther.GetAllQuestionAnswers(questionIds);

            foreach(var studAnswer in studentAnswers)
            {
                foreach(var corrAnswer in correctAnswers)
                {
                    if (studAnswer.ToString() == corrAnswer.ToString()) counter++;
                }
            }

            var studentResultSummaryView = new GetStudentResultSummaryView
            {
                NumCorrect = counter,
                NumQuestions = studentAnswers.Count()
            };

            return studentResultSummaryView;
        }
    }
}
