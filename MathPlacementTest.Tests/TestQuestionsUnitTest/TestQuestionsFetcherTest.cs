using System;
using Xunit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using MathPlacementTest.Services;

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
            var testQuestionViewToReturn = fixture.Create<TestQuestionView>();
            fixture.Freeze<Mock<ITestQuestionsFetcherService>>()
                .Setup(mock => mock.)

            //Act
            var service = fixture.Create<TestQuestionsFetcherService>();
            var testQuestionView = service.GetTestQuestions(fixture.Create<int>());

            //Assert
            testQuestionView.Should().BeEquivalentTo(testQuestionViewToReturn);
        }

        [Fact]
        public void GetTestQustions_GivenTestId_ReturnTestQuestionView()
        {
            //Arrange
            var testQuestionViewToReturn = fixture.Create<Test>();
            fixture.Freeze<Mock<ITestQuestionsDataFetcher>>()
                .Setup(mock => mock.GetTest(It.IsAny<int>())
                .Returns(testQuestionViewToReturn);

            //Act
            var service = fixture.Create<TestQuestionsFetcherService>();
            var testQuestionView = service.GetTestQuestions(fixture.Create<int>());

            //Assert
            testQuestionView.Should().BeEquivalentTo(testQuestionViewToReturn);
        }
    }
}
