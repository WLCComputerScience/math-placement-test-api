using MathPlacementTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MathPlacementTest.Services.Objects.Student;

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
        public string AddQuestionaireInfo([FromForm] StudentQuestionaireInfoParams studentQuestionaireInfoParams)
        {
            var output = "Courses Taken: ";

            foreach (string course in studentQuestionaireInfoParams.CoursesTaken)
            {
                output = output + course + ", ";
            }

            output += " AdvancedCourse: " + studentQuestionaireInfoParams.AdvancedCourse;
            output += " GradeInAdvancedCourse: " + studentQuestionaireInfoParams.GradeInAdvancedCourse;
            output += " DesiredClass: " + studentQuestionaireInfoParams.DesiredClass;
            output += " HadMathInLastYear: " + studentQuestionaireInfoParams.HadMathInLastYear.ToString();

            return output;
        }
    }

}
