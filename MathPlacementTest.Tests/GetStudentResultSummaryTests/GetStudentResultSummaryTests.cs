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

namespace MathPlacementTest.Test
{
    public class GetStudentResultSummaryTests
    {
        private IFixture fixture = new Fixture();

        public GetStudentResultSummaryTests()
        {
            this.fixture.Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void GetStudentResultSummary_GivenNegativeStudentId_ReturnNull()
        {
            //Act
            var service = fixture.Create<IGetStudentResultSummary>();
            var studentResultSummaryParams = new GetStudentResultSummaryParams
            {
                StudentId = -1
            };
            var GetStudentResultSummary = service.GetStudentResultSummary(studentResultSummaryParams);

            //Assert
            GetStudentResultSummary.Should().BeNull();
        }

        [Fact]
        public void GetStudentResultSummary_GivenZeroStudentId_ReturnNull()
        {
            //Act
            var service = fixture.Create<IGetStudentResultSummary>();
            var studentResultSummaryParams = new GetStudentResultSummaryParams
            {
                StudentId = 0
            };
            var GetStudentResultSummary = service.GetStudentResultSummary(studentResultSummaryParams);

            //Assert
            GetStudentResultSummary.Should().BeNull();
        }
    }
}
