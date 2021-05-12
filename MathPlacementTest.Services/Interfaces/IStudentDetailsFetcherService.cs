using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public interface IStudentDetailsFetcherService
    {
        StudentDetailsView GetStudentDetails(int studentId);
    }
}
