/*using MathPlacementTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlacementTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentCreateController : Controller
    {
        private readonly IStudentCreateService _studentCreateService;
        
        public StudentCreateController(IStudentCreateService studentCreateService)
        {
            _studentCreateService = studentCreateService;
        }

        *//*        [HttpPost]
                [Route("Create")]
                public StudentCreateView CreateStudent([FromForm] string first, string last, string wlcid)
                {
                    StudentCreateView s = new StudentCreateView();
                    s.StudentId = wlcid;
                    s.ResultMessage = "success";
                    return s;
                }*//*

        [HttpPost]
        [Route("Create")]
        public StudentCreateView CreateStudent([FromForm] StudentCreateParams studentCreateParams)
        {
            return _studentCreateService.CreateStudent(studentCreateParams);
        }
    }
}
*/