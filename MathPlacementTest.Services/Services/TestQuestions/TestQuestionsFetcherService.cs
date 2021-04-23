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
            var test = _testQuestionsDataFetcher.GetTest(testId);
            IEnumerable<Questions> questions;

            questions = _testQuestionsDataFetcher.GetQuestions(testId);

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
