using System;
using Xunit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using MathPlacementTest.Services;

namespace MathPlacementTest.Tests
{
    public class TestQuestionsDataFetcherTest
    {
        private IFixture fixture = new Fixture();
        public TestQuestionsDataFetcherTest()
        {
            this.fixture.Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void GetTest_GivenInvalidTestId_ReturnNull()
        {
            //Act
            var service = fixture.Create<TestQuestionsDataFetcher>();
            var testQuestionView = service.GetTest(-1);

            //Assert
            testQuestionView.Should().BeNull();
        }

        [Fact]
        public void GetTest_GivenTestId_ReturnTest()
        {
            //Act
            var service = fixture.Create<TestQuestionsDataFetcher>();
            var testQuestionView = service.GetTest(-1);

            //Assert
            testQuestionView.Should();
        }

        [Fact]
        public void GetQuestions_GivenInvalidTestId_ReturnNull()
        {
            //Act
            var service = fixture.Create<TestQuestionsDataFetcher>();
            var testQuestionView = service.GetQuestions(-1);

            //Assert
            testQuestionView.Should().BeNull();
        }

        [Fact]
        public void GetTest_GivenTestId_ReturnQuestions()
        {
            //Act
            var service = fixture.Create<TestQuestionsDataFetcher>();
            var testQuestionView = service.GetTest(-1);

            //Assert
            testQuestionView.Should();
        }
    }
}
