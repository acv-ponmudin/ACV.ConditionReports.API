using ACV.ConditionReports.API.Repositories.Entities;
using ACV.ConditionReports.API.Repositories.Interface;
using Dapper;
using Microsoft.Data.SqlClient;
using Z.Dapper.Plus;

namespace ACV.ConditionReports.API.Repositories
{
    public class ReportRepository : IReportRepository
    {
        SqlConnection _sqlConnection;
        Serilog.ILogger _logger;

        public ReportRepository(SqlConnection sqlConnection, Serilog.ILogger logger)
        {
            _sqlConnection = sqlConnection;
            _logger = logger;   
        }

        public async Task Insert(InspectionCR inspectionCR)
        {
            try
            {
                using (_sqlConnection)
                {
                    _sqlConnection.Open();
                   
                    using (var trans = _sqlConnection.BeginTransaction())
                    {
                        try
                        {
                            // inspection table insertion
                            var inspection = new
                            {
                                inspection_id = inspectionCR.InspectionID,
                                vin = inspectionCR.Vin,
                                year = inspectionCR.Year,
                                mfg = inspectionCR.Manufacture,
                                model = inspectionCR.Model,
                                trim = inspectionCR.Trim,
                                default_image_url = inspectionCR.DefaultImageURL,
                                autograde_value = inspectionCR.AutogradeValue,
                                customer_client_name = inspectionCR.CustomerClientName,
                                datetime_created_utc = inspectionCR.DatetimeCreatedUTC,
                                datetime_submitted_utc = inspectionCR.DatetimeSubmittedUTC,
                                datetime_damage_approved_utc = inspectionCR.DatetimeDamageApprovedUTC,
                                odometer_miles = inspectionCR.OdometerMiles,
                                exterior_color = inspectionCR.ExteriorColor,
                                interior_color = inspectionCR.InteriorColor,
                                condition_report_url_public = inspectionCR.ConditionReportURLPublic,
                                condition_report_url_private = inspectionCR.ConditionReportURLPrivate,
                                condition_report_url_pdf = inspectionCR.ConditionReportURLPDF
                            };

                            var inspectionInsertedId = _sqlConnection.ExecuteScalarAsync<int>(QueryConstant.inspectionCRQuery, inspection, trans);

                            // Damages table bulk insert
                            var damages = inspectionCR.Damages.Select(x => new
                            {
                                damage_id = x.DamageID,
                                inspection_id = x.InspectionID,
                                aasc_item_code = x.AascItemCode,
                                aasc_item_description = x.AascItemDescription,
                                aasc_damage_code = x.AascDamageCode,
                                aasc_damage_description = x.AascDamageDescription,
                                aasc_severity_code = x.AascSeverityCode,
                                aasc_severity_description = x.AascSeverityDescription,
                                frame = x.Frame,
                                image_file_name = x.ImageFileName,
                                image_file_url = x.ImageFileURL,
                                image_thumbnail_url = x.ImageThumbnailURL,
                                estimated_repair_cost = x.EstimatedRepairCost,
                                parts_price = x.PartsPrice,
                                labor_price = x.LaborPrice
                            }).ToList();

                            SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.String);

                            await _sqlConnection.UseBulkOptions(x =>
                            {
                                x.DestinationTableName = "damages_cr";
                                x.UseInternalTransaction = true;
                                x.Transaction = trans;
                            }).BulkInsertAsync(damages);

                            trans.Commit();
                        }
                        catch (SqlException ex)
                        {
                            _logger.Error(ex.ToString());
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }
    }
}
