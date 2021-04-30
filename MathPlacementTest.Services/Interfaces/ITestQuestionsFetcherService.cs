using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public interface ITestQuestionsFetcherService
    {
        TestQuestionView GetTestQuestions(int testId);
    }
}
