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
        private readonly IStudentCreateService _studentCreateService;
        private readonly IStudentQuestionaireInfoCreatorService _studentQuestionaireInfoCreatorService;
        public StudentController(IStudentCreateService studentCreateService, IStudentQuestionaireInfoCreatorService studentQuestionaireInfoCreatorService)
        {
            _studentCreateService = studentCreateService;
            _studentQuestionaireInfoCreatorService = studentQuestionaireInfoCreatorService;
        }

        [HttpPost]
        [Route("Create")]
        public StudentCreateView CreateStudent([FromForm] StudentCreateParams studentCreateParams)
        {
            return _studentCreateService.CreateStudent(studentCreateParams);
        }

        [HttpPost]
        [Route("AddQuestionaireInfo")]
        public TestInfo AddQuestionaireInfo([FromForm] StudentQuestionaireInfoParams studentQuestionaireInfoParams)
        {
            return _studentQuestionaireInfoCreatorService.AddQuestionaireInfo(studentQuestionaireInfoParams);
        }
    }

}
