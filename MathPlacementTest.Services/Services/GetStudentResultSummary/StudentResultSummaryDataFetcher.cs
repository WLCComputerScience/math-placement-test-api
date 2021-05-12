using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentResultSummaryDataFetcher : IStudentResultSummaryDataFetcher
    {
        private readonly MathTestDbContext _dbcontext;
        public StudentResultSummaryDataFetcher(MathTestDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public IEnumerable<QuestionAnswer> GetAllQuestionAnswers(IEnumerable<long> questionIds)
        {
            var questionAnswers = _dbcontext.Questions
                .Where(q => questionIds.Any(x => x == q.QuestionId))
                .Select(q => new QuestionAnswer() { QuestionId = q.QuestionId, CorrectAnswer = q.CorrectAnswer })
                .ToList();

            return questionAnswers;
        }

        public IEnumerable<StudentQuestionResult> GetAllStudentQuestions(long studentId)
        {
            var studentAnswers = _dbcontext.StudentAnswers
                .Where(s => s.StudentId == studentId)
                .Select(s => new StudentQuestionResult() {QuestionId=s.QuestionId, StudentAnswer=s.StudentsAnswer })
                .ToList();

            return studentAnswers;
        }
    }
}
