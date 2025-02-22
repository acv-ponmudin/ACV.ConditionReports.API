using System.ComponentModel.DataAnnotations.Schema; 

namespace ACV.ConditionReports.API.Repositories.Entities
{
    public class InspectionCR
    {
        [Column("inspection_id")]
        public int InspectionID { get; set; }

        [Column("vin")]
        public string Vin { get; set; }

        [Column("year")]
        public string Year { get; set; }

        [Column("mfg")]
        public string Manufacture { get; set; }

        [Column("model")]
        public string Model { get; set; }

        [Column("trim")]
        public string Trim { get; set; }

        [Column("default_image_url")]
        public string DefaultImageURL { get; set; }

        [Column("autograde_value")]
        public float AutogradeValue { get; set; }

        [Column("customer_client_name")]
        public string CustomerClientName { get; set; }

        [Column("datetime_created_utc")]
        public DateTime DatetimeCreatedUTC { get; set; }

        [Column("datetime_submitted_utc")]
        public DateTime DatetimeSubmittedUTC { get; set; }

        [Column("datetime_damage_approved_utc")]
        public DateTime DatetimeDamageApprovedUTC { get; set; }

        [Column("odometer_miles")]
        public int OdometerMiles { get; set; }

        [Column("exterior_color")]
        public string ExteriorColor { get; set; }

        [Column("interior_color")]
        public string InteriorColor { get; set; }

        [Column("condition_report_url_public")]
        public string ConditionReportURLPublic { get; set; }

        [Column("condition_report_url_private")]
        public string ConditionReportURLPrivate { get; set; }

        [Column("condition_report_url_pdf")]
        public string ConditionReportURLPDF { get; set; }

        [Column("damages")]
        public DamageCR[] Damages { get; set; }
    }
}
