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
                TestId = 5
            };

            var testToReturn = fixture.Create<Test>();
            fixture.Freeze<Mock<ITestQuestionsDataFetcher>>()
                .Setup(mock => mock.GetTest(getQuestionsParams)) // choose an invalid testId
                .Returns(testToReturn);

            var questionsToReturn = fixture.CreateMany<Questions>();
            fixture.Freeze<Mock<ITestQuestionsDataFetcher>>()
                .Setup(mock => mock.GetQuestions(getQuestionsParams)) // choose an invalid testId
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
            var testQuestionView = service.GetTestQuestions(getQuestionsParams); // choose an invalid testId

            //Assert
            testQuestionView.Should().BeEquivalentTo(testQuestionViewToReturn);
        }

        [Fact]
        public void GetTestQustions_GivenTestId_ReturnTestQuestionView()
        {
            //Arrange
            GetQuestionsParams getQuestionsParams = new GetQuestionsParams
            {
                TestId = 1
            };

            var testToReturn = fixture.Create<Test>();
            fixture.Freeze<Mock<ITestQuestionsDataFetcher>>()
                .Setup(mock => mock.GetTest(getQuestionsParams)) // choose a valid testId
                .Returns(testToReturn);

            var questionsToReturn = fixture.CreateMany<Questions>();
            fixture.Freeze<Mock<ITestQuestionsDataFetcher>>()
                .Setup(mock => mock.GetQuestions(getQuestionsParams)) // choose a valid testId
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
            var testQuestionView = service.GetTestQuestions(getQuestionsParams); // choose a valid testId

            //Assert
            testQuestionView.Should().BeEquivalentTo(testQuestionViewToReturn);
        }
    }
}
