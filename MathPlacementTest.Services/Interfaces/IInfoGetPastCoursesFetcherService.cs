﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public interface IInfoGetPastCoursesFetcherService
    {
        public PastCoursesView GetPastCourses();
    }
}
