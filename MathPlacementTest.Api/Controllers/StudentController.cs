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
        private readonly IStudentQuestionaireInfoCreatorService _studentQuestionaireInfoCreatorService;
        public StudentController(IStudentQuestionaireInfoCreatorService studentQuestionaireInfoCreatorService)
        {
            _studentQuestionaireInfoCreatorService = studentQuestionaireInfoCreatorService;
        }
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
            return _studentQuestionaireInfoCreatorService.AddQuestionaireInfo(studentQuestionaireInfoParams);
        }
    }

}
