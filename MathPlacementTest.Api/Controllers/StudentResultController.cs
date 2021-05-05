using MathPlacementTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlacementTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentResultController : ControllerBase
    {

        private readonly IStudentResultFetcherService _studentResultFetcherService;
        private readonly IGetStudentResultSummary _studentResultsSummary;

        public StudentResultController(IStudentResultFetcherService studentResultFetcherService, IGetStudentResultSummary studentResultSummary)
        {
            _studentResultFetcherService = studentResultFetcherService;
            _studentResultsSummary = studentResultSummary;
        }

        [HttpPost]
        [Route("getResult")]
        public StudentResultView Get([FromForm] StudentResultParams studentResultParams)
        {
            return _studentResultFetcherService.GetStudentResults(studentResultParams);
        }

        [HttpPost]
        [Route("getStudentSummary")]
        public GetStudentResultSummaryView GetStudentResultSummary([FromForm] GetStudentResultSummaryParams studentResultSummaryParams)
        {
            return _studentResultsSummary.GetStudentResultSummary(studentResultSummaryParams);
        }
    }
}
