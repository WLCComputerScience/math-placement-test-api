using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class InfoGetPastCoursesFetcherService : IInfoGetPastCoursesFetcherService
    {
        private readonly IInfoGetPastCoursesDataFetcher _infoGetPastCoursesDataFetcher;

        public InfoGetPastCoursesFetcherService(IInfoGetPastCoursesDataFetcher infoGetPastCoursesDataFetcher)
        {
            _infoGetPastCoursesDataFetcher = infoGetPastCoursesDataFetcher;
        }

        public PastCoursesView GetPastCourses()
        {
            var pastCourses = _infoGetPastCoursesDataFetcher.GetPastCourses();

            PastCoursesView pastCoursesView = new PastCoursesView
            {
                pastCourse = pastCourses
            };

            return pastCoursesView;
        }
    }
}
