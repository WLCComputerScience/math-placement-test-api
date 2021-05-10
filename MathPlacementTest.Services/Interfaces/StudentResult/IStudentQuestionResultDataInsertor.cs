using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public interface IStudentQuestionResultDataInsertor
    {
        public BooleanResponse InsertStudentQuestionResult(InsertStudentResultParams insertStudentResultParams);
    }
}
