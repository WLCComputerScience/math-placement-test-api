using System;
using System.Collections.Generic;
using System.Text;
using MathPlacementTest.Services.Objects.Student;
using MathPlacementTest.Services.Objects.Test;

namespace MathPlacementTest.Services
{
    public interface IStudentQuestionaireDataInsertorService
    {
        public bool AddQuestionaireData(StudentQuestionaireInfoParams studentQuestionaireInfoParams);

        public bool AddTestTakenData(StudentQuestionaireInfoParams studentQuestionaireInfoParams, TestInfo testInfo);
    }
}
