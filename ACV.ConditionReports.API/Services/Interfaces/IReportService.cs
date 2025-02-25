using ACV.ConditionReports.API.Repositories.Entities;

namespace ACV.ConditionReports.API.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<WRK_DP_TIRE>> GetTireDetails();
        Task Insert(InspectionCR inspectionCR);
    }
}
