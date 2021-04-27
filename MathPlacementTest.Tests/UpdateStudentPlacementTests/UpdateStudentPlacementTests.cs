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


            //Assert

        }

        [Fact]
        public void updateStudentPlacement_GivenNullChosenClass_ReturnNull()
        {
            //Act


            //Assert

        }

        [Fact]
        public void updateStudentPlacement_GivenEmptyChosenClass_ReturnNull()
        {
            //Act


            //Assert

        }
    }
}
