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
           
            Questions newQuestions = new Questions()
            {
                QuestionId = 1,
                Problem = "What is 1 + 1?"
            };

            TestQuestionView resultView = new TestQuestionView()
            {
                TestId = testId,
                Title = "Level 1",
                TimeAllowed = 1000,
                questions = newQuestions
            };

            return resultView;
        }

    }
}
