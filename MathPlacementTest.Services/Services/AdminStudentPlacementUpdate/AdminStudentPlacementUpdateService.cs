﻿using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class AdminStudentPlacementUpdateService : IAdminStudentPlacementUpdateService
    {
        private readonly MathTestDbContext _dbcontext;
        public AdminStudentPlacementUpdateService(MathTestDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public AdminUpdateStudentPlacementView UpdateStudentPlacement(AdminUpdateStudentPlacementParams updateStudentPlacementParams)
        {
            if(updateStudentPlacementParams.StudentId == 0 || updateStudentPlacementParams.StudentId < 0)
            {
                return null;
            }
            else if (string.IsNullOrEmpty(updateStudentPlacementParams.ChosenClass))
            {
                return null;
            }

            using(var context = _dbcontext)
            {
                var studentToUpdate = context.Students.Where(s => s.StudentId == updateStudentPlacementParams.StudentId).FirstOrDefault();

                if(studentToUpdate != null)
                {
                    studentToUpdate.ClassChosen = updateStudentPlacementParams.ChosenClass;
                    context.SaveChanges();

                    var updateStudentPlacementView = new AdminUpdateStudentPlacementView
                    {
                        UpdateSuccess = true,
                        ErrorMessage = "No errors"
                    };

                    return updateStudentPlacementView;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
