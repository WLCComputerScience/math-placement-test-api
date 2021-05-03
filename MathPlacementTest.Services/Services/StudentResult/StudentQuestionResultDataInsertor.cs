using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Http;

namespace MathPlacementTest.Services
{
    public class StudentQuestionResultDataInsertor : IStudentQuestionResultDataInsertor
    {
        private readonly MathTestDbContext _dbContext;
        public StudentQuestionResultDataInsertor(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BooleanResponse InsertStudentQuestionResult(InsertStudentResultParams insertStudentResultParams)
        {
            var existingStudentAnswer = _dbContext.StudentAnswers.Where(x => x.StudentId == insertStudentResultParams.StudentId && x.QuestionId == insertStudentResultParams.QuestionId).FirstOrDefault();
            if (existingStudentAnswer != null)
            {
                return new BooleanResponse()
                {
                    IsSuccess = false,
                    Message = "Student has already answered this question."
                };
            }
            var studentAnswer = new StudentAnswer()
            {
                StudentId = insertStudentResultParams.StudentId,
                QuestionId = insertStudentResultParams.QuestionId,
                TimeRemaining = insertStudentResultParams.TimeRemaining,
                StudentsAnswer = insertStudentResultParams.Answer
            };
            _dbContext.StudentAnswers.Add(studentAnswer);
            _dbContext.SaveChanges();
            if (studentAnswer.TestQuestionId > -1)
            {
                return new BooleanResponse()
                {
                    IsSuccess = true,
                    Message = ""
                };
            }
            return new BooleanResponse()
            {
                IsSuccess = false,
                Message = "Error inserting student result"
            };             
        }
    }
}
