using CadCurriculoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CadCurriculoMVC.DAO
{
    public class IdiomaDAO
    {
        private SqlParameter[] CriaParametros(PessoaViewModel p, IdiomaViewModel i)
        {
            SqlParameter[] parameters = new SqlParameter[12];

            parameters[0] = new SqlParameter("idioma_id", i.IdiomaId);
            parameters[1] = new SqlParameter("pessoa_id", p.Id);

            if (i.Idioma_1 == null)
            {
                parameters[2] = new SqlParameter("idioma1", DBNull.Value);
                parameters[3] = new SqlParameter("nivel1", DBNull.Value);
            }
            else
            {
                parameters[2] = new SqlParameter("idioma1", i.Idioma_1);
                parameters[3] = new SqlParameter("nivel1", i.Nivel_1);
            }

            if (i.Idioma_2 == null)
            {
                parameters[4] = new SqlParameter("idioma2", DBNull.Value);
                parameters[5] = new SqlParameter("nivel2", DBNull.Value);
            }
            else
            {
                parameters[4] = new SqlParameter("idioma2", i.Idioma_2);
                parameters[5] = new SqlParameter("nivel2", i.Nivel_2);
            }

            if (i.Idioma_3 == null)
            {
                parameters[6] = new SqlParameter("idioma3", DBNull.Value);
                parameters[7] = new SqlParameter("nivel3", DBNull.Value);
            }
            else
            {
                parameters[6] = new SqlParameter("idioma3", i.Idioma_3);
                parameters[7] = new SqlParameter("nivel3", i.Nivel_3);
            }

            if (i.Idioma_4 == null)
            {
                parameters[8] = new SqlParameter("idioma4", DBNull.Value);
                parameters[9] = new SqlParameter("nivel4", DBNull.Value);
            }
            else
            {
                parameters[8] = new SqlParameter("idioma4", i.Idioma_4);
                parameters[9] = new SqlParameter("nivel4", i.Nivel_4);
            }


            if (i.Idioma_5 == null)
            {
                parameters[10] = new SqlParameter("idioma5", DBNull.Value);
                parameters[11] = new SqlParameter("nivel5", DBNull.Value);
            }
            else
            {
                parameters[10] = new SqlParameter("idioma5", i.Idioma_5);
                parameters[11] = new SqlParameter("nivel5", i.Nivel_5);
            }

            return parameters;
        }

        private IdiomaViewModel MontaCurriculoIdioma(DataRow registro)
        {
            return new IdiomaViewModel
            {               
                IdiomaId = Convert.ToInt32(registro["idioma_id"]),
                Idioma_1 = registro["idioma1"].ToString(),
                Nivel_1 = Convert.ToInt16(registro["nivel1"]),
                Idioma_2 = registro["idioma2"] == System.DBNull.Value ? " " : registro["idioma2"].ToString(),
                Nivel_2 = registro["nivel2"] == System.DBNull.Value ? 0 : Convert.ToInt16(registro["nivel2"]),
                Idioma_3 = registro["idioma3"] == System.DBNull.Value ? " " : registro["idioma3"].ToString(),
                Nivel_3 = registro["nivel3"] == System.DBNull.Value ? 0 : Convert.ToInt16(registro["nivel3"]),
                Idioma_4 = registro["idioma4"] == System.DBNull.Value ? " " : registro["idioma4"].ToString(),
                Nivel_4 = registro["nivel4"] == System.DBNull.Value ? 0 : Convert.ToInt16(registro["nivel4"]),
                Idioma_5 = registro["idioma5"] == System.DBNull.Value ? " " : registro["idioma5"].ToString(),
                Nivel_5 = registro["nivel5"] == System.DBNull.Value ? 0 : Convert.ToInt16(registro["nivel5"]),
            };
        }

        public void Insert(PessoaViewModel p, IdiomaViewModel i)
        {
            string sql = $"set dateformat dmy; " +
                         $"insert into idioma " +
                         $"(idioma_id, pessoa_id," +
                         $" idioma1, nivel1," +
                         $"idioma2, nivel2, " +
                         $"idioma3, nivel3, " +
                         $"idioma4, nivel4, " +
                         $"idioma5, nivel5) " +
                         $"values " +                         
                         $"({"@idioma_id"}, {"@pessoa_id"}, " +
                         $"{"@idioma1"}, {"@nivel1"}, " +
                         $"{"@idioma2"}, {"@nivel2"}, " +
                         $"{"@idioma3"}, {"@nivel3"}, " +
                         $"{"@idioma4"}, {"@nivel4"}, " +
                         $"{"@idioma5"}, {"@nivel5"})";


            HelperDAO.ExecutaSQL(sql, CriaParametros(p, i));
        }

        public void Update(PessoaViewModel p, IdiomaViewModel i)
        {
            string sql = $"set dateformat dmy; " +
                         $"UPDATE idioma " +
                         $"SET pessoa_id = {"@pessoa_id"}, " +
                         $"idioma1 = {"@idioma1"}, nivel1 = {"@nivel1"}, " +
                         $"idioma2 = {"@idioma2"}, nivel2 = {"@nivel2"}, " +
                         $"idioma3 = {"@idioma3"}, nivel3 = {"@nivel3"}, " +
                         $"idioma4 = {"@idioma4"}, nivel4 = {"@nivel4"}, " +
                         $"idioma5 = {"@idioma5"}, nivel5 = {"@nivel5"} " +
                         $"WHERE idioma_id={"@idioma_id"}";

            HelperDAO.ExecutaSQL(sql, CriaParametros(p, i));
        }

        public void Delete(int id)
        {
            string sql = $"set dateformat dmy; " +
                         $"DELETE FROM idioma " +
                         $"WHERE pessoa_id = {id}";


            HelperDAO.ExecutaSQL(sql);
        }

        public IdiomaViewModel Consultar(int id)
        {
            string sql = "select * from idioma where pessoa_id = " + id;

            DataTable table = HelperDAO.ExecutaSelect(sql, null);

            if (table.Rows.Count == 0)
                return null;
            else
            {
                return MontaCurriculoIdioma(table.Rows[0]);
            }
        }

        public List<IdiomaViewModel> Listar()
        {
            string sql = "select * from idioma";
            DataTable table = HelperDAO.ExecutaSelect(sql, null);
            List<IdiomaViewModel> lista = new List<IdiomaViewModel>();
            foreach (DataRow registro in table.Rows)
                lista.Add(MontaCurriculoIdioma(registro));

            return lista;
        }
    }
}