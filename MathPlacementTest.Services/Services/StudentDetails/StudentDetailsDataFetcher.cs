using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentDetailsDataFetcher : IStudentDetailsDataFetcher
    {
        private readonly MathTestDbContext _dbContext;

        public StudentDetailsDataFetcher(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student GetStudent(int studentId)
        {
            var student = _dbContext.Students.Where(p => p.StudentId == studentId).FirstOrDefault();
            return student;
        }

        public string GetTestName(int studentId)
        {
            var studentsWithTests = (from s in _dbContext.Students
                                     where s.StudentId == studentId
                                     join t in _dbContext.Tests
                                     on s.TestTaken equals t.TestId
                                     select new
                                     {
                                         Title = t.Title
                                     }
                                     ).FirstOrDefault();

            if (studentsWithTests == null)
            {
                return "No TestTaken";
            }

            return studentsWithTests.Title;
        }

        public IEnumerable<StudentAnswers> GetStudentAnswers(int studentId)
        {
            var answersToInput = new List<StudentAnswers>();

            var studentsAnswersWithCorrectAnswer = (from s in _dbContext.StudentAnswers
                                                    where s.StudentId == studentId
                                                    join q in _dbContext.Questions
                                                    on s.QuestionId equals q.QuestionId
                                                    select new
                                                    {
                                                        QuestionId = q.QuestionId,
                                                        CorrectAnswer = q.CorrectAnswer,
                                                        StudentsAnswer = s.StudentsAnswer
                                                    }
                                                    ).ToList();

            foreach (var info in studentsAnswersWithCorrectAnswer)
            {
                StudentAnswers studentAnswersUpdated = new StudentAnswers()
                {
                    QuestionId = info.QuestionId,
                    CorrectAnswer = info.CorrectAnswer,
                    StudentsAnswer = info.StudentsAnswer
                };
                answersToInput.Add(studentAnswersUpdated);
            }
            return answersToInput;
        }
    }
}
