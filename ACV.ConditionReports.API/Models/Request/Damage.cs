using System.Text.Json.Serialization;

namespace ACV.ConditionReports.API.Models.Request
{
    public class Damage
    {
        [JsonPropertyName("damage_id")]
        public required int DamageID { get; set; }

        [JsonPropertyName("inspection_id")]
        public required int InspectionID { get; set; }

        [JsonPropertyName("aasc_item_code")]
        public required int AascItemCode { get; set; }

        [JsonPropertyName("aasc_item_description")]
        public required string AascItemDescription { get; set; }

        [JsonPropertyName("aasc_damage_code")]
        public required int AascDamageCode { get; set; }

        [JsonPropertyName("aasc_damage_description")]
        public required string AascDamageDescription { get; set; }

        [JsonPropertyName("aasc_severity_code")]
        public required int AascSeverityCode { get; set; }

        [JsonPropertyName("aasc_severity_description")]
        public required string AascSeverityDescription { get; set; }

        [JsonPropertyName("frame")]
        public required string Frame { get; set; }

        [JsonPropertyName("image_file_name")]
        public required string ImageFileName { get; set; }

        [JsonPropertyName("image_file_url")]
        public required string ImageFileURL { get; set; }

        [JsonPropertyName("image_thumbnail_url")]
        public required string ImageThumbnailURL { get; set; }

        [JsonPropertyName("estimated_repair_cost")]
        public required int EstimatedRepairCost { get; set; }

        [JsonPropertyName("parts_price")]
        public required int PartsPrice { get; set; }

        [JsonPropertyName("labor_price")]
        public required int LaborPrice { get; set; }
    }
}
