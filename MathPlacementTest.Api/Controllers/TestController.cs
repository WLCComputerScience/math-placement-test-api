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
    public class TestController : ControllerBase
    {

        private readonly ITestQuestionsFetcherService _testQuestionsFetcherService;

        public TestController(ITestQuestionsFetcherService testQuestionsFetcherService)
        {
            _testQuestionsFetcherService = testQuestionsFetcherService;

        }

        [HttpPost]
        [Route("GetQuestions")]
        public TestQuestionView GetQuestions([FromForm] GetQuestionsParams getQuestionsParams)
        {
            return _testQuestionsFetcherService.GetTestQuestions(getQuestionsParams);
        }
    }
}
