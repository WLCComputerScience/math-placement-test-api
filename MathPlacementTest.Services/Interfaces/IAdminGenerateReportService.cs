using MathPlacementTest.Services.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MathPlacementTest.Services
{
    public interface IAdminGenerateReportService
    {
        public bool GenerateReport(GenerateReportParams generateReportParams);

        public void WriteCSV<T>(IEnumerable<T> items, string path);
    }
}
