using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

namespace MergeMySQLEventsIntoMSSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            using var MSSQLCN = new SqlConnection() { ConnectionString = "Data Source = GANN; " + "Initial Catalog=gann;" + "User id=gann_user;" + "Password=[PASSWORD];" };
            MSSQLCN.Open();
            using var MSSQLCN2 = new SqlConnection() { ConnectionString = "Data Source = GANN; " + "Initial Catalog=gann;" + "User id=gann_user;" + "Password=[PASSWORD];" };
            MSSQLCN2.Open();
            using var MySQLCN = new MySqlConnection() { ConnectionString = "Data Source = GANN2; " + "Initial Catalog=meer;" + "User id=gann2;" + "Password=[PASSWORD];" };
            MySQLCN.Open();

            string statement1ForMSSQL = "SELECT * FROM [gann].[dbo].[EvolvedFilesMeta]";
            var cmd = new SqlCommand(statement1ForMSSQL, MSSQLCN);
            var reader = cmd.ExecuteReader();

            foreach (var o in reader)
            {
                var startTime = reader["StartTime"];
                var endTime = reader["EndTime"];

                string statement1ForMySQL = "SELECT * FROM meer.event e inner join  meer.event_json ej on e.cid=ej.cid WHERE timestamp BETWEEN @StartTime AND @EndTime;";
                var cmd2 = new MySqlCommand(statement1ForMySQL, MySQLCN);

                cmd2.Parameters.Add("@StartTime", MySqlDbType.DateTime);
                cmd2.Parameters["@StartTime"].Value = startTime;

                cmd2.Parameters.Add("@EndTime", MySqlDbType.DateTime);
                cmd2.Parameters["@EndTime"].Value = endTime;

                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var SURICATA_CID = reader2["cid"];
                    var SURICATA_FlowID = reader2["flow_id"];
                    var SURICATA_json = reader2["json"];

                    var ID_EvolvedTinyInts = (int)reader["ID_EvolvedTinyInts"];

                    string statement2ForMSSQL = "UPDATE [gann].[dbo].[EvolvedFilesMeta] SET [SURICATA_CID] = @SURICATA_CID, [SURICATA_FlowID] = @SURICATA_FlowID, [SURICATA_json] = @SURICATA_json WHERE [ID_EvolvedTinyInts] = @ID_EvolvedTinyInts";
                    var cmd3 = new SqlCommand(statement2ForMSSQL, MSSQLCN2);

                    cmd3.Parameters.Add("@ID_EvolvedTinyInts", SqlDbType.BigInt);
                    cmd3.Parameters.Add("@SURICATA_CID", SqlDbType.BigInt);
                    cmd3.Parameters.Add("@SURICATA_FlowID", SqlDbType.BigInt);
                    cmd3.Parameters.Add("@SURICATA_json", SqlDbType.NVarChar);

                    cmd3.Parameters["@ID_EvolvedTinyInts"].Value = ID_EvolvedTinyInts;
                    cmd3.Parameters["@SURICATA_CID"].Value = SURICATA_CID;
                    cmd3.Parameters["@SURICATA_FlowID"].Value = SURICATA_FlowID;
                    cmd3.Parameters["@SURICATA_json"].Value = SURICATA_json;

                    cmd3.ExecuteNonQuery();
                    cmd3.Dispose();
                }
                reader2.Close();
                cmd2.Dispose();
            }

            cmd.Dispose();
            MSSQLCN.Close();
            MySQLCN.Close();
        }
    }
}
