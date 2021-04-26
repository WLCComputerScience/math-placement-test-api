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
        private readonly IStudentQuestionaireDataInsertorService _dataInsertorService;

        public StudentQuestionaireInfoCreatorService(IStudentQuestionaireDataInsertorService dataInsertorService)
        {
            _dataInsertorService = dataInsertorService;
        }

        public TestInfo AddQuestionaireInfo(StudentQuestionaireInfoParams studentQuestionaireInfoParams)
        {
            var testToReturn = new TestInfo() { TestId = -1 };

            if (studentQuestionaireInfoParams == null)
            {
                return testToReturn;
            }

            var success = _dataInsertorService.AddQuestionaireData(studentQuestionaireInfoParams);

            if (!success)
            {
                return testToReturn;
            }

            testToReturn.TestId = 2;
            return testToReturn;
        }
    }
}
