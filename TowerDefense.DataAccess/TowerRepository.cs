using System.Collections.Generic;
using System.Data.SqlClient;
using TowerDefense.Logic;

namespace TowerDefense.DataAccess
{
    public class TowerRepository : ITowerRepository
    {
        private readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                                                    "AttachDbFilename=C:\\Projects\\TowerDefense\\TowerDefense.Database\\TowerDefense.mdf;" +
                                                    "Integrated Security=True";
       
        public IEnumerable<TowerInfo> FetchList() //TODO: Replace with Dapper //TODO: Replace DB column with Real to map easier into Float
        {
            var towers = new List<TowerInfo>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("Tower_GetList", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tower = new TowerInfo(
                            reader.GetInt32(reader.GetOrdinal("TowerId")),
                            reader.GetString(reader.GetOrdinal("TowerTypeCode")),
                            reader.GetString(reader.GetOrdinal("TowerName")),
                            reader.GetString(reader.GetOrdinal("PrefabPath")),
                            (float)reader.GetDouble(reader.GetOrdinal("Range")),
                            (float)reader.GetDouble(reader.GetOrdinal("StartTime")),
                            (float)reader.GetDouble(reader.GetOrdinal("UpdateTargetRate")),
                            (float)reader.GetDouble(reader.GetOrdinal("FireRate")),
                            (float)reader.GetDouble(reader.GetOrdinal("FireCooldown"))
                            );
                        towers.Add(tower);
                    }
                }
            }
            return towers;
        }
    }
}