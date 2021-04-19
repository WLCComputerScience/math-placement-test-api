using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentCreateService : IStudentCreateService
    {
        public StudentCreateView CreateStudent(StudentCreateParams studentCreateParams)
        {            
            
            
            StudentCreateView ret = new StudentCreateView();
            ret.StudentId = "1476766";
            ret.ResultMessage = "Student created sucessfully";
            return ret;
        }

    }
}
