using System;
using Xunit;
using MathPlacementTest.Services;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using MathPlacementTest.Services.Objects;
using System.Collections.Generic;

namespace MathPlacementTest.Tests
{
    public class AdminGenerateReportTests
    {
        private IFixture fixture = new Fixture();

        public AdminGenerateReportTests()
        {
            this.fixture.Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void GenerateReport_GivenNullParams_ReturnFalse()
        {
            //Act
            var service = fixture.Create<AdminGenerateReportService>();
            var CSVBool= service.GenerateReport(null);

            //Assert
            CSVBool.Should().BeFalse();
        }

        [Fact]
        public void GenerateReport_GivenNullFileName_ReturnFalse()
        {

            //Arrange
            GenerateReportParams reportParams = new GenerateReportParams() { 
                EndDate = fixture.Create<DateTime>(), 
                StartDate = fixture.Create<DateTime>(), 
                FileName = null };
            //Act
            var service = fixture.Create<AdminGenerateReportService>();
            var CSVBool = service.GenerateReport(reportParams);

            //Assert
            CSVBool.Should().BeFalse();
        }

        [Fact]
        public void GenerateReport_GivenEmptyFileName_ReturnFalse()
        {

            //Arrange
            GenerateReportParams reportParams = new GenerateReportParams()
            {
                EndDate = fixture.Create<DateTime>(),
                StartDate = fixture.Create<DateTime>(),
                FileName = ""
            };
            //Act
            var service = fixture.Create<AdminGenerateReportService>();
            var CSVBool = service.GenerateReport(reportParams);

            //Assert
            CSVBool.Should().BeFalse();
        }

        [Fact]
        public void GenerateReport_GivenNullStartDate_ReturnFalse()
        {

            //Arrange
            GenerateReportParams reportParams = new GenerateReportParams()
            {
                EndDate = fixture.Create<DateTime>(),
                FileName = fixture.Create<string>()
            };
            //Act
            var service = fixture.Create<AdminGenerateReportService>();
            var CSVBool = service.GenerateReport(reportParams);

            //Assert
            CSVBool.Should().BeFalse();
        }

        [Fact]
        public void GenerateReport_GivenNullEndDate_ReturnFalse()
        {

            //Arrange
            GenerateReportParams reportParams = new GenerateReportParams()
            {
                StartDate = fixture.Create<DateTime>(),
                FileName = fixture.Create<string>()
            };
            //Act
            var service = fixture.Create<AdminGenerateReportService>();
            var CSVBool = service.GenerateReport(reportParams);

            //Assert
            CSVBool.Should().BeFalse();
        }

        [Fact]
        public void GenerateReport_GivenNoDatabaseData_ReturnFalse()
        {

            //Arrange
            fixture.Freeze<Mock<IAdminGenerateReportDataRetrieverService>>()
                .Setup(mock => mock.FetchData(It.IsAny<GenerateReportParams>()))
                .Returns<IEnumerable<ReportDetails>>(null);

            //Act
            var service = fixture.Create<AdminGenerateReportService>();
            var CSVBool = service.GenerateReport(fixture.Create<GenerateReportParams>());

            //Assert
            CSVBool.Should().BeFalse();
        }

        [Fact]
        public void GenerateReport_GivenGoodParams_ReturnTrue()
        {
            //Arrange
            List<ReportDetails> reportData = fixture.Create<List<ReportDetails>>();

            fixture.Freeze<Mock<IAdminGenerateReportDataRetrieverService>>()
                .Setup(mock => mock.FetchData(It.IsAny<GenerateReportParams>()))
                .Returns(reportData);

            fixture.Freeze<Mock<IAdminGenerateReportService>>()
                .Setup(mock => mock.WriteCSV(It.IsAny<IEnumerable<ReportDetails>>(), It.IsAny<string>()))
                .Verifiable();

            //Act
            var service = fixture.Create<AdminGenerateReportService>();
            var CSVBool = service.GenerateReport(fixture.Create<GenerateReportParams>());

            //Assert
            CSVBool.Should().BeTrue();
        }
    }
}
