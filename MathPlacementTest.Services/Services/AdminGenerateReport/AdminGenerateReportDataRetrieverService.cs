using MathPlacementTest.Data;
using MathPlacementTest.Services.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MathPlacementTest.Services
{
    public class AdminGenerateReportDataRetrieverService : IAdminGenerateReportDataRetrieverService
    {
        private readonly MathTestDbContext _dbContext;

        public AdminGenerateReportDataRetrieverService(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ReportDetails> FetchData(GenerateReportParams generateReportParams)
        {
            if(generateReportParams == null)
            {
                return null;
            }
            List<ReportDetails> DataToReturn = new List<ReportDetails>();
            try
            {
                //Get all students whose insertedOn date is between the given start and end date
                var studentsToReport = _dbContext.Students.Where(s => (s.InsertedOn >= generateReportParams.StartDate) && (s.InsertedOn <= generateReportParams.EndDate)).ToList();

                //Generate list of only the relevant data
                foreach (var student in studentsToReport)
                {
                    DataToReturn.Add(new ReportDetails
                    {
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        ClassToBePlacedIn = student.ClassChosen,
                        WLCId = student.WLCId
                    });
                }

                return DataToReturn;
            }
            catch
            {
                return null;
            }
        }
    }
}
