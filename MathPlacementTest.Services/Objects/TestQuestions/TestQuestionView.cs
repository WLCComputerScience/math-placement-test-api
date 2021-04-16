using System;
using System.Collections.Generic;
using System.Text;
namespace MathPlacementTest.Services
{
    public class TestQuestionView
    {
        public int TestId { get; set; }
        public string Title { get; set; }
        public int TimeAllowed { get; set; }
        public Questions questions { get; set; }
    }
}
