using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class TestQuestionsDataFetcher : ITestQuestionsDataFetcher
    {
        private readonly MathTestDbContext _dbContext;

        public TestQuestionsDataFetcher(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }



    }
}
