using MathPlacementTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlacementTest.Api.Controllers
{
    public class StudentController : Controller
    {
        [HttpPost]
        [Route("Create")]
        public StudentCreateView Create([FromForm] string student)
        {
            return default;
        }
    }

}
