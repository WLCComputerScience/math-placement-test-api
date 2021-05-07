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
            //get in list of ids
            //dbcontext.questions
            //use linq statement to find all questions with an id in that list
            //return those questions
            return default;
        }

        public IEnumerable<StudentQuestionResult> GetAllStudentQuestions(long studentId)
        {
            var studentAnswers = _dbcontext.StudentAnswers.Where(s => s.StudentId == studentId).Select(s => new StudentQuestionResult() {QuestionId=s.QuestionId, StudentAnswer=s.StudentsAnswer }).ToList();

            return studentAnswers;
        }
    }
}
