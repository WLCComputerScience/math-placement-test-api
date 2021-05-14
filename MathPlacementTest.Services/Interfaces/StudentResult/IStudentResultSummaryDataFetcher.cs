using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public interface IStudentResultSummaryDataFetcher
    {
        public IEnumerable<StudentQuestionResult> GetAllStudentQuestions(long studentId);
        public IEnumerable<QuestionAnswer> GetAllQuestionAnswers(IEnumerable<long> questionIds);
    }
}
