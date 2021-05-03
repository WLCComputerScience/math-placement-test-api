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
    public class AdminController : Controller
    {
        private readonly IGetAllStudentService _getAllStudentService;
        public AdminController(IGetAllStudentService getAllStudentService)
        {
            _getAllStudentService = getAllStudentService;
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
    }
}
