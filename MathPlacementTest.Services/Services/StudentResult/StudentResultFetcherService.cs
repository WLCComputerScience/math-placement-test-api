using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentResultFetcherService : IStudentResultFetcherService
    {
        private readonly MathTestDbContext _dbContext;

        public StudentResultFetcherService(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public StudentResultView GetStudentResults(StudentResultParams studentResultParams)
        {
            var result = _dbContext.studentData.Where(d => d.StudentId == studentResultParams.StudentId).FirstOrDefault();

            StudentResultView resultView = new StudentResultView()
            {
                //StudentId = result.StudentId,
                //NumberCorrect = result.NumberCorrect,
                //TotalNumber = result.TotalNumber
            };
            return resultView;
        }
    }
}
