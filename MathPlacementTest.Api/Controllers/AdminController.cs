using MathPlacementTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlacementTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IAdminUpdateStudentPlacement _adminUpdateStudentPlacement;
        public AdminController(IAdminUpdateStudentPlacement adminUpdateStudentPlacement)
        {
            _adminUpdateStudentPlacement = adminUpdateStudentPlacement;
        }

        [HttpPost]
        [Route("Update")]

        public AdminUpdateStudentPlacementView updateStudentPlacement(AdminUpdateStudentPlacementParams updateStudentPlacementParams)
        {
            return _adminUpdateStudentPlacement.updateStudentPlacement(updateStudentPlacementParams);
        }
    }
}
