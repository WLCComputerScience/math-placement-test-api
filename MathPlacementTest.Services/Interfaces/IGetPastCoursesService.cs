using System;
using System.Collections.Generic;
using System.Text;
using MathPlacementTest.Services.Objects.Courses;
using MathPlacementTest.Services.Objects.Student;

namespace MathPlacementTest.Services
{
    public interface IGetPastCoursesService
    {
        IEnumerable<PastCourse> GetPastCourses(GetPastCoursesParams getPastCoursesParams);
    }
}
