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
    public class InfoController : ControllerBase
    {

        private readonly IInfoGetPastCoursesFetcherService _infoGetPastCoursesFetcherService;

        public InfoController(IInfoGetPastCoursesFetcherService infoGetPastCoursesFetcherService)
        {
            _infoGetPastCoursesFetcherService = infoGetPastCoursesFetcherService;

        }

        [HttpPost]
        [Route("GetPastCourses")]
        public PastCoursesView GetPastCourses()
        {
            return _infoGetPastCoursesFetcherService.GetPastCourses();
        }
    }
}
