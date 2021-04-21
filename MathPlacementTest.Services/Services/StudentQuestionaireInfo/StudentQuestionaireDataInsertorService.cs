using MathPlacementTest.Services.Objects.Student;
using MathPlacementTest.Services.Objects.Test;
using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentQuestionaireDataInsertorService : IStudentQuestionaireDataInsertorService
    {
        private readonly MathTestDbContext _dbContext;

        public StudentQuestionaireDataInsertorService(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public TestInfo AddQuestionaireData(StudentQuestionaireInfoParams studentQuestionaireInfoParams)
        {
            var hardCodedTest = new TestInfo() { TestName = "Test 5 I guess" };
            return hardCodedTest;
        }
    }
}
