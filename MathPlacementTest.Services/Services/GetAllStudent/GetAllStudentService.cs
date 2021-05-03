using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public class GetAllStudentService : IGetAllStudentService
    {
        private readonly IGetAllStudentDataService _getAllStudentDataService;

        public GetAllStudentService(IGetAllStudentDataService getAllStudentDataService)
        {
            _getAllStudentDataService = getAllStudentDataService;
        }
        public List<GetAllStudentView> GetAllStudent()
        {
            return _getAllStudentDataService.DBGetAllStudent();
        }
    }
}
