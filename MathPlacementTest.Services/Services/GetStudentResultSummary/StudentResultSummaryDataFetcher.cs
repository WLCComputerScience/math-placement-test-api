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
            //dbcontext.questions
            //use linq statement to find all questions with an id in that list
            //return those questions
            var questionAnswers = new List<QuestionAnswer>();

            foreach(var id in questionIds)
            {
                var answer = _dbcontext.Questions.Where(a => a.QuestionId == id).Select(a => new QuestionAnswer() { CorrectAnswer = a.CorrectAnswer }).ToList();
                questionAnswers.Add(answer);
            }
            return questionAnswers;
        }

        public IEnumerable<StudentQuestionResult> GetAllStudentQuestions(long studentId)
        {
            var studentAnswers = _dbcontext.StudentAnswers.Where(s => s.StudentId == studentId).Select(s => new StudentQuestionResult() {QuestionId=s.QuestionId, StudentAnswer=s.StudentsAnswer }).ToList();

            return studentAnswers;
        }
    }
}
