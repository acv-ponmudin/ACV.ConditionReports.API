using ACV.ConditionReports.API.Repositories.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ACV.ConditionReports.API.Repositories
{
    public class GetTire
    {
        SqlConnection _sqlConnection;
        
        public GetTire(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }


        public IEnumerable<WRK_DP_TIRE> GetTireDetails()
        {
            using(_sqlConnection)
            {
                _sqlConnection.Open();
                string query = "select Vehicle_ID, Inspection_ID, Assignment_ID from WRK_DP_TIRE";


                IEnumerable<WRK_DP_TIRE> data = _sqlConnection.Query<WRK_DP_TIRE>(query);
                return data;
            }
        }


    }
}
