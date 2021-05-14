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
        private readonly IGetStudentResultSummary _studentResultsSummary;

        public StudentResultController(IGetStudentResultSummary studentResultSummary)
        {
            _studentResultsSummary = studentResultSummary;
        }

        [HttpPost]
        [Route("getStudentSummary")]
        public GetStudentResultSummaryView GetStudentResultSummary([FromForm] GetStudentResultSummaryParams studentResultSummaryParams)
        {
            return _studentResultsSummary.GetStudentResultSummary(studentResultSummaryParams);
        }
    }
}
