using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class TestQuestionsFetcherService : ITestQuestionsFetcherService
    {
        private readonly ITestQuestionsDataFetcher _testQuestionsDataFetcher;

        public TestQuestionsFetcherService(ITestQuestionsDataFetcher testQuestionsDataFetcher)
        {
            _testQuestionsDataFetcher = testQuestionsDataFetcher;
        }
        
        public TestQuestionView GetTestQuestions(int testId)
        {
            if (testId <= 0)
            {
                return null;
            }

            var test = _testQuestionsDataFetcher.GetTest(testId);
            var questions = _testQuestionsDataFetcher.GetQuestions(testId);

            if (test == null)
            {
                return null;
            }

            if (questions.Count() == 0)
            {
                return null;
            }

            TestQuestionView resultView = new TestQuestionView()
            {
                TestId = test.TestId,
                Title = test.Title,
                TimeAllowed = test.TimeAllowed,
                questions = questions
            };

            return resultView;
        }
    }
}
