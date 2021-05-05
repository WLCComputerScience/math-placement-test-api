using MathPlacementTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlacementTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {

        private readonly IStudentDetailsFetcherService _studentDetailsFetcherService;

        public AdminController(IStudentDetailsFetcherService studentDetailsFetcherService)
        {
            _studentDetailsFetcherService = studentDetailsFetcherService;

        }

        [HttpPost]
        [Route("GetStudentDetails")]
        public StudentDetailsView GetStudentDetails([FromForm] GetStudentParams getStudentParams)
        {
            return _studentDetailsFetcherService.GetStudentDetails(getStudentParams.StudentId);
        }
    }
}