using MathPlacementTest.Services.Objects;
using System.Collections.Generic;

namespace MathPlacementTest.Services
{
    public interface IAdminGenerateReportDataRetrieverService
    {
        public List<ReportDetails> FetchData(GenerateReportParams generateReportParams);
    }
}
