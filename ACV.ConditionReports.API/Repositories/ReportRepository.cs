using ACV.ConditionReports.API.Repositories.Entities;
using ACV.ConditionReports.API.Repositories.Interface;
using Dapper;
using Microsoft.Data.SqlClient;
using Serilog;
using Z.Dapper.Plus;

namespace ACV.ConditionReports.API.Repositories
{
    public class ReportRepository : IReportRepository
    {
        SqlConnection _sqlConnection;

        public ReportRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public void Insert(InspectionCR inspectionCR)
        {
            try
            {
                using (_sqlConnection)
                {
                    _sqlConnection.Open();
                    string inspectionCRQuery = "INSERT INTO dbo.INSPECTION_CR(INSPECTION_ID,VIN,YEAR,MFG,MODEL,TRIM,DEFAULT_IMAGE_URL,AUTOGRADE_VALUE,CUSTOMER_CLIENT_NAME,DATETIME_CREATED_UTC,DATETIME_SUBMITTED_UTC,DATETIME_DAMAGE_APPROVED_UTC,ODOMETER_MILES,EXTERIOR_COLOR,INTERIOR_COLOR,CONDITION_REPORT_URL_PUBLIC,CONDITION_REPORT_URL_PRIVATE,CONDITION_REPORT_URL_PDF)\r\n     VALUES(@inspection_id,@vin,@year, @mfg, @model, @trim, @default_image_url,@autograde_value,@customer_client_name,@datetime_created_utc,@datetime_submitted_utc,@datetime_damage_approved_utc,@odometer_miles, @exterior_color,@interior_color,@condition_report_url_public,@condition_report_url_private,@condition_report_url_pdf); SELECT SCOPE_IDENTITY();";

                    string damagesCRQuery = "INSERT INTO DAMAGES_CR(DAMAGE_ID,INSPECTION_ID,AASC_ITEM_CODE,AASC_ITEM_DESCRIPTION,AASC_DAMAGE_CODE,AASC_DAMAGE_DESCRIPTION,AASC_SEVERITY_CODE,AASC_SEVERITY_DESCRIPTION,FRAME,IMAGE_FILE_NAME,IMAGE_FILE_URL,IMAGE_THUMBNAIL_URL,ESTIMATED_REPAIR_COST,PARTS_PRICE,LABOR_PRICE) VALUES (@damage_id,@inspection_id,@aasc_item_code,@aasc_item_description,@aasc_damage_code,@aasc_damage_description,@aasc_severity_code,@aasc_severity_description,@frame,@image_file_name,@image_file_url,@image_thumbnail_url,@estimated_repair_cost,@parts_price,@labor_price)";

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

                            var inspectionInsertedId = _sqlConnection.ExecuteScalar<int>(inspectionCRQuery, inspection, trans);

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

                            _sqlConnection.UseBulkOptions(x =>
                            {
                                x.DestinationTableName = "damages_cr";
                                x.UseInternalTransaction = true;
                                x.Transaction = trans;
                            }).BulkInsert(damages);

                            trans.Commit();
                        }
                        catch (SqlException ex)
                        {
                            Log.Error(ex.ToString());
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
