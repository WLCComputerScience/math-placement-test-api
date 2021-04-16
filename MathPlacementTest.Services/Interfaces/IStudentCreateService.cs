using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public interface IStudentCreateService
    {
        public StudentCreateView CreateStudent(StudentCreateParams studentCreateParams);
    }
}
