using System;
using Xunit;
using MathPlacementTest.Services;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using MathPlacementTest.Services.Objects.Test;
using MathPlacementTest.Services.Objects.Student;

namespace MathPlacementTest.Tests
{
    public class StudentInfoCreatorTest
    {
        private IFixture fixture = new Fixture();

        public StudentInfoCreatorTest()
        {
            this.fixture.Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void AddQuestionaireData_GivenNullParams_ReturnInvalidTestId()
        {
            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(null);

            //Assert
            testInfo.TestId.Should().Be(-1);

        }

        [Fact]
        public void AddQuestionaireData_GivenEmptyPaCourses_ReturnInvalidTestId()
        {
            //Arrange
            var advancedCourse = fixture.Create<string>();
            var desiredClass = fixture.Create<string>();
            var gradeInAdvancedCourse = fixture.Create<string>();
            var hadMathInLasteYear = fixture.Create<bool>();
            var studentId = fixture.Create<long>();
            var testTestInfo = new StudentQuestionaireInfoParams() {
                AdvancedCourse = advancedCourse,
                CoursesTaken = { },
                DesiredClass = desiredClass,
                GradeInAdvancedCourse = gradeInAdvancedCourse, HadMathInLastYear = hadMathInLasteYear,
                StudentId = studentId
            };

            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(null);

            //Assert
            testInfo.TestId.Should().Be(-1);
        }

    }
}
