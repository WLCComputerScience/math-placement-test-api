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
    public class CreateStudentTests
    {
        private IFixture fixture = new Fixture();

        public CreateStudentTests()
        {
            this.fixture.Customize(new AutoMoqCustomization());
        }
        [Fact]
        public void CreateStudent_GivenEmptyFirstName_ReturnNegative1()
        {
            StudentCreateService createStudent = fixture.Create<StudentCreateService>();

            StudentCreateParams testParams = new StudentCreateParams
            {
                StudentFirstName = "",
                StudentLastName = fixture.Create<string>(),
                StudentWLCId = fixture.Create<int>()
            };

            var results = createStudent.CreateStudent(testParams);
            Assert.Equal(results.StudentId, -1);
        }
        [Fact]
        public void CreateStudent_GivenEmptyLastName_ReturnNegative1()
        {
            StudentCreateService createStudent = fixture.Create<StudentCreateService>();

            StudentCreateParams testParams = new StudentCreateParams
            {
                StudentFirstName = fixture.Create<string>(),
                StudentLastName = "",
                StudentWLCId = fixture.Create<int>()
            };
            var results = createStudent.CreateStudent(testParams);
            Assert.Equal(results.StudentId, -1);
        }

        [Fact]
        public void CreateStudent_GivenNullFirstName_ReturnNegative1()
        {
            StudentCreateService createStudent = fixture.Create<StudentCreateService>();

            StudentCreateParams testParams = new StudentCreateParams
            {
                StudentFirstName = null,
                StudentLastName = fixture.Create<string>(),
                StudentWLCId = fixture.Create<int>()
            };

            var results = createStudent.CreateStudent(testParams);
            Assert.Equal(results.StudentId, -1);
        }
        [Fact]
        public void CreateStudent_GivenNullLastName_ReturnNegative1()
        {
            StudentCreateService createStudent = fixture.Create<StudentCreateService>();

            StudentCreateParams testParams = new StudentCreateParams
            {
                StudentFirstName = fixture.Create<string>(),
                StudentLastName = null,
                StudentWLCId = fixture.Create<int>()
            };
            var results = createStudent.CreateStudent(testParams);
            Assert.Equal(results.StudentId, -1);
        }
        [Fact]
        public void CreateStudent_GivenNegativeStudentId_ReturnNegative1()
        {
            StudentCreateService createStudent = fixture.Create<StudentCreateService>();

            StudentCreateParams testParams = new StudentCreateParams
            {
                StudentFirstName = fixture.Create<string>(),
                StudentLastName = fixture.Create<string>(),
                StudentWLCId = fixture.Create<int>()*-1
            };
            var results = createStudent.CreateStudent(testParams);
            Assert.Equal(results.StudentId, -1);
        }
        [Fact]
        public void CreateStudent_GivenZeroStudentId_ReturnNegative1()
        {
            StudentCreateService createStudent = fixture.Create<StudentCreateService>();

            StudentCreateParams testParams = new StudentCreateParams
            {
                StudentFirstName = fixture.Create<string>(),
                StudentLastName = fixture.Create<string>(),
                StudentWLCId = 0
            };
            var results = createStudent.CreateStudent(testParams);
            Assert.Equal(results.StudentId, -1);
        }
        [Fact]
        public void CreateStudent_RepeatStudentWithinTimeLimit_ReturnNegative1()
        {
            StudentCreateService createStudent = fixture.Create<StudentCreateService>();

            StudentCreateParams testParams = new StudentCreateParams
            {
                StudentFirstName = fixture.Create<string>(),
                StudentLastName = fixture.Create<string>(),
                StudentWLCId = fixture.Create<int>()
            };
            var results = createStudent.CreateStudent(testParams);
            results = createStudent.CreateStudent(testParams);
            Assert.Equal(results.StudentId, -1);
        }
    }    
}