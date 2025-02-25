using ACV.ConditionReports.API.Repositories;
using ACV.ConditionReports.API.Repositories.Entities;
using ACV.ConditionReports.API.Repositories.Interface;
using ACV.ConditionReports.API.Services.Interfaces;

namespace ACV.ConditionReports.API.Services
{
    public class ReportService : IReportService
    {
        GetTire _getTire;
        IReportRepository _repository;

        public ReportService(GetTire getTire, IReportRepository repository)
        {
            _getTire = getTire;
            _repository = repository;
        }

        public async Task<IEnumerable<WRK_DP_TIRE>> GetTireDetails()
        {
            return await _getTire.GetTireDetails();
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
