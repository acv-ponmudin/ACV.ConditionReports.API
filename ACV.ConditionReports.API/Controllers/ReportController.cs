using ACV.ConditionReports.API.Models.Request;
using ACV.ConditionReports.API.Repositories.Entities;
using ACV.ConditionReports.API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace ACV.ConditionReports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        IReportService _reportService;
        IMapper _mapper;

        public ReportController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<WRK_DP_TIRE> Get()
        {
            return _reportService.GetTireDetails().Take(25).ToList<WRK_DP_TIRE>();
        }

        [HttpPost]
        public void InsertConditionReport([FromBody] ConditionReport conditionReport)
        {
            var a = _mapper.Map<InspectionCR>(conditionReport);
            _reportService.Insert(a);
        }
    }
}
