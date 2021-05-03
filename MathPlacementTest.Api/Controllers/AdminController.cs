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
        private readonly IAdminStudentPlacementUpdateService _adminUpdateStudentPlacement;
        public AdminController(IAdminStudentPlacementUpdateService adminUpdateStudentPlacement)
        {
            _adminUpdateStudentPlacement = adminUpdateStudentPlacement;
        }

        [HttpPost]
        [Route("Update")]
        public AdminUpdateStudentPlacementView UpdateStudentPlacement([FromForm] AdminUpdateStudentPlacementParams updateStudentPlacementParams)
        {
            return _adminUpdateStudentPlacement.UpdateStudentPlacement(updateStudentPlacementParams);
        }
    }
}
