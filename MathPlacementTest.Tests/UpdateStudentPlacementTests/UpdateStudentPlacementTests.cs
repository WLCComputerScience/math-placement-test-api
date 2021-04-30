using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using MathPlacementTest;
using MathPlacementTest.Services;

namespace MathPlacementTest.Tests
{
    public class UpdateStudentPlacementTests
    {
        private IFixture fixture = new Fixture();

        public UpdateStudentPlacementTests()
        {
            this.fixture.Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void updateStudentPlacement_GivenZeroStudentId_ReturnNull()
        {
            //Act
            var service = fixture.Create<AdminStudentPlacementUpdateService>();
            var studentPlacementParams = new AdminUpdateStudentPlacementParams
            {
                StudentId = 0,
                ChosenClass = fixture.Create<string>()
            };
            var updatedStudentPlacement = service.updateStudentPlacement(studentPlacementParams);

            //Assert
            updatedStudentPlacement.Should().BeNull();
        }

        [Fact]
        public void updateStudentPlacement_GivenNegativeStudentId_ReturnNull()
        {
            //Act
            var service = fixture.Create<AdminStudentPlacementUpdateService>();
            var studentPlacementParams = new AdminUpdateStudentPlacementParams
            {
                StudentId = -1,
                ChosenClass = fixture.Create<string>()
            };
            var updatedStudentPlacement = service.updateStudentPlacement(studentPlacementParams);

            //Assert
            updatedStudentPlacement.Should().BeNull();
        }

        [Fact]
        public void updateStudentPlacement_GivenNullChosenClass_ReturnNull()
        {
            //Act
            var service = fixture.Create<AdminStudentPlacementUpdateService>();
            var studentPlacementParams = new AdminUpdateStudentPlacementParams
            {
                StudentId = fixture.Create<int>(),
                ChosenClass = null
            };
            var updatedStudentPlacement = service.updateStudentPlacement(studentPlacementParams);

            //Assert
            updatedStudentPlacement.Should().BeNull();
        }

        [Fact]
        public void updateStudentPlacement_GivenEmptyChosenClass_ReturnNull()
        {
            //Act
            var service = fixture.Create<AdminStudentPlacementUpdateService>();
            var studentPlacementParams = new AdminUpdateStudentPlacementParams
            {
                StudentId = fixture.Create<int>(),
                ChosenClass = ""
            };
            var updatedStudentPlacement = service.updateStudentPlacement(studentPlacementParams);

            //Assert
            updatedStudentPlacement.Should().BeNull();
        }
    }
}
