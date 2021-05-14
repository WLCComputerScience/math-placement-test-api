using System;
using System.Collections.Generic;
using System.Text;
using MathPlacementTest.Data;

namespace MathPlacementTest.Services
{
    public interface IInfoGetPastCoursesDataFetcher
    {
        public IEnumerable<InfoPastCourse> GetPastCourses();
    }
}
