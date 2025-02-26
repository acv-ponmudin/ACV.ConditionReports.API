using System.ComponentModel.DataAnnotations.Schema;

namespace ACV.ConditionReports.API.Repositories.Entities
{
    public class DamageCR
    {
        [Column("damage_id")]
        public int DamageID { get; set; }

        [Column("inspection_id")]
        public int InspectionID { get; set; }

        [Column("aasc_item_code")]
        public int AascItemCode { get; set; }

        [Column("aasc_item_description")]
        public string AascItemDescription { get; set; }

        [Column("aasc_damage_code")]
        public int AascDamageCode { get; set; }

        [Column("aasc_damage_description")]
        public string AascDamageDescription { get; set; }

        [Column("aasc_severity_code")]
        public int AascSeverityCode { get; set; }

        [Column("aasc_severity_description")]
        public string AascSeverityDescription { get; set; }

        [Column("frame")]
        public string Frame { get; set; }

        [Column("image_file_name")]
        public string ImageFileName { get; set; }

        [Column("image_file_url")]
        public string ImageFileURL { get; set; }

        [Column("image_thumbnail_url")]
        public string ImageThumbnailURL { get; set; }

        [Column("estimated_repair_cost")]
        public int EstimatedRepairCost { get; set; }

        [Column("parts_price")]
        public int PartsPrice { get; set; }

        [Column("labor_price")]
        public int LaborPrice { get; set; }
    }
}
