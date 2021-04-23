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
            var questions = ;
            IEnumerable<Questions> q;
            Questions newQuestions = new Questions()
            {
                QuestionId = 1,
                Problem = "1+1"
            };

            TestQuestionView resultView = new TestQuestionView()
            {
                TestId = test.TestId,
                Title = test.Title,
                TimeAllowed = test.TimeAllowed,
                questions = 
            };

            return resultView;
        }
    }
}
