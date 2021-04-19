using MathPlacementTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MathPlacementTest.Services.Objects.Student;
using MathPlacementTest.Services.Objects.Test;

namespace MathPlacementTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        [HttpPost]
        [Route("Create")]
        public StudentCreateView Create([FromForm] string student)
        {
            return default;
        }

        [HttpPost]
        [Route("AddQuestionaireInfo")]
        public TestInfo AddQuestionaireInfo([FromForm] StudentQuestionaireInfoParams studentQuestionaireInfoParams)
        {
            // Do things with studentQuestionaireInfoParams in order to determine what test to me
            //

            var hardCodedTest = new TestInfo() { TestName = "Test 1" };
            return hardCodedTest;
        }
    }

}
