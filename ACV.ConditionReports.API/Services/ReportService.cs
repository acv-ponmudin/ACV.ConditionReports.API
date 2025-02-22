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

        public IEnumerable<WRK_DP_TIRE> GetTireDetails()
        {
            return _getTire.GetTireDetails();
        }

        public void Insert(InspectionCR inspectionCR)
        {
            _repository.Insert(inspectionCR);
        }
    }
}
