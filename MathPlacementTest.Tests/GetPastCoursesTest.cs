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
    }
}
