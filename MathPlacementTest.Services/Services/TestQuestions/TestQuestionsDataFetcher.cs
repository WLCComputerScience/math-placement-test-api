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

        public Test GetTest (GetQuestionsParams getQuestionsParams)
        {
            var test = _dbContext.Tests.Where(p => p.TestId == getQuestionsParams.TestId).FirstOrDefault();
            return test;
        }

        public IEnumerable<Questions> GetQuestions(GetQuestionsParams getQuestionsParams)
        {
            var questionsToInput = new List<Questions>();

            var testQuestionsWithProblems = (from t in _dbContext.TestQuestions
                                             where t.TestId == getQuestionsParams.TestId
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
