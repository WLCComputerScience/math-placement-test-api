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
            var testToReturn = fixture.Create<Test>();
            fixture.Freeze<Mock<ITestQuestionsDataFetcher>>()
                .Setup(mock => mock.GetTest(5)) // choose an invalid testId
                .Returns(testToReturn);

            var questionsToReturn = fixture.CreateMany<Questions>();
            fixture.Freeze<Mock<ITestQuestionsDataFetcher>>()
                .Setup(mock => mock.GetQuestions(5)) // choose an invalid testId
                .Returns(questionsToReturn);

            TestQuestionView testQuestionViewToReturn = new TestQuestionView()
            {
                TestId = testToReturn.TestId,
                Title = testToReturn.Title,
                TimeAllowed = testToReturn.TimeAllowed,
                questions = questionsToReturn
            };

            //Act
            var service = fixture.Create<ITestQuestionsFetcherService>();
            var testQuestionView = service.GetTestQuestions(5); // choose an invalid testId

            //Assert
            testQuestionView.Should().BeEquivalentTo(testQuestionViewToReturn);
        }

        [Fact]
        public void GetTestQustions_GivenTestId_ReturnTestQuestionView()
        {
            //Arrange
            var testToReturn = fixture.Create<Test>();
            fixture.Freeze<Mock<ITestQuestionsDataFetcher>>()
                .Setup(mock => mock.GetTest(1)) // choose a valid testId
                .Returns(testToReturn);

            var questionsToReturn = fixture.CreateMany<Questions>();
            fixture.Freeze<Mock<ITestQuestionsDataFetcher>>()
                .Setup(mock => mock.GetQuestions(1)) // choose a valid testId
                .Returns(questionsToReturn);

            TestQuestionView testQuestionViewToReturn = new TestQuestionView()
            {
                TestId = testToReturn.TestId,
                Title = testToReturn.Title,
                TimeAllowed = testToReturn.TimeAllowed,
                questions = questionsToReturn
            };

            //Act
            var service = fixture.Create<ITestQuestionsFetcherService>();
            var testQuestionView = service.GetTestQuestions(1); // choose a valid testId

            //Assert
            testQuestionView.Should().BeEquivalentTo(testQuestionViewToReturn);
        }
    }
}
