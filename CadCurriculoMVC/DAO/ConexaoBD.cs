using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadCurriculoMVC.DAO
{
    public static class ConexaoBD
    {
        public static SqlConnection GetConnection()
        {
            //string cx = "Data Source=localhost;database=CurriculoDB;user id=sa;password=123456";
            string cx = "Data Source=COMPUTER\\SQLEXPRESS;database=CurriculoDB;user id=sa;password=123456789";
            SqlConnection connection = new SqlConnection(cx);
            connection.Open();
            return connection;
        }
    }
}