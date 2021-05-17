using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public interface IEmailReportService
    {
        bool EmailReport(EmailReportParams emailReportParams, IAdminGenerateReportDataRetrieverService adminGenerateReportService);
    }
}
