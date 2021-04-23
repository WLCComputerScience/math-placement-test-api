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
            var testQuestions = _dbContext.TestQuestions.Where(p => p.TestId == testId).ToList();
            var questionsToInput = new List<Questions>();

            foreach (var testQuestion in testQuestions)
            {
                var questions = _dbContext.Questions.Where(p => p.QuestionId == testQuestion.QuestionId).ToList();
                foreach (var question in questions)
                {
                    Questions questionUpdated = new Questions()
                    {
                        QuestionId = question.QuestionId,
                        Problem = question.Problem
                    };
                    questionsToInput.Add(questionUpdated);
                }
            }
            return questionsToInput;
        }
    }
}
