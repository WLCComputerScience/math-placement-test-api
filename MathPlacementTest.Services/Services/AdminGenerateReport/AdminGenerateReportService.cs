﻿using MathPlacementTest.Services.Objects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathPlacementTest.Services
{
    public class AdminGenerateReportService : IAdminGenerateReportService
    {
        private readonly IAdminGenerateReportDataRetrieverService _adminGenerateReportDataRetrieverService;

        public AdminGenerateReportService(IAdminGenerateReportDataRetrieverService adminGenerateReportDataRetrieverService)
        {
            _adminGenerateReportDataRetrieverService = adminGenerateReportDataRetrieverService;
        }
        public bool GenerateReport(GenerateReportParams generateReportParams)
        {
            //Return true if report is generated and saved to file
            //False otherwise
            if(generateReportParams == null)
            {
                return false;
            }
            //Get list of details
            List<ReportDetails> reportData = _adminGenerateReportDataRetrieverService.FetchData(generateReportParams);
            if(reportData == null)
            {
                return false;
            }
            try
            {
                WriteCSV(reportData, "MathPlacementTestReport.csv");
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void WriteCSV<T>(IEnumerable<T> items, string path)
        {
            //From answer here https://stackoverflow.com/questions/7114819/write-c-sharp-lists-of-objects-in-csv-file
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(", ", props.Select(p => p.Name)));

                foreach (var item in items)
                {
                    writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));
                }
            }
        }
    }
}