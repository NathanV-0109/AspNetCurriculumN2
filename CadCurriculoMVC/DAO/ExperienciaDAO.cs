using CadCurriculoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CadCurriculoMVC.DAO
{
    public class ExperienciaDAO    
    {
        private SqlParameter[] CriaParametros(PessoaViewModel p, ExperienciaViewModel e)
        {
            SqlParameter[] parameters = new SqlParameter[14];

            parameters[0] = new SqlParameter("experiencia_id", e.ExperienciaId);
            parameters[1] = new SqlParameter("pessoa_id", p.Id);

            if(e.NomeEmpresa_1 == null)
            {
                parameters[2] = new SqlParameter("nome_empresa1", DBNull.Value);
                parameters[3] = new SqlParameter("nome_cargo1", DBNull.Value);
                parameters[4] = new SqlParameter("dt_inicio1", DBNull.Value);
                parameters[5] = new SqlParameter("dt_fim1", DBNull.Value);
            }
            else
            {
                parameters[2] = new SqlParameter("nome_empresa1", e.NomeEmpresa_1);
                parameters[3] = new SqlParameter("nome_cargo1", e.NomeCargo_1);
                parameters[4] = new SqlParameter("dt_inicio1", e.DtInicio_1);
                parameters[5] = new SqlParameter("dt_fim1", e.DtFim_1);

            }

            if (e.NomeEmpresa_2 == null)
            {
                parameters[6] = new SqlParameter("nome_empresa2", DBNull.Value);
                parameters[7] = new SqlParameter("nome_cargo2", DBNull.Value);
                parameters[8] = new SqlParameter("dt_inicio2", DBNull.Value);
                parameters[9] = new SqlParameter("dt_fim2", DBNull.Value);
            }
            else
            {
                parameters[6] = new SqlParameter("nome_empresa2", e.NomeEmpresa_2);
                parameters[7] = new SqlParameter("nome_cargo2", e.NomeCargo_2);
                parameters[8] = new SqlParameter("dt_inicio2", e.DtInicio_2);
                parameters[9] = new SqlParameter("dt_fim2", e.DtFim_2);

            }

            if (e.NomeEmpresa_3 == null)
            {
                parameters[10] = new SqlParameter("nome_empresa3", DBNull.Value);
                parameters[11] = new SqlParameter("nome_cargo3", DBNull.Value);
                parameters[12] = new SqlParameter("dt_inicio3", DBNull.Value);
                parameters[13] = new SqlParameter("dt_fim3", DBNull.Value);
            }
            else
            {
                parameters[10] = new SqlParameter("nome_empresa3", e.NomeEmpresa_3);
                parameters[11] = new SqlParameter("nome_cargo3", e.NomeCargo_3);
                parameters[12] = new SqlParameter("dt_inicio3", e.DtInicio_3);
                parameters[13] = new SqlParameter("dt_fim3", e.DtFim_3);

            }

            return parameters;
        }

        private ExperienciaViewModel MontaCurriculoExperiencia(DataRow registro)
        {
            return new ExperienciaViewModel
            {
                ExperienciaId = Convert.ToInt32(registro["experiencia_id"]),                
                NomeEmpresa_1 = registro["nome_empresa1"].ToString(),
                NomeCargo_1 = registro["nome_cargo1"].ToString(),
                DtInicio_1 = Convert.ToDateTime(registro["dt_inicio1"]),
                DtFim_1 = Convert.ToDateTime(registro["dt_fim1"]),
                NomeEmpresa_2 =  registro["nome_empresa2"] == System.DBNull.Value ? " " : registro["nome_empresa2"].ToString(),
                NomeCargo_2 = registro["nome_cargo2"] == System.DBNull.Value ? " " : registro["nome_cargo2"].ToString(),
                DtInicio_2 = registro["dt_inicio2"] == System.DBNull.Value ? DateTime.Now : Convert.ToDateTime(registro["dt_inicio2"]),
                DtFim_2 = registro["dt_fim2"] == System.DBNull.Value ? DateTime.Now : Convert.ToDateTime(registro["dt_fim2"]),
                NomeEmpresa_3 = registro["nome_empresa3"] == System.DBNull.Value ? " " : registro["nome_empresa3"].ToString(),
                NomeCargo_3 = registro["nome_cargo3"] == System.DBNull.Value ? " " : registro["nome_cargo3"].ToString(),
                DtInicio_3 = registro["dt_inicio3"] == System.DBNull.Value ? DateTime.Now : Convert.ToDateTime(registro["dt_inicio3"]),
                DtFim_3 = registro["dt_fim3"] == System.DBNull.Value ? DateTime.Now : Convert.ToDateTime(registro["dt_fim3"])
            };
        }

        public void Insert(PessoaViewModel p, ExperienciaViewModel e)
        {
            string sql = $"set dateformat dmy; " +
                         $"insert into experiencia " +
                         $"(experiencia_id, pessoa_id, nome_empresa1, nome_cargo1, dt_inicio1, dt_fim1, " +
                         $"nome_empresa2, nome_cargo2, dt_inicio2, dt_fim2, " +
                         $"nome_empresa3, nome_cargo3, dt_inicio3, dt_fim3) " +
                         $"values " +
                         $"({"@experiencia_id"}, {"@pessoa_id"}, {"@nome_empresa1"}, {"@nome_cargo1"}, {"@dt_inicio1"}, {"@dt_fim1"}, " +
                         $"{"@nome_empresa2"}, {"@nome_cargo2"}, {"@dt_inicio2"}, {"@dt_fim2"}, " +
                         $"{"@nome_empresa3"}, {"@nome_cargo3"}, {"@dt_inicio3"}, {"@dt_fim3"})";   

            HelperDAO.ExecutaSQL(sql, CriaParametros(p, e));
        }

        public void Update(PessoaViewModel p, ExperienciaViewModel e)
        {  
            string sql = $"set dateformat dmy; " +
                         $"UPDATE experiencia " +
                         $"SET pessoa_id = {"@pessoa_id"}, " +
                         $"nome_empresa1 = {"@nome_empresa1"}, nome_cargo1 = {"@nome_cargo1"}, dt_inicio1 = {"@dt_inicio1"}, " +
                         $"dt_fim1 = {"@dt_fim1"}, " +
                         $"nome_empresa2 = {"@nome_empresa2"}, nome_cargo2 = {"@nome_cargo2"}, dt_inicio2 = {"@dt_inicio2"}, dt_fim2 = {"@dt_fim2"}, " +
                         $"nome_empresa3 = {"@nome_empresa3"}, nome_cargo3 = {"@nome_cargo3"}, dt_inicio3 = {"@dt_inicio3"}, dt_fim3 = {"@dt_fim3"} " +
                         $"WHERE experiencia_id={"@experiencia_id"}";

            HelperDAO.ExecutaSQL(sql, CriaParametros(p, e));
        }

        public void Delete(int id)
        {
            string sql = $"set dateformat dmy; " +
                         $"DELETE FROM experiencia " +
                         $"WHERE pessoa_id = {id} ";


            HelperDAO.ExecutaSQL(sql);
        }

        public ExperienciaViewModel Consultar(int id)
        {
            string sql = "select * from experiencia where pessoa_id = " + id;

            DataTable table = HelperDAO.ExecutaSelect(sql, null);

            if (table.Rows.Count == 0)
                return null;
            else
            {
                return MontaCurriculoExperiencia(table.Rows[0]);
            }
        }

        public List<ExperienciaViewModel> Listar()
        {
            string sql = "select * from experiencia";
            DataTable table = HelperDAO.ExecutaSelect(sql, null);
            List<ExperienciaViewModel> lista = new List<ExperienciaViewModel>();
            foreach (DataRow registro in table.Rows)
                lista.Add(MontaCurriculoExperiencia(registro));

            return lista;
        }
    }
}