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
    public class EmailReportTests
    {
        private IFixture fixture = new Fixture();

        public EmailReportTests()
        {
            this.fixture.Customize(new AutoMoqCustomization());
        }
        [Fact]
        public void EmailReport_GivenNullEmailAddress()
        {
            EmailReportService emailReport = fixture.Create<EmailReportService>();

            EmailReportParams emailParams = new EmailReportParams
            {
                ToEmailAddress = null,
                FilePath = fixture.Create<string>()
            };

            var results = emailReport.EmailReport(emailParams);
            Assert.False(results);
        }

        [Fact]
        public void EmailReport_GivenEmptyEmailAddress()
        {
            EmailReportService emailReport = fixture.Create<EmailReportService>();

            EmailReportParams emailParams = new EmailReportParams
            {
                ToEmailAddress = "",
                FilePath = fixture.Create<string>()
            };

            var results = emailReport.EmailReport(emailParams);
            Assert.False(results);
        }
        public void EmailReport_GivenInvalidEmailAddress()
        {
            EmailReportService emailReport = fixture.Create<EmailReportService>();

            EmailReportParams emailParams = new EmailReportParams
            {
                ToEmailAddress = null,
                FilePath = fixture.Create<string>()
            };

            var results = emailReport.EmailReport(emailParams);
            Assert.False(results);
        }
        [Fact]
        public void EmailReport_GivenInvalidFilePath()
        {
            EmailReportService emailReport = fixture.Create<EmailReportService>();

            EmailReportParams emailParams = new EmailReportParams
            {
                ToEmailAddress = fixture.Create<string>(),
                FilePath = fixture.Create<string>()
            };

            var results = emailReport.EmailReport(emailParams);
            Assert.False(results);
        }
        [Fact]
        public void EmailReport_GivenNullFilePath()
        {
            EmailReportService emailReport = fixture.Create<EmailReportService>();

            EmailReportParams emailParams = new EmailReportParams
            {
                ToEmailAddress = fixture.Create<string>(),
                FilePath = null
            };

            var results = emailReport.EmailReport(emailParams);
            Assert.False(results);
        }
        [Fact]
        public void EmailReport_GivenEmptyFilePath()
        {
            EmailReportService emailReport = fixture.Create<EmailReportService>();

            EmailReportParams emailParams = new EmailReportParams
            {
                ToEmailAddress = fixture.Create<string>(),
                FilePath = ""
            };

            var results = emailReport.EmailReport(emailParams);
            Assert.False(results);
        }

    }
}