using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public interface IAdminUpdateStudentPlacement
    {
        public AdminUpdateStudentPlacementView updateStudentPlacement(AdminUpdateStudentPlacementParams updateStudentPlacementParams);
    }
}
