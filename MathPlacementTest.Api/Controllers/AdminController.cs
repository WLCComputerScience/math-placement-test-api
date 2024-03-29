using MathPlacementTest.Services;
using MathPlacementTest.Services.Objects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlacementTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AdminController : Controller
    {
        private readonly IGetAllStudentService _getAllStudentService;
        private readonly IAdminStudentPlacementUpdateService _adminUpdateStudentPlacement;
        private readonly IAdminGenerateReportService _adminGenerateReportService;
        private readonly IEmailReportService _emailReportService;
        private readonly IAdminGenerateReportSenderService _adminGenerateReportSenderService;
        private readonly IStudentDetailsFetcherService _studentDetailsFetcherService;

        private readonly IAdminGenerateReportDataRetrieverService _adminGenerateReportDataRetrieverService;

        public AdminController(IGetAllStudentService getAllStudentService,
            IAdminStudentPlacementUpdateService adminUpdateStudentPlacement, 
            IAdminGenerateReportService adminGenerateReportService,
            IEmailReportService emailReportService,
            IAdminGenerateReportSenderService adminGenerateReportSenderService,
            IStudentDetailsFetcherService studentDetailsFetcherService,
            IAdminGenerateReportDataRetrieverService adminGenerateReportDataRetrieverService)
        {
            _getAllStudentService = getAllStudentService;
            _adminUpdateStudentPlacement = adminUpdateStudentPlacement;
            _adminGenerateReportService = adminGenerateReportService;
            _emailReportService = emailReportService;
            _adminGenerateReportSenderService = adminGenerateReportSenderService;
            _studentDetailsFetcherService = studentDetailsFetcherService;
            _adminGenerateReportDataRetrieverService = adminGenerateReportDataRetrieverService;
        }

        [HttpPost]
        [Route("test")]
        public string test()
        {
            return "test";
        }


        [HttpPost]
        [Route("GetAllStudents")]
        public List<GetAllStudentView> GetAllStudent()
        {
            return _getAllStudentService.GetAllStudent();
        }

        [HttpPost]
        [Route("GenerateReport")]
        public FileStreamResult GenerateReport([FromForm] GenerateReportParams generateReportParams)
        {
            //Returns an actual csv file to download
            return _adminGenerateReportSenderService.SendFile(generateReportParams);
        }
        [HttpPost]
        [Route("EmailReport")]
        public bool EmailReport([FromForm] EmailReportParams emailReportParams)
        {
            return _emailReportService.EmailReport(emailReportParams, _adminGenerateReportDataRetrieverService);
        }

        [HttpPost]
        [Route("UpdateStudentPlacement")]
        public AdminUpdateStudentPlacementView UpdateStudentPlacement([FromForm] AdminUpdateStudentPlacementParams updateStudentPlacementParams)
        {
            return _adminUpdateStudentPlacement.UpdateStudentPlacement(updateStudentPlacementParams);
        }
        
        [HttpPost]
        [Route("GetStudentDetails")]
        public StudentDetailsView GetStudentDetails([FromForm] GetStudentParams getStudentParams)
        {
            return _studentDetailsFetcherService.GetStudentDetails(getStudentParams);
        }
    }
}