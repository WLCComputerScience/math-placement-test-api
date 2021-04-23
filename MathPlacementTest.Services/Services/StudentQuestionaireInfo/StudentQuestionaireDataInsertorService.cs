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
            studentToUpdate.DesiredClass = studentQuestionaireInfoParams.DesiredClass;
            studentToUpdate.MathInLastYear = studentQuestionaireInfoParams.HadMathInLastYear;
            studentToUpdate.MostAdvancedClass = studentQuestionaireInfoParams.AdvancedCourse;
            studentToUpdate.AdvancedClassGrade = studentQuestionaireInfoParams.GradeInAdvancedCourse;
            _dbContext.SaveChanges();

            foreach (var pastCourse in studentQuestionaireInfoParams.CoursesTaken)
            {
                var courseTaken = new CourseTaken() { 
                    PastCourseId = pastCourse.PastCourseId, 
                    StudentId = studentQuestionaireInfoParams.StudentId };
                _dbContext.CoursesTaken.Add(courseTaken);
                _dbContext.SaveChanges();
            }
            return true;
        }
    }
}
