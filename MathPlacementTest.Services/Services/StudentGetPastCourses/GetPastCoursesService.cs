using MathPlacementTest.Services.Objects.Courses;
using MathPlacementTest.Services.Objects.Student;
using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PastCourse = MathPlacementTest.Services.Objects.Courses.PastCourse;

namespace MathPlacementTest.Services
{
    public class GetPastCoursesService : IGetPastCoursesService
    {
        private readonly IGetPastCourseDataRetrieverService _getPastCourseDataRetrieverService;

        public GetPastCoursesService(IGetPastCourseDataRetrieverService getPastCourseDataRetrieverService)
        {
            _getPastCourseDataRetrieverService = getPastCourseDataRetrieverService;
        }
        public IEnumerable<PastCourse> GetPastCourses(GetPastCoursesParams getPastCoursesParams)
        {
            if(getPastCoursesParams == null)
            {
                return null;
            }
            try
            {
                //Get all CoursesTaken associated with the student id.
                //Join with the pastcourse table to get full description and display order
                List<PastCourse> courses = _getPastCourseDataRetrieverService.GetPastCourses(getPastCoursesParams.StudentId);
                List<PastCourse> orderedCourses = courses.OrderBy(order => order.DisplayOrder).ToList();
                return orderedCourses;
            }
            catch
            {
                //If it fails at anytime, return null
                return null;
            }
        }
    }
}
