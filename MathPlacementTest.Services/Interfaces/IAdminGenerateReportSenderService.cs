using System;
using System.Collections.Generic;
using System.Text;
using MathPlacementTest.Services.Objects;
using Microsoft.AspNetCore.Mvc;

namespace MathPlacementTest.Services
{
    public interface IAdminGenerateReportSenderService
    {
        public FileStreamResult SendFile(GenerateReportParams generateReportParams);
    }
}
