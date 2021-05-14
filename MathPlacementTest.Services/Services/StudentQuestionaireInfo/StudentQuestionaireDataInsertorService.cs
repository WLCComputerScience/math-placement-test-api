using MathPlacementTest.Services.Objects.Student;
using MathPlacementTest.Services.Objects.Test;
using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MathPlacementTest.Services
{
    public class StudentQuestionaireDataInsertorService : IStudentQuestionaireDataInsertorService
    {
        private readonly MathTestDbContext _dbContext;

        public StudentQuestionaireDataInsertorService(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddQuestionaireData(StudentQuestionaireInfoParams studentQuestionaireInfoParams)
        {
           var studentToUpdate = _dbContext.Students.Where(s => s.StudentId == studentQuestionaireInfoParams.StudentId).FirstOrDefault();
            if(studentToUpdate == null)
            {
                return false;
            }
            try
            {
                var coursesTakenStudent = _dbContext.CoursesTaken.Where(s => s.StudentId == studentQuestionaireInfoParams.StudentId).FirstOrDefault();
                if (coursesTakenStudent == null)
                {
                    //If student exists in coursesTaken, we just ignore
                    studentToUpdate.DesiredClass = studentQuestionaireInfoParams.DesiredClass;
                    studentToUpdate.MathInLastYear = studentQuestionaireInfoParams.HadMathInLastYear;
                    studentToUpdate.MostAdvancedClass = studentQuestionaireInfoParams.AdvancedCourse;
                    studentToUpdate.MostAdvancedClassGrade = studentQuestionaireInfoParams.GradeInAdvancedCourse;
                    _dbContext.SaveChanges();

                    // only update courses taken
                    foreach (var pastCourse in studentQuestionaireInfoParams.CoursesTaken)
                    {
                        var courseTaken = new CourseTaken()
                        {
                            PastCourseId = pastCourse.PastCourseId,
                            StudentId = studentQuestionaireInfoParams.StudentId
                        };
                        _dbContext.CoursesTaken.Add(courseTaken);
                        _dbContext.SaveChanges();
                    }
                    return true;
                }
                else
                {
                    //Return false if student already exists in coursesTaken
                    return false;
                }
            }
            catch
            {
                // If it fails at any point, return false
                return false;
            }
        }

        public bool AddTestTakenData(StudentQuestionaireInfoParams studentQuestionaireInfoParams, TestInfo testInfo)
        {
            if(testInfo == null || studentQuestionaireInfoParams == null)
            {
                return false;
            }

            var studentToUpdate = _dbContext.Students.Where(s => s.StudentId == studentQuestionaireInfoParams.StudentId).FirstOrDefault();
            if (studentToUpdate == null)
            {
                return false;
            }
            try
            {
                studentToUpdate.TestTaken = testInfo.TestId;
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
