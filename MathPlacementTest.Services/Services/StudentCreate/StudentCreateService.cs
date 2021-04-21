using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentCreateService : IStudentCreateService
    {
        private readonly IStudentCreateDataCreatorService _studentCreateDataCreator;
        
        public StudentCreateService(IStudentCreateDataCreatorService studentCreateDataCreatorService)
        {
            _studentCreateDataCreator = studentCreateDataCreatorService;
        }

        public StudentCreateView CreateStudent(StudentCreateParams studentCreateParams)
        {

            Student student = _studentCreateDataCreator.DBCreateStudent(studentCreateParams);
            var id = student.StudentId;

            StudentCreateView ret = new StudentCreateView
            {
                StudentId = id,
                ResultMessage = "Student created sucessfully"
            };
            return ret;
        }

    }
}
