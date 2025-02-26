using ACV.ConditionReports.API.Models.Request;
using ACV.ConditionReports.API.Repositories.Entities;
using ACV.ConditionReports.API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACV.ConditionReports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        IReportService _reportService;
        IMapper _mapper;
        Serilog.ILogger _logger;

        public ReportController(IReportService reportService, IMapper mapper, Serilog.ILogger logger)
        {
            _reportService = reportService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> InsertConditionReport([FromBody] ConditionReport conditionReport)
        {
            try
            {
                var a = _mapper.Map<InspectionCR>(conditionReport);
                await _reportService.Insert(a);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return Ok(new { message = "Report Added Successfully" });
        }
    }
}
