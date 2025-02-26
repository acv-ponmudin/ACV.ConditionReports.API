using ACV.ConditionReports.API.Repositories.Entities;

namespace ACV.ConditionReports.API.Services.Interfaces
{
    public interface IReportService
    {
        Task Insert(InspectionCR inspectionCR);
    }
}
