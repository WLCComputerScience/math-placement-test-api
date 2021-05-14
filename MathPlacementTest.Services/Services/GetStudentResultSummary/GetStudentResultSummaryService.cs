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

            List<long> questionIds = studentAnswers
                .Select(q => q.QuestionId)
                .ToList();

            var counter = 0;

            var correctAnswers = _studentResultSummaryDataFecther.GetAllQuestionAnswers(questionIds);

            foreach(var studAnswer in studentAnswers)
            {
                var answerFound = correctAnswers
                    .Where(a => a.QuestionId == studAnswer.QuestionId && a.CorrectAnswer.ToUpper().Trim() == studAnswer.StudentAnswer.ToUpper().Trim())
                    .FirstOrDefault();
                counter = answerFound == null ? counter : counter + 1;
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
