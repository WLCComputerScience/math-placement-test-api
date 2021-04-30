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
    public class GetAllStudentController : Controller
    {
        private readonly IStudentCreateService _studentCreateService;
        public StudentController(IStudentCreateService studentCreateService)
        {
            _studentCreateService = studentCreateService;
        }

        [HttpPost]
        [Route("GetAllStudents")]
        public StudentCreateView CreateStudent([FromForm] StudentCreateParams studentCreateParams)
        {
            return _studentCreateService.CreateStudent(studentCreateParams);
        }
    }
*/