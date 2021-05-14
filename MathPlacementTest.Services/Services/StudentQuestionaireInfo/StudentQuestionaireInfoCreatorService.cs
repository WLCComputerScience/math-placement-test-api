using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MathPlacementTest.Services.Objects.Test;
using MathPlacementTest.Services.Objects.Student;

namespace MathPlacementTest.Services
{
    public class StudentQuestionaireInfoCreatorService: IStudentQuestionaireInfoCreatorService
    {
        private readonly IStudentQuestionaireDataInsertorService _dataInsertorService;

        public StudentQuestionaireInfoCreatorService(IStudentQuestionaireDataInsertorService dataInsertorService)
        {
            _dataInsertorService = dataInsertorService;
        }

        public TestInfo AddQuestionaireInfo(StudentQuestionaireInfoParams studentQuestionaireInfoParams)
        {
            //Create testToReturn immediately with invalid TestId
            //If something ever goes wrong we immediately return with the invalid TestId
            var testToReturn = new TestInfo() { TestId = -1 };

            if (studentQuestionaireInfoParams == null)
            {
                return testToReturn;
            }
            else if (String.IsNullOrEmpty(studentQuestionaireInfoParams.AdvancedCourse) || 
                String.IsNullOrEmpty(studentQuestionaireInfoParams.DesiredClass) ||
                String.IsNullOrEmpty(studentQuestionaireInfoParams.GradeInAdvancedCourse))
            {
                return testToReturn;
            }

            var success = _dataInsertorService.AddQuestionaireData(studentQuestionaireInfoParams);

            if (!success)
            {
                //If database fails to save, return invalid test immediately
                return testToReturn;
            }

            //Return correct TestId
            if(studentQuestionaireInfoParams.CoursesTaken.Any(course => course.PastCourseId == 3))
            {
                //Give calc2 test if calc2 in past courses
                testToReturn.TestId = 4;
            }
            else if(studentQuestionaireInfoParams.CoursesTaken.Any(course => course.PastCourseId == 2))
            {
                //give calc1 test if calc1 in past courses
                testToReturn.TestId = 3;
            }
            else if (studentQuestionaireInfoParams.CoursesTaken.Any(course => course.PastCourseId == 1))
            {
                //give trig test if trig in past courses
                testToReturn.TestId = 2;
            }
            else if (studentQuestionaireInfoParams.CoursesTaken.Any(course => course.PastCourseId == 4))
            {
                //None of the above is tested, check DesiredCourse to give appropriate test
                switch (studentQuestionaireInfoParams.DesiredClass)
                {
                    case "Calculus 3":
                        testToReturn.TestId = 4;
                        break;
                    case "Calculus 2":
                        testToReturn.TestId = 3;
                        break;
                    case "Calculus 1":
                        testToReturn.TestId = 3;
                        break;
                    case "Trigonometry":
                        testToReturn.TestId = 2;
                        break;
                    case "Elementary Statistics":
                        testToReturn.TestId = 1;
                        break;
                }
            }

            //Add TestTaken to database after we determine what it is
            success = _dataInsertorService.AddTestTakenData(studentQuestionaireInfoParams ,testToReturn);

            if (!success)
            {
                //If database fails to save, return invalid test
                testToReturn.TestId = -1;
                return testToReturn;
            }

            return testToReturn;
        }
    }
}
