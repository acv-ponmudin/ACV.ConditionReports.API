using System.Text.Json.Serialization;

namespace ACV.ConditionReports.API.Models.Request 
{
    public class ConditionReport
    {
        [JsonPropertyName("inspection_id")]
        public required int InspectionID { get; set; }

        [JsonPropertyName("vin")]
        public required string Vin { get; set; }

        [JsonPropertyName("year")]
        public required string Year { get; set; }

        [JsonPropertyName("mfg")]
        public required string Manufacture { get; set; }

        [JsonPropertyName("model")]
        public required string Model { get; set; }

        [JsonPropertyName("trim")]
        public required string Trim { get; set; }

        [JsonPropertyName("default_image_url")]
        public required string DefaultImageURL { get; set; }

        [JsonPropertyName("autograde_value")]
        public required float AutogradeValue { get; set; }

        [JsonPropertyName("customer_client_name")]
        public required string CustomerClientName { get; set; }

        [JsonPropertyName("datetime_created_utc")]
        public required DateTime DatetimeCreatedUTC { get; set; }

        [JsonPropertyName("datetime_submitted_utc")]
        public required DateTime DatetimeSubmittedUTC { get; set; }

        [JsonPropertyName("datetime_damage_approved_utc")]
        public required DateTime DatetimeDamageApprovedUTC { get; set; }

        [JsonPropertyName("odometer_miles")]
        public required int OdometerMiles { get; set; }

        [JsonPropertyName("exterior_color")]
        public required string ExteriorColor { get; set; }

        [JsonPropertyName("interior_color")]
        public required string InteriorColor { get; set; }

        [JsonPropertyName("condition_report_url_public")]
        public required string ConditionReportURLPublic { get; set; }

        [JsonPropertyName("condition_report_url_private")]
        public required string ConditionReportURLPrivate { get; set; }

        [JsonPropertyName("condition_report_url_pdf")]
        public required string ConditionReportURLPDF { get; set; }

        [JsonPropertyName("damages")]
        public required Damage[] Damages { get; set; }
    }
}
