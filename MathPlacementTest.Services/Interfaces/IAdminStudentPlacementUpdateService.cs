﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public interface IAdminStudentPlacementUpdateService
    {
        public AdminUpdateStudentPlacementView UpdateStudentPlacement(AdminUpdateStudentPlacementParams updateStudentPlacementParams);
    }
}
