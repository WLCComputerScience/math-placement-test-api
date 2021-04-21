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
        private readonly StudentQuestionaireDataInsertorService _dataInsertorService;

        public StudentQuestionaireInfoCreatorService(StudentQuestionaireDataInsertorService dataInsertorService)
        {
            _dataInsertorService = dataInsertorService;
        }

        public TestInfo AddQuestionaireInfo(StudentQuestionaireInfoParams studentQuestionaireInfoParams)
        {

            var hardCodedTest = _dataInsertorService.AddQuestionaireData(studentQuestionaireInfoParams);

            return hardCodedTest;
        }
    }
}
