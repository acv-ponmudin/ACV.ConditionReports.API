using ACV.ConditionReports.API.Repositories.Entities;

namespace ACV.ConditionReports.API.Services.Interfaces
{
    public interface IReportService
    {
        IEnumerable<WRK_DP_TIRE> GetTireDetails();
        void Insert(InspectionCR inspectionCR);
    }
}
