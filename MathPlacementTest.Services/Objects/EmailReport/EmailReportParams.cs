using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public class EmailReportParams
    {
        public string ToEmailAddress { get; set; }
        public string FilePath { get; set; }
        public string errorMessage { get; set; }
    }
}
