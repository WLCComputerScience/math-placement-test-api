using System;
using Xunit;
using MathPlacementTest.Services;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using MathPlacementTest.Services.Objects.Courses;
using MathPlacementTest.Services.Objects.Test;
using MathPlacementTest.Services.Objects.Student;
using System.Collections.Generic;

namespace MathPlacementTest.Tests
{
    public class GetPastCoursesTest
    {
        private IFixture fixture = new Fixture();

        public GetPastCoursesTest()
        {
            this.fixture.Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void GetPastCourses_GivenNullParams_ReturnNull()
        {
            //Act
            var service = fixture.Create<GetPastCoursesService>();
            var courses = service.GetPastCourses(null);

            courses.Should().BeNull();
        }

        [Fact]
        public void GetPastCourses_GivenInvalidParams_ReturnNullOrEmptyList()
        {
            //Arrange
            GetPastCoursesParams getPastCoursesParams = fixture.Create<GetPastCoursesParams>();

            //Return Empty list
            fixture.Freeze<Mock<IGetPastCourseDataRetrieverService>>()
                .Setup(mock => mock.GetPastCourses(It.IsAny<long>()))
                .Returns(new List<PastCourse>());
            //Act
            var service = fixture.Create<GetPastCoursesService>();
            var courses = service.GetPastCourses(getPastCoursesParams);

            courses.Should().BeNullOrEmpty();
        }

        [Fact]
        public void GetPastCourses_GivenValidParams_ReturnSortedCourses()
        {
            //Arrange
            GetPastCoursesParams getPastCoursesParams = fixture.Create<GetPastCoursesParams>();
            var pastCourseId1 = fixture.Create<long>();
            var pastCourseId2 = fixture.Create<long>();
            var pastCourseId3 = fixture.Create<long>();

            var des1 = fixture.Create<string>();
            var des2 = fixture.Create<string>();
            var des3 = fixture.Create<string>();

            List<PastCourse> coursesToReturn = new List<PastCourse>
            {
                new PastCourse() { PastCourseId = pastCourseId3, Description = des3, DisplayOrder = 3 },
                new PastCourse() { PastCourseId = pastCourseId1, Description = des1, DisplayOrder = 1 },
                new PastCourse() { PastCourseId = pastCourseId2, Description = des2, DisplayOrder = 2 }
            };
            List<PastCourse> sortedCourses = new List<PastCourse>
            {
                new PastCourse() { PastCourseId = pastCourseId1, Description = des1, DisplayOrder = 1 },
                new PastCourse() { PastCourseId = pastCourseId2, Description = des2, DisplayOrder = 2 },
                new PastCourse() { PastCourseId = pastCourseId3, Description = des3, DisplayOrder = 3 }
            };
            //Return Empty list
            fixture.Freeze<Mock<IGetPastCourseDataRetrieverService>>()
                .Setup(mock => mock.GetPastCourses(It.IsAny<long>()))
                .Returns(coursesToReturn);
            //Act
            var service = fixture.Create<GetPastCoursesService>();
            var courses = service.GetPastCourses(getPastCoursesParams);

            courses.Should().BeEquivalentTo(sortedCourses);
        }
    }
}
