using MathPlacementTest.Services.Objects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MathPlacementTest.Services
{
    public class AdminGenerateReportSenderService : IAdminGenerateReportSenderService
    {
        private readonly IAdminGenerateReportService _adminGenerateReportService;

        public AdminGenerateReportSenderService(IAdminGenerateReportService adminGenerateReportService)
        {
            _adminGenerateReportService = adminGenerateReportService;
        }
        public FileStreamResult SendFile(GenerateReportParams generateReportParams)
        {
            if(generateReportParams == null)
            {
                return null;
            }

            if(_adminGenerateReportService.GenerateReport(generateReportParams) == false)
            {
                return null;
            }

            FileStream fileStream = File.Open(@"..\..\PlacementTestReports\" + generateReportParams.FileName + ".csv", FileMode.OpenOrCreate);
            return new FileStreamResult(fileStream, "text /csv") { FileDownloadName = generateReportParams.FileName + ".csv" };
        }
    }
}
