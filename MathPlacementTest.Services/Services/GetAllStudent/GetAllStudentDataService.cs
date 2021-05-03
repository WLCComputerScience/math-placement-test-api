using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public class GetAllStudentDataService : IGetAllStudentDataService
    {
        private readonly MathTestDbContext _dbContext;
        public GetAllStudentDataService(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public  List<GetAllStudentView> DBGetAllStudent()
        {
            List<GetAllStudentView> studentList = new List<GetAllStudentView>();

            foreach (var student in _dbContext.students)
            {
                GetAllStudentView tmp = new GetAllStudentView
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    WLCId = student.WLCId,
                    ClassChosen = student.ClassChosen,
                };

                tmp.InsertedOn = student.InsertedOn.ToString("dd MMMM yyyy");
                studentList.Add(tmp);
            }
            return studentList;
        }
    }
}
