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
                StudentId = -1
            };

            //Act
            var service = fixture.Create<StudentDetailsFetcherService>();
            var studentDetailsView = service.GetStudentDetails(getStudentParams); // choose an invalid studentId

            //Assert
            studentDetailsView.Should().BeNull();
        }
    }
}
