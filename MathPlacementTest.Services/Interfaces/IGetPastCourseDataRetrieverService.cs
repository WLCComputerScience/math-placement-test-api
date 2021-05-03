using System;
using System.Collections.Generic;
using System.Text;
using MathPlacementTest.Services.Objects.Student;
using MathPlacementTest.Services.Objects.Test;
using MathPlacementTest.Data;
using PastCourse = MathPlacementTest.Services.Objects.Courses.PastCourse;

namespace MathPlacementTest.Services
{
    public interface IGetPastCourseDataRetrieverService
    {
        List<PastCourse> GetPastCourses(long studentId);
    }
}
