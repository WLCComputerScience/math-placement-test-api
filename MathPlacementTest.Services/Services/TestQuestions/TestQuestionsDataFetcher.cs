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
            IEnumerable<Questions> questionList;
            var questionIds = _dbContext.TestQuestions.Where(p => p.TestId == testId).ToList();
            var questions = _dbContext.Questions.Where(p => p.QuestionId == questionIds).ToList();
        }

    }
}
