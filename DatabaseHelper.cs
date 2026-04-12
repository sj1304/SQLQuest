using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SQLQuest
{
    public static class DatabaseHelper
    {
        private static string connectionString =
            ConfigurationManager.ConnectionStrings["MyGameDB"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        public static int ExecuteNonQuery(string query)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                return cmd.ExecuteNonQuery();
            }
        }

        public static DataTable GetLevelObjects(int levelNumber)
        {
            string query = $"SELECT * FROM level_objects WHERE level_number = {levelNumber}";
            return ExecuteQuery(query);
        }

        public static DataTable GetHints(int levelNumber)
        {
            string query = $"SELECT * FROM hints WHERE level_number = {levelNumber}";
            return ExecuteQuery(query);
        }

        public static bool IsLevelComplete(int levelNumber)
        {
            string query = $"SELECT object_value FROM level_objects " +
                           $"WHERE object_names = 'Door' AND level_number = {levelNumber}";
            DataTable dt = ExecuteQuery(query);
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["object_value"].ToString() == "1";
            return false;
        }

        public static DataRow GetPlayer(string playerName)
        {
            string query = $"SELECT * FROM player WHERE player_name = '{playerName}'";
            DataTable dt = ExecuteQuery(query);
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        public static void CreatePlayer(string playerName)
        {
            string query = $"INSERT INTO player (player_name, highscore, levels_complete) " +
                           $"VALUES ('{playerName}', 0, 0)";
            ExecuteNonQuery(query);
        }

        public static void UpdatePlayerScore(string playerName, int score, int levelsComplete)
        {
            if(levelsComplete==1)
            {
                score = 150;
            }
            else if(levelsComplete==2)
            {
                score = 300;
            }
            else if(levelsComplete==3)
            {
                score = 500;
            }
            else
            {
                score = 0;
            }
            string query = $"UPDATE player SET highscore = {score}, levels_complete = {levelsComplete} " +
                           $"WHERE player_name = '{playerName}'";
            ExecuteNonQuery(query);
        }

        public static void AddToInventory(string itemName, int levelNumber)
        {
            string query = $"INSERT INTO inventory (level_number, inventory_name) " +
                           $"VALUES ({levelNumber}, '{itemName}')";
            ExecuteNonQuery(query);
        }

        public static bool IsInInventory(string itemName, int levelNumber)
        {
            string query = $"SELECT * FROM inventory WHERE inventory_name = '{itemName}' " +
                           $"AND level_number = {levelNumber}";
            return ExecuteQuery(query).Rows.Count > 0;
        }

        public static void ResetLevel(int levelNumber)
        {
            ExecuteNonQuery($"UPDATE level_objects SET object_value = '0' WHERE level_number = {levelNumber}");
            ExecuteNonQuery($"DELETE FROM inventory WHERE level_number = {levelNumber}");
        }
    }
}