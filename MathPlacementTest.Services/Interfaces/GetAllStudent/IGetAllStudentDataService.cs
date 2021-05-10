using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public interface IGetAllStudentDataService
    {
        public List<GetAllStudentView> DBGetAllStudent();
    }
}
