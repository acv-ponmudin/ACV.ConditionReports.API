using ACV.ConditionReports.API.Repositories.Entities;

namespace ACV.ConditionReports.API.Repositories.Interface
{
    public interface IReportRepository
    {
        Task Insert(InspectionCR inspectionCR);
    }
}
