using MathPlacementTest.Services.Objects.Courses;
using MathPlacementTest.Services.Objects.Student;
using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PastCourse = MathPlacementTest.Services.Objects.Courses.PastCourse;

namespace MathPlacementTest.Services.Services
{
    public class GetPastCoursesService : IGetPastCoursesService
    {
        private readonly MathTestDbContext _dbContext;

        public GetPastCoursesService(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<PastCourse> GetPastCourses(GetPastCoursesParams getPastCoursesParams)
        {
            List<PastCourse> coursesToReturn = new List<PastCourse>();
            if(getPastCoursesParams == null)
            {
                return null;
            }
            //Get all CoursesTaken associated with the student id.

            var courses = (from ct in _dbContext.CoursesTaken
                           join pc in _dbContext.PastCourses
                           on ct.PastCourseId equals pc.PastCourseId
                           where ct.StudentId == getPastCoursesParams.StudentId
                           select new
                           {
                               PastCourseId = ct.PastCourseId,
                               Description = pc.Description,
                               DisplayOrder = pc.DisplayOrder
                           }).ToList();
            var orderedCourses = courses.OrderBy(order => order.DisplayOrder).ToList();
            //var studentPastCourses = _dbContext.CoursesTaken.Where(s => s.StudentId == getPastCoursesParams.StudentId).ToList();
            //foreach(CourseTaken course in studentPastCourses)
            //{
            //    var pastCourseInfo = _dbContext.PastCourses.Where(p => p.PastCourseId == course.PastCourseId).FirstOrDefault();
            //    //
                
            //}
            throw new NotImplementedException();
        }
    }
}
