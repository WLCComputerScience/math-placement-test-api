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

        public StudentResultController(IStudentResultFetcherService studentResultFetcherService)
        {
            _studentResultFetcherService = studentResultFetcherService;

        }

        [HttpPost]
        [Route("getResult")]
        public StudentResultView Get([FromForm] StudentResultParams studentResultParams)
        {
            return _studentResultFetcherService.GetStudentResults(studentResultParams);
        }
    }
}
