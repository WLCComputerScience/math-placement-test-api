using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentQuestionResultService : IStudentQuestionResultService
    {
        private readonly IStudentQuestionResultDataInsertor _studentQuestionResultDataInsertor;
        public StudentQuestionResultService(IStudentQuestionResultDataInsertor studentQuestionResultDataInsertor)
        {
            _studentQuestionResultDataInsertor = studentQuestionResultDataInsertor;
        }

        public BooleanResponse CreateStudentQuestionResult(InsertStudentResultParams insertStudentResultParams)
        {
            return _studentQuestionResultDataInsertor.InsertStudentQuestionResult(insertStudentResultParams);
        }
    }
}
