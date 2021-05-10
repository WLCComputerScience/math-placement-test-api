using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class TestQuestionsDataFetcher : ITestQuestionsDataFetcher
    {
        private readonly MathTestDbContext _dbContext;

        public TestQuestionsDataFetcher(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Test GetTest (int testId)
        {
            var test = _dbContext.Tests.Where(p => p.TestId == testId).FirstOrDefault();
            return test;
        }

        public IEnumerable<Questions> GetQuestions(int testId)
        {
            var questionsToInput = new List<Questions>();

            var testQuestionsWithProblems = (from t in _dbContext.TestQuestions
                                             where t.TestId == testId
                                             join q in _dbContext.Questions
                                             on t.QuestionId equals q.QuestionId
                                             select new
                                             {
                                                 QuestionId = t.QuestionId,
                                                 Problem = q.Problem
                                             }
                                             ).ToList();

            foreach(var info in testQuestionsWithProblems)
            {
                Questions questionUpdated = new Questions()
                {
                    QuestionId = info.QuestionId,
                    Problem = info.Problem
                };
                questionsToInput.Add(questionUpdated);
            }

            return questionsToInput;
        }
    }
}
