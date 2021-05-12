using MathPlacementTest.Services.Objects;
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
            if(generateReportParams == null || generateReportParams.FileName == "" || generateReportParams.FileName == null ||
                generateReportParams.EndDate == DateTime.MinValue || generateReportParams.StartDate == DateTime.MinValue)
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
                WriteCSV(reportData, @"..\..\PlacementTestReports\" + generateReportParams.FileName +".csv");
            }
            catch
            {
                //If it fails to write, return false
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

            //Create folder if it does not exist
            bool exists = System.IO.Directory.Exists(@"..\..\PlacementTestReports\");

            if (!exists)
                System.IO.Directory.CreateDirectory(@"..\..\PlacementTestReports\");

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
