using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public interface IStudentCreateDataCreatorService
    {
        Student DBCreateStudent(StudentCreateParams studentCreateParams);
    }
}
