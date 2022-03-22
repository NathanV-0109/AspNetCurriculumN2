using System.Data;
using System.Data.SqlClient;

namespace CadCurriculoMVC.DAO
{
    static class HelperDAO
    {
        public static void ExecutaSQL(string sql, SqlParameter[] parameter)
        {
            using (var connection = ConexaoBD.GetConnection())
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddRange(parameter);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public static void ExecutaSQL(string sql)
        {
            using (var connection = ConexaoBD.GetConnection())
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public static DataTable ExecutaSelect(string sql, SqlParameter[] parameters)
        {
            using(var cx = ConexaoBD.GetConnection())
            {
                using(var adapter = new SqlDataAdapter(sql, cx))
                {
                    if (parameters != null)                    
                        adapter.SelectCommand.Parameters.AddRange(parameters);

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    return table;
                }
            }
        }
    }
}