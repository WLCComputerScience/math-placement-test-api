using System;
using Xunit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using MathPlacementTest.Services;
using MathPlacementTest.Data;

namespace MathPlacementTest.Tests
{
    public class StudentDetailsFetcherTest
    {
        private IFixture fixture = new Fixture();
        public StudentDetailsFetcherTest()
        {
            this.fixture.Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void GetStudentDetails_GivenInvalidStudentId_ReturnNull()
        {
            //Arrange
            GetStudentParams getStudentParams = new GetStudentParams
            {
                StudentId = 100
            };

            var studentToReturn = fixture.Create<Student>();
            fixture.Freeze<Mock<IStudentDetailsDataFetcher>>()
                .Setup(mock => mock.GetStudent(getStudentParams)) // choose an invalid studentId
                .Returns(studentToReturn);

            var studentAnswersToReturn = fixture.CreateMany<StudentAnswers>();
            fixture.Freeze<Mock<IStudentDetailsDataFetcher>>()
                .Setup(mock => mock.GetStudentAnswers(getStudentParams)) // choose an invalid studentId
                .Returns(studentAnswersToReturn);

            var titleToReturn = fixture.Create<String>();
            fixture.Freeze<Mock<IStudentDetailsDataFetcher>>()
                .Setup(mock => mock.GetTestName(getStudentParams)) // choose an invalid studentId
                .Returns(titleToReturn);

            StudentInfo studentInfo = new StudentInfo()
            {
                FirstName = studentToReturn.FirstName,
                LastName = studentToReturn.LastName,
                WLCId = studentToReturn.WLCId,
                InsertedOn = studentToReturn.InsertedOn,
                MostAdvancedClass = studentToReturn.MostAdvancedClass,
                AdvancedClassGrade = studentToReturn.MostAdvancedClassGrade,
                DesiredClass = studentToReturn.DesiredClass,
                MathInLastYear = studentToReturn.MathInLastYear,
                ChosenClass = studentToReturn.ClassChosen
            };

            StudentDetailsView studentDetailsViewToReturn = new StudentDetailsView()
            {
                Student = studentInfo,
                Title = titleToReturn,
                studentAnswers = studentAnswersToReturn
            };

            //Act
            var service = fixture.Create<IStudentDetailsFetcherService>();
            var studentDetailsView = service.GetStudentDetails(getStudentParams); // choose an invalid studentId

            //Assert
            studentDetailsView.Should().BeEquivalentTo(studentDetailsViewToReturn);
        }

        [Fact]
        public void GetStudentDetails_GivenStudentId_ReturnResultView()
        {
            //Arrange
            GetStudentParams getStudentParams = new GetStudentParams
            {
                StudentId = 100
            };

            var studentToReturn = fixture.Create<Student>();
            fixture.Freeze<Mock<IStudentDetailsDataFetcher>>()
                .Setup(mock => mock.GetStudent(getStudentParams)) // choose a valid studentId
                .Returns(studentToReturn);

            var studentAnswersToReturn = fixture.CreateMany<StudentAnswers>();
            fixture.Freeze<Mock<IStudentDetailsDataFetcher>>()
                .Setup(mock => mock.GetStudentAnswers(getStudentParams)) // choose a valid studentId
                .Returns(studentAnswersToReturn);

            var titleToReturn = fixture.Create<String>();
            fixture.Freeze<Mock<IStudentDetailsDataFetcher>>()
                .Setup(mock => mock.GetTestName(getStudentParams)) // choose a valid studentId
                .Returns(titleToReturn);

            StudentInfo studentInfo = new StudentInfo()
            {
                FirstName = studentToReturn.FirstName,
                LastName = studentToReturn.LastName,
                WLCId = studentToReturn.WLCId,
                InsertedOn = studentToReturn.InsertedOn,
                MostAdvancedClass = studentToReturn.MostAdvancedClass,
                AdvancedClassGrade = studentToReturn.MostAdvancedClassGrade,
                DesiredClass = studentToReturn.DesiredClass,
                MathInLastYear = studentToReturn.MathInLastYear,
                ChosenClass = studentToReturn.ClassChosen
            };

            StudentDetailsView studentDetailsViewToReturn = new StudentDetailsView()
            {
                Student = studentInfo,
                Title = titleToReturn,
                studentAnswers = studentAnswersToReturn
            };

            //Act
            var service = fixture.Create<IStudentDetailsFetcherService>();
            var studentDetailsView = service.GetStudentDetails(getStudentParams); // choose a valid studentId

            //Assert
            studentDetailsView.Should().BeEquivalentTo(studentDetailsViewToReturn);
        }
    }
}
