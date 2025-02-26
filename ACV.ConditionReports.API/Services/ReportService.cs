using ACV.ConditionReports.API.Repositories;
using ACV.ConditionReports.API.Repositories.Entities;
using ACV.ConditionReports.API.Repositories.Interface;
using ACV.ConditionReports.API.Services.Interfaces;

namespace ACV.ConditionReports.API.Services
{
    public class ReportService : IReportService
    {
        IReportRepository _repository;

        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        public async Task Insert(InspectionCR inspectionCR)
        {
            try
            {
                await _repository.Insert(inspectionCR);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
