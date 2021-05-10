using MathPlacementTest.Services.Objects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MathPlacementTest.Services
{
    public interface IAdminGenerateReportDataRetrieverService
    {
        public List<ReportDetails> FetchData(GenerateReportParams generateReportParams);
    }
}
