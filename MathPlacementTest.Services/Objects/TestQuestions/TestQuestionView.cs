using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public class TestQuestionView
    {
        public long TestId { get; set; }
        public string Title { get; set; }
        public long TimeAllowed { get; set; }
        public IEnumerable<Questions> questions { get; set; }
    }
}
