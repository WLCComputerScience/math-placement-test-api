using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services.Objects
{
    public class GenerateReportParams
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string FileName { get; set; }
    }
}
