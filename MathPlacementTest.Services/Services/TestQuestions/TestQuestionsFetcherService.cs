using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class TestQuestionsFetcherService : ITestQuestionsFetcherService
    {
        
        public TestQuestionView GetTestQuestions(int testId)
        {
            var result = ;

            Questions newQuestions = new Questions()
            {
                QuestionId = result.,
                Problem = result.
            };

            TestQuestionView resultView = new TestQuestionView()
            {
                TestId = result.,
                Title = result.,
                TimeAllowed = result.,
                questions = newQuestions
            };

            return resultView;
        }
    }
}
