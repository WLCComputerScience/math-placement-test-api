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
    public class TestQuestionsFetcherTest
    {
        private IFixture fixture = new Fixture();
        public TestQuestionsFetcherTest()
        {
            this.fixture.Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void GetTestQuestions_GivenInvalidTestId_ReturnNull()
        {
            //Arrange
            GetQuestionsParams getQuestionsParams = new GetQuestionsParams
            {
                TestId = -1
            };

            //Act
            var service = fixture.Create<TestQuestionsFetcherService>();
            var testQuestionView = service.GetTestQuestions(getQuestionsParams); // choose an invalid testId

            //Assert
            testQuestionView.Should().BeNull();
        }
    }
}
