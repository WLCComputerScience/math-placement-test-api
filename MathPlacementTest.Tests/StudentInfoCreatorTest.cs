using System;
using Xunit;
using MathPlacementTest.Services;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using MathPlacementTest.Services.Objects.Courses;
using MathPlacementTest.Services.Objects.Test;
using MathPlacementTest.Services.Objects.Student;
using System.Collections.Generic;

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
        public void AddQuestionaireData_GivenEmptyAdvancedCourse_ReturnInvalidTestId()
        {
            //Arrange
            var advancedCourse = "";
            var desiredClass = fixture.Create<string>();
            var gradeInAdvancedCourse = fixture.Create<string>();
            var hadMathInLastYear = fixture.Create<bool>();
            var studentId = fixture.Create<long>();
            IEnumerable<PastCourse> coursesTaken = new List<PastCourse>() {
                new PastCourse() { PastCourseId = fixture.Create<long>(), Description = fixture.Create<string>() },
                new PastCourse() { PastCourseId = fixture.Create<long>(), Description = fixture.Create<string>() }
            };
            var testTestInfo = new StudentQuestionaireInfoParams() {
                AdvancedCourse = advancedCourse,
                CoursesTaken = coursesTaken,
                DesiredClass = desiredClass,
                GradeInAdvancedCourse = gradeInAdvancedCourse, 
                HadMathInLastYear = hadMathInLastYear,
                StudentId = studentId
            };

            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(testTestInfo);

            //Assert
            testInfo.TestId.Should().Be(-1);
        }

        [Fact]
        public void AddQuestionaireData_GivenEmptyDesiredClass_ReturnInvalidTestId()
        {
            //Arrange
            var advancedCourse = fixture.Create<string>();
            var desiredClass = "";
            var gradeInAdvancedCourse = fixture.Create<string>();
            var hadMathInLastYear = fixture.Create<bool>();
            var studentId = fixture.Create<long>();
            IEnumerable<PastCourse> coursesTaken = new List<PastCourse>() {
                new PastCourse() { PastCourseId = fixture.Create<long>(), Description = fixture.Create<string>() },
                new PastCourse() { PastCourseId = fixture.Create<long>(), Description = fixture.Create<string>() }
            };
            var testTestInfo = new StudentQuestionaireInfoParams()
            {
                AdvancedCourse = advancedCourse,
                CoursesTaken = coursesTaken,
                DesiredClass = desiredClass,
                GradeInAdvancedCourse = gradeInAdvancedCourse,
                HadMathInLastYear = hadMathInLastYear,
                StudentId = studentId
            };

            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(testTestInfo);

            //Assert
            testInfo.TestId.Should().Be(-1);
        }

        [Fact]
        public void AddQuestionaireData_GivenEmptyGradeInAdvancedClass_ReturnInvalidTestId()
        {
            //Arrange
            var advancedCourse = fixture.Create<string>();
            var desiredClass = fixture.Create<string>();
            var gradeInAdvancedCourse = "";
            var hadMathInLastYear = fixture.Create<bool>();
            var studentId = fixture.Create<long>();
            IEnumerable<PastCourse> coursesTaken = new List<PastCourse>() {
                new PastCourse() { PastCourseId = fixture.Create<long>(), Description = fixture.Create<string>() },
                new PastCourse() { PastCourseId = fixture.Create<long>(), Description = fixture.Create<string>() }
            };
            var testTestInfo = new StudentQuestionaireInfoParams()
            {
                AdvancedCourse = advancedCourse,
                CoursesTaken = coursesTaken,
                DesiredClass = desiredClass,
                GradeInAdvancedCourse = gradeInAdvancedCourse,
                HadMathInLastYear = hadMathInLastYear,
                StudentId = studentId
            };

            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(testTestInfo);

            //Assert
            testInfo.TestId.Should().Be(-1);
        }

        [Fact]
        public void AddQuestionaireData_GivenValidParamsPastCourseId3_ReturnValidTestId4()
        {
            //Highest PastCourseID is what is considered
            //Arrange
            var advancedCourse = fixture.Create<string>();
            var desiredClass = fixture.Create<string>();
            var gradeInAdvancedCourse = fixture.Create<string>();
            var hadMathInLastYear = fixture.Create<bool>();
            var studentId = fixture.Create<long>();
            IEnumerable<PastCourse> coursesTaken = new List<PastCourse>() {
                new PastCourse() { PastCourseId = 3, Description = fixture.Create<string>() },
                new PastCourse() { PastCourseId = 2, Description = fixture.Create<string>() }
            };
            var testTestInfo = new StudentQuestionaireInfoParams()
            {
                AdvancedCourse = advancedCourse,
                CoursesTaken = coursesTaken,
                DesiredClass = desiredClass,
                GradeInAdvancedCourse = gradeInAdvancedCourse,
                HadMathInLastYear = hadMathInLastYear,
                StudentId = studentId
            };

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddQuestionaireData(It.IsAny<StudentQuestionaireInfoParams>()))
                .Returns(true);

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddTestTakenData(It.IsAny<StudentQuestionaireInfoParams>(), It.IsAny<TestInfo>()))
                .Returns(true);

            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(testTestInfo);

            //Assert
            testInfo.TestId.Should().Be(4);
        }

        [Fact]
        public void AddQuestionaireData_GivenValidParamsPastCourseId2_ReturnValidTestId3()
        {
            //Highest PastCourseID is what is considered
            //Arrange
            var advancedCourse = fixture.Create<string>();
            var desiredClass = fixture.Create<string>();
            var gradeInAdvancedCourse = fixture.Create<string>();
            var hadMathInLastYear = fixture.Create<bool>();
            var studentId = fixture.Create<long>();
            IEnumerable<PastCourse> coursesTaken = new List<PastCourse>() {
                new PastCourse() { PastCourseId = 2, Description = fixture.Create<string>() },
                new PastCourse() { PastCourseId = 1, Description = fixture.Create<string>() }
            };
            var testTestInfo = new StudentQuestionaireInfoParams()
            {
                AdvancedCourse = advancedCourse,
                CoursesTaken = coursesTaken,
                DesiredClass = desiredClass,
                GradeInAdvancedCourse = gradeInAdvancedCourse,
                HadMathInLastYear = hadMathInLastYear,
                StudentId = studentId
            };

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddQuestionaireData(It.IsAny<StudentQuestionaireInfoParams>()))
                .Returns(true);

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddTestTakenData(It.IsAny<StudentQuestionaireInfoParams>(), It.IsAny<TestInfo>()))
                .Returns(true);

            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(testTestInfo);

            //Assert
            testInfo.TestId.Should().Be(3);
        }

        [Fact]
        public void AddQuestionaireData_GivenValidParamsPastCourseId1_ReturnValidTestId2()
        {
            //Highest PastCourseID is what is considered
            //Arrange
            var advancedCourse = fixture.Create<string>();
            var desiredClass = fixture.Create<string>();
            var gradeInAdvancedCourse = fixture.Create<string>();
            var hadMathInLastYear = fixture.Create<bool>();
            var studentId = fixture.Create<long>();
            IEnumerable<PastCourse> coursesTaken = new List<PastCourse>() {
                new PastCourse() { PastCourseId = 1, Description = fixture.Create<string>() }
            };
            var testTestInfo = new StudentQuestionaireInfoParams()
            {
                AdvancedCourse = advancedCourse,
                CoursesTaken = coursesTaken,
                DesiredClass = desiredClass,
                GradeInAdvancedCourse = gradeInAdvancedCourse,
                HadMathInLastYear = hadMathInLastYear,
                StudentId = studentId
            };

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddQuestionaireData(It.IsAny<StudentQuestionaireInfoParams>()))
                .Returns(true);

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddTestTakenData(It.IsAny<StudentQuestionaireInfoParams>(), It.IsAny<TestInfo>()))
                .Returns(true);

            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(testTestInfo);

            //Assert
            testInfo.TestId.Should().Be(2);
        }

        [Fact]
        public void AddQuestionaireData_GivenValidParamsPastCourseId1AndPastCourseId3_ReturnValidTestId4()
        {
            //Highest PastCourseID is what is considered
            //Arrange
            var advancedCourse = fixture.Create<string>();
            var desiredClass = fixture.Create<string>();
            var gradeInAdvancedCourse = fixture.Create<string>();
            var hadMathInLastYear = fixture.Create<bool>();
            var studentId = fixture.Create<long>();
            IEnumerable<PastCourse> coursesTaken = new List<PastCourse>() {
                new PastCourse() { PastCourseId = 1, Description = fixture.Create<string>() },
                new PastCourse() { PastCourseId = 3, Description = fixture.Create<string>() }
            };
            var testTestInfo = new StudentQuestionaireInfoParams()
            {
                AdvancedCourse = advancedCourse,
                CoursesTaken = coursesTaken,
                DesiredClass = desiredClass,
                GradeInAdvancedCourse = gradeInAdvancedCourse,
                HadMathInLastYear = hadMathInLastYear,
                StudentId = studentId
            };

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddQuestionaireData(It.IsAny<StudentQuestionaireInfoParams>()))
                .Returns(true);

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddTestTakenData(It.IsAny<StudentQuestionaireInfoParams>(), It.IsAny<TestInfo>()))
                .Returns(true);

            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(testTestInfo);

            //Assert
            testInfo.TestId.Should().Be(4);
        }

        [Fact]
        public void AddQuestionaireData_GivenValidParamsPastCourseId3AndPastCourseId1_ReturnValidTestId4()
        {
            //Highest PastCourseID is what is considered
            //Arrange
            var advancedCourse = fixture.Create<string>();
            var desiredClass = fixture.Create<string>();
            var gradeInAdvancedCourse = fixture.Create<string>();
            var hadMathInLastYear = fixture.Create<bool>();
            var studentId = fixture.Create<long>();
            IEnumerable<PastCourse> coursesTaken = new List<PastCourse>() {
                new PastCourse() { PastCourseId = 3, Description = fixture.Create<string>() },
                new PastCourse() { PastCourseId = 1, Description = fixture.Create<string>() }
            };
            var testTestInfo = new StudentQuestionaireInfoParams()
            {
                AdvancedCourse = advancedCourse,
                CoursesTaken = coursesTaken,
                DesiredClass = desiredClass,
                GradeInAdvancedCourse = gradeInAdvancedCourse,
                HadMathInLastYear = hadMathInLastYear,
                StudentId = studentId
            };

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddQuestionaireData(It.IsAny<StudentQuestionaireInfoParams>()))
                .Returns(true);

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddTestTakenData(It.IsAny<StudentQuestionaireInfoParams>(), It.IsAny<TestInfo>()))
                .Returns(true);

            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(testTestInfo);

            //Assert
            testInfo.TestId.Should().Be(4);
        }

        [Fact]
        public void AddQuestionaireData_GivenValidParamsPastCourseId4AndDesiredCourseCalc3_ReturnValidTestId4()
        {
            //Highest PastCourseID is what is considered
            //Arrange
            var advancedCourse = fixture.Create<string>();
            var desiredClass = "Calculus 3";
            var gradeInAdvancedCourse = fixture.Create<string>();
            var hadMathInLastYear = fixture.Create<bool>();
            var studentId = fixture.Create<long>();
            IEnumerable<PastCourse> coursesTaken = new List<PastCourse>() {
                new PastCourse() { PastCourseId = 4, Description = fixture.Create<string>() }
            };
            var testTestInfo = new StudentQuestionaireInfoParams()
            {
                AdvancedCourse = advancedCourse,
                CoursesTaken = coursesTaken,
                DesiredClass = desiredClass,
                GradeInAdvancedCourse = gradeInAdvancedCourse,
                HadMathInLastYear = hadMathInLastYear,
                StudentId = studentId
            };

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddQuestionaireData(It.IsAny<StudentQuestionaireInfoParams>()))
                .Returns(true);

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddTestTakenData(It.IsAny<StudentQuestionaireInfoParams>(), It.IsAny<TestInfo>()))
                .Returns(true);

            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(testTestInfo);

            //Assert
            testInfo.TestId.Should().Be(4);
        }

        [Fact]
        public void AddQuestionaireData_GivenValidParamsPastCourseId4AndDesiredCourseCalc2_ReturnValidTestId3()
        {
            //Highest PastCourseID is what is considered
            //Arrange
            var advancedCourse = fixture.Create<string>();
            var desiredClass = "Calculus 2";
            var gradeInAdvancedCourse = fixture.Create<string>();
            var hadMathInLastYear = fixture.Create<bool>();
            var studentId = fixture.Create<long>();
            IEnumerable<PastCourse> coursesTaken = new List<PastCourse>() {
                new PastCourse() { PastCourseId = 4, Description = fixture.Create<string>() }
            };
            var testTestInfo = new StudentQuestionaireInfoParams()
            {
                AdvancedCourse = advancedCourse,
                CoursesTaken = coursesTaken,
                DesiredClass = desiredClass,
                GradeInAdvancedCourse = gradeInAdvancedCourse,
                HadMathInLastYear = hadMathInLastYear,
                StudentId = studentId
            };

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddQuestionaireData(It.IsAny<StudentQuestionaireInfoParams>()))
                .Returns(true);

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddTestTakenData(It.IsAny<StudentQuestionaireInfoParams>(), It.IsAny<TestInfo>()))
                .Returns(true);

            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(testTestInfo);

            //Assert
            testInfo.TestId.Should().Be(3);
        }

        [Fact]
        public void AddQuestionaireData_GivenValidParamsPastCourseId4AndDesiredCourseCalc1_ReturnValidTestId3()
        {
            //Highest PastCourseID is what is considered
            //Arrange
            var advancedCourse = fixture.Create<string>();
            var desiredClass = "Calculus 1";
            var gradeInAdvancedCourse = fixture.Create<string>();
            var hadMathInLastYear = fixture.Create<bool>();
            var studentId = fixture.Create<long>();
            IEnumerable<PastCourse> coursesTaken = new List<PastCourse>() {
                new PastCourse() { PastCourseId = 4, Description = fixture.Create<string>() }
            };
            var testTestInfo = new StudentQuestionaireInfoParams()
            {
                AdvancedCourse = advancedCourse,
                CoursesTaken = coursesTaken,
                DesiredClass = desiredClass,
                GradeInAdvancedCourse = gradeInAdvancedCourse,
                HadMathInLastYear = hadMathInLastYear,
                StudentId = studentId
            };

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddQuestionaireData(It.IsAny<StudentQuestionaireInfoParams>()))
                .Returns(true);

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddTestTakenData(It.IsAny<StudentQuestionaireInfoParams>(), It.IsAny<TestInfo>()))
                .Returns(true);

            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(testTestInfo);

            //Assert
            testInfo.TestId.Should().Be(3);
        }

        [Fact]
        public void AddQuestionaireData_GivenValidParamsPastCourseId4AndDesiredCourseTrig_ReturnValidTestId2()
        {
            //Highest PastCourseID is what is considered
            //Arrange
            var advancedCourse = fixture.Create<string>();
            var desiredClass = "Trigonometry";
            var gradeInAdvancedCourse = fixture.Create<string>();
            var hadMathInLastYear = fixture.Create<bool>();
            var studentId = fixture.Create<long>();
            IEnumerable<PastCourse> coursesTaken = new List<PastCourse>() {
                new PastCourse() { PastCourseId = 4, Description = fixture.Create<string>() }
            };
            var testTestInfo = new StudentQuestionaireInfoParams()
            {
                AdvancedCourse = advancedCourse,
                CoursesTaken = coursesTaken,
                DesiredClass = desiredClass,
                GradeInAdvancedCourse = gradeInAdvancedCourse,
                HadMathInLastYear = hadMathInLastYear,
                StudentId = studentId
            };

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddQuestionaireData(It.IsAny<StudentQuestionaireInfoParams>()))
                .Returns(true);

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddTestTakenData(It.IsAny<StudentQuestionaireInfoParams>(), It.IsAny<TestInfo>()))
                .Returns(true);

            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(testTestInfo);

            //Assert
            testInfo.TestId.Should().Be(2);
        }

        [Fact]
        public void AddQuestionaireData_GivenValidParamsPastCourseId4AndDesiredCourseElemStats_ReturnValidTestId1()
        {
            //Highest PastCourseID is what is considered
            //Arrange
            var advancedCourse = fixture.Create<string>();
            var desiredClass = "Elementary Statistics";
            var gradeInAdvancedCourse = fixture.Create<string>();
            var hadMathInLastYear = fixture.Create<bool>();
            var studentId = fixture.Create<long>();
            IEnumerable<PastCourse> coursesTaken = new List<PastCourse>() {
                new PastCourse() { PastCourseId = 4, Description = fixture.Create<string>() }
            };
            var testTestInfo = new StudentQuestionaireInfoParams()
            {
                AdvancedCourse = advancedCourse,
                CoursesTaken = coursesTaken,
                DesiredClass = desiredClass,
                GradeInAdvancedCourse = gradeInAdvancedCourse,
                HadMathInLastYear = hadMathInLastYear,
                StudentId = studentId
            };

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddQuestionaireData(It.IsAny<StudentQuestionaireInfoParams>()))
                .Returns(true);

            fixture.Freeze<Mock<IStudentQuestionaireDataInsertorService>>()
                .Setup(mock => mock.AddTestTakenData(It.IsAny<StudentQuestionaireInfoParams>(), It.IsAny<TestInfo>()))
                .Returns(true);

            //Act
            var service = fixture.Create<StudentQuestionaireInfoCreatorService>();
            var testInfo = service.AddQuestionaireInfo(testTestInfo);

            //Assert
            testInfo.TestId.Should().Be(1);
        }
    }
}
