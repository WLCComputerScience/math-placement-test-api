﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public interface IGetStudentResultSummary
    {
        public GetStudentResultSummaryView GetStudentResultSummary(GetStudentResultSummaryParams studentResultSummaryParams);
    }
}
