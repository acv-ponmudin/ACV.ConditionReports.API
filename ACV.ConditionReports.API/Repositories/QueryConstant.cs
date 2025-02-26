namespace ACV.ConditionReports.API.Repositories
{
    public static class QueryConstant
    {
        public static string inspectionCRQuery = "INSERT INTO dbo.INSPECTION_CR(INSPECTION_ID,VIN,YEAR,MFG,MODEL,TRIM,DEFAULT_IMAGE_URL,AUTOGRADE_VALUE,CUSTOMER_CLIENT_NAME,DATETIME_CREATED_UTC,DATETIME_SUBMITTED_UTC,DATETIME_DAMAGE_APPROVED_UTC,ODOMETER_MILES,EXTERIOR_COLOR,INTERIOR_COLOR,CONDITION_REPORT_URL_PUBLIC,CONDITION_REPORT_URL_PRIVATE,CONDITION_REPORT_URL_PDF)\r\n     VALUES(@inspection_id,@vin,@year, @mfg, @model, @trim, @default_image_url,@autograde_value,@customer_client_name,@datetime_created_utc,@datetime_submitted_utc,@datetime_damage_approved_utc,@odometer_miles, @exterior_color,@interior_color,@condition_report_url_public,@condition_report_url_private,@condition_report_url_pdf); SELECT SCOPE_IDENTITY();";

        public static string damagesCRQuery = "INSERT INTO DAMAGES_CR(DAMAGE_ID,INSPECTION_ID,AASC_ITEM_CODE,AASC_ITEM_DESCRIPTION,AASC_DAMAGE_CODE,AASC_DAMAGE_DESCRIPTION,AASC_SEVERITY_CODE,AASC_SEVERITY_DESCRIPTION,FRAME,IMAGE_FILE_NAME,IMAGE_FILE_URL,IMAGE_THUMBNAIL_URL,ESTIMATED_REPAIR_COST,PARTS_PRICE,LABOR_PRICE) VALUES (@damage_id,@inspection_id,@aasc_item_code,@aasc_item_description,@aasc_damage_code,@aasc_damage_description,@aasc_severity_code,@aasc_severity_description,@frame,@image_file_name,@image_file_url,@image_thumbnail_url,@estimated_repair_cost,@parts_price,@labor_price)";
    }
}
