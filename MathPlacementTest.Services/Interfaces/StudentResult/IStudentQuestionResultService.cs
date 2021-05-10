using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public interface IStudentQuestionResultService
    {
        public BooleanResponse CreateStudentQuestionResult(InsertStudentResultParams insertStudentResultParams);
    }
}
