using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PastCourse = MathPlacementTest.Services.Objects.Courses.PastCourse;

namespace MathPlacementTest.Services
{
    public class GetPastCoursesDataRetrieverService : IGetPastCourseDataRetrieverService
    {
        private readonly MathTestDbContext _dbContext;

        public GetPastCoursesDataRetrieverService(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<PastCourse> GetPastCourses(long studentId)
        {
            //Join with the pastcourse table to get full description and display order
            var courses = (from ct in _dbContext.CoursesTaken
                           join pc in _dbContext.PastCourses
                           on ct.PastCourseId equals pc.PastCourseId
                           where ct.StudentId == studentId
                           select new
                           {
                               PastCourseId = ct.PastCourseId,
                               Description = pc.Description,
                               DisplayOrder = pc.DisplayOrder
                           }).ToList();
            List<PastCourse> coursesToReturn = new List<PastCourse>();
            //Create a new list of pastCourses as orderedCourses and sort by DisplayOrder
            foreach (var c in courses)
            {
                PastCourse pastCourse = new PastCourse() { Description = c.Description, DisplayOrder = c.DisplayOrder, PastCourseId = c.PastCourseId };
                coursesToReturn.Add(pastCourse);
            }
            return coursesToReturn;
        }
    }
}
