using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MathPlacementTest.Services.Objects.Test;
using MathPlacementTest.Services.Objects.Student;

namespace MathPlacementTest.Services
{
    public class StudentQuestionaireInfoCreatorService: IStudentQuestionaireInfoCreatorService
    {
        private readonly MathTestDbContext _dbContext;

        public StudentQuestionaireInfoCreatorService(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TestInfo AddQuestionaireInfo(StudentQuestionaireInfoParams studentQuestionaireInfoParams)
        {
            throw new NotImplementedException();
        }
    }
}
