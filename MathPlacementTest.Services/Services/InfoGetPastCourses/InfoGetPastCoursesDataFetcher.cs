using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class InfoGetPastCoursesDataFetcher : IInfoGetPastCoursesDataFetcher
    {
        private readonly MathTestDbContext _dbContext;

        public InfoGetPastCoursesDataFetcher(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<InfoPastCourse> GetPastCourses()
        {
            var pastCourses = (from pc in _dbContext.PastCourses
                               select new
                               {
                                   PastCourseId = pc.PastCourseId,
                                   DisplayOrder = pc.DisplayOrder,
                                   Description = pc.Description
                               }).ToList();

            List<InfoPastCourse> coursesToReturn = new List<InfoPastCourse>();
            foreach (var pastCourse in pastCourses)
            {
                InfoPastCourse newPastCourse = new InfoPastCourse
                {
                    PastCourseId = pastCourse.PastCourseId,
                    DisplayOrder = pastCourse.DisplayOrder,
                    Description = pastCourse.Description
                };
                coursesToReturn.Add(newPastCourse);
            }

            return coursesToReturn;
        }
    }
}
