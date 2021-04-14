using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public interface IStudentResultFetcherService
    {
        StudentResultView GetStudentResults(StudentResultParams studentResultParams);
    }
}
