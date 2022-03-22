using CadCurriculoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CadCurriculoMVC.DAO
{
    public class FormacaoDAO
    {
        private SqlParameter[] CriaParametros(PessoaViewModel p, FormacaoViewModel f)
        {
            SqlParameter[] parameters = new SqlParameter[17];

            parameters[0] = new SqlParameter("formacao_id", f.FormacaoId);
            parameters[1] = new SqlParameter("pessoa_id", p.Id);

            if (f.NomeCurso_1 == null)
            {
                parameters[2] = new SqlParameter("nome_curso1", "".Trim());
                parameters[3] = new SqlParameter("mes_formacao1", DBNull.Value);
                parameters[4] = new SqlParameter("ano_formacao1", DBNull.Value);
            }
            else
            {
                parameters[2] = new SqlParameter("nome_curso1", f.NomeCurso_1);
                if (f.MesFormacao_1 != null)
                    parameters[3] = new SqlParameter("mes_formacao1", f.MesFormacao_1);
                if (f.AnoFormacao_1 != null)
                    parameters[4] = new SqlParameter("ano_formacao1", f.AnoFormacao_1);
            }

            if (f.NomeCurso_2 == null)
            {
                parameters[5] = new SqlParameter("nome_curso2", "".Trim());
                parameters[6] = new SqlParameter("mes_formacao2", DBNull.Value);
                parameters[7] = new SqlParameter("ano_formacao2", DBNull.Value);
            }
            else
            {
                parameters[5] = new SqlParameter("nome_curso2", f.NomeCurso_2);
                if (f.MesFormacao_2 != null)
                    parameters[6] = new SqlParameter("mes_formacao2", f.MesFormacao_2);
                if (f.AnoFormacao_2 != null)
                    parameters[7] = new SqlParameter("ano_formacao2", f.AnoFormacao_2);
            }

            if (f.NomeCurso_3 == null)
            {
                parameters[8] = new SqlParameter("nome_curso3", "".Trim());
                parameters[9] = new SqlParameter("mes_formacao3", DBNull.Value);
                parameters[10] = new SqlParameter("ano_formacao3", DBNull.Value);
            }
            else
            {
                parameters[8] = new SqlParameter("nome_curso3", f.NomeCurso_3);
                if (f.MesFormacao_3 != null)
                    parameters[9] = new SqlParameter("mes_formacao3", f.MesFormacao_3);
                if (f.AnoFormacao_3 != null)
                    parameters[10] = new SqlParameter("ano_formacao3", f.AnoFormacao_3);
            }

            if (f.NomeCurso_4 == null)
            {
                parameters[11] = new SqlParameter("nome_curso4", "".Trim());
                parameters[12] = new SqlParameter("mes_formacao4", DBNull.Value);
                parameters[13] = new SqlParameter("ano_formacao4", DBNull.Value);
            }
            else
            {
                parameters[11] = new SqlParameter("nome_curso4", f.NomeCurso_4);
                if (f.MesFormacao_4 != null)
                    parameters[12] = new SqlParameter("mes_formacao4", f.MesFormacao_4);
                if (f.AnoFormacao_4 != null)
                    parameters[13] = new SqlParameter("ano_formacao4", f.AnoFormacao_4);
            }

            if (f.NomeCurso_5 == null)
            {
                parameters[14] = new SqlParameter("nome_curso5", "".Trim());
                parameters[15] = new SqlParameter("mes_formacao5", DBNull.Value);
                parameters[16] = new SqlParameter("ano_formacao5", DBNull.Value);
            }
            else
            {
                parameters[14] = new SqlParameter("nome_curso5", f.NomeCurso_5);
                if (f.MesFormacao_5 != null)
                    parameters[15] = new SqlParameter("mes_formacao5", f.MesFormacao_5);
                if (f.AnoFormacao_5 != null)
                    parameters[16] = new SqlParameter("ano_formacao5", f.AnoFormacao_5);
            }

            return parameters;
        }

        private FormacaoViewModel MontaCurriculoFormacao(DataRow registro)
        {
            FormacaoViewModel f = new FormacaoViewModel();

            f.FormacaoId = Convert.ToInt32(registro["formacao_id"]);
            if (registro["nome_curso1"] != DBNull.Value)
                f.NomeCurso_1 = registro["nome_curso1"].ToString();

            if (registro["mes_formacao1"] != null)
                f.MesFormacao_1 = Convert.ToInt32(registro["mes_formacao1"]);

            if (registro["ano_formacao1"] != null)
                f.AnoFormacao_1 = Convert.ToInt32(registro["ano_formacao1"]);

            if (registro["nome_curso2"] != DBNull.Value)
                f.NomeCurso_2 = registro["nome_curso2"].ToString();

            if (registro["mes_formacao2"] != null && registro["mes_formacao2"] != System.DBNull.Value)
                f.MesFormacao_2 = Convert.ToInt32(registro["mes_formacao2"]);

            if (registro["ano_formacao2"] != null && registro["ano_formacao2"] != System.DBNull.Value)
                f.AnoFormacao_2 = Convert.ToInt32(registro["ano_formacao2"]);

            if (registro["nome_curso3"] != DBNull.Value && registro["nome_curso3"] != System.DBNull.Value)
                f.NomeCurso_3 = registro["nome_curso3"].ToString();

            if (registro["mes_formacao3"] != null && registro["mes_formacao3"] != System.DBNull.Value)
                f.MesFormacao_3 = Convert.ToInt32(registro["mes_formacao3"]);

            if (registro["ano_formacao3"] != null && registro["ano_formacao3"] != System.DBNull.Value)
                f.AnoFormacao_3 = Convert.ToInt32(registro["ano_formacao3"]);

            if (registro["nome_curso4"] != DBNull.Value && registro["nome_curso4"] != System.DBNull.Value)
                f.NomeCurso_4 = registro["nome_curso4"].ToString();

            if (registro["mes_formacao4"] != null && registro["mes_formacao4"] != System.DBNull.Value)
                f.MesFormacao_4 = Convert.ToInt32(registro["mes_formacao4"]);

            if (registro["ano_formacao4"] != null && registro["ano_formacao4"] != System.DBNull.Value)
                f.AnoFormacao_4 = Convert.ToInt32(registro["ano_formacao4"]);

            if (registro["nome_curso5"] != DBNull.Value && registro["nome_curso5"] != System.DBNull.Value)
                f.NomeCurso_5 = registro["nome_curso5"].ToString();

            if (registro["mes_formacao5"] != null && registro["mes_formacao5"] != System.DBNull.Value)
                f.MesFormacao_5 = Convert.ToInt32(registro["mes_formacao5"]);

            if (registro["ano_formacao5"] != null && registro["ano_formacao5"] != System.DBNull.Value)
                f.AnoFormacao_5 = Convert.ToInt32(registro["ano_formacao5"]);

            return f;
        }

        public void Insert(PessoaViewModel p, FormacaoViewModel f)
        {
            string sql = $"set dateformat dmy; " +
                         $"insert into formacao " +
                         $"(formacao_id, pessoa_id, " +
                         $"nome_curso1, mes_formacao1, ano_formacao1, " +
                         $"nome_curso2, mes_formacao2, ano_formacao2, " +
                         $"nome_curso3, mes_formacao3, ano_formacao3, " +
                         $"nome_curso4, mes_formacao4, ano_formacao4, " +
                         $"nome_curso5, mes_formacao5, ano_formacao5)" +
                         $"values " +                         
                         $"({"@formacao_id"}, {"@pessoa_id"}," +
                         $"{"@nome_curso1"}, {"@mes_formacao1"}, {"@ano_formacao1"}, " +
                         $"{"@nome_curso2"}, {"@mes_formacao2"}, {"@ano_formacao2"}," +
                         $"{"@nome_curso3"}, {"@mes_formacao3"}, {"@ano_formacao3"}," +
                         $"{"@nome_curso4"}, {"@mes_formacao4"}, {"@ano_formacao4"}," +
                         $"{"@nome_curso5"}, {"@mes_formacao5"}, {"@ano_formacao5"})";

            HelperDAO.ExecutaSQL(sql, CriaParametros(p, f));
        }

        public void Update(PessoaViewModel p, FormacaoViewModel f)
        {
            string sql = $"set dateformat dmy; " +
                         $"UPDATE formacao " +
                         $"SET pessoa_id = {"@pessoa_id"}, " +
                         $"nome_curso1 = {"@nome_curso1"}, mes_formacao1 = {"@mes_formacao1"}, ano_formacao1 = {"@ano_formacao1"}, " +
                         $"nome_curso2 = {"@nome_curso2"}, mes_formacao2 = {"@mes_formacao2"}, ano_formacao2 = {"@ano_formacao2"}, " +
                         $"nome_curso3 = {"@nome_curso3"}, mes_formacao3 = {"@mes_formacao3"}, ano_formacao3 = {"@ano_formacao3"}, " +
                         $"nome_curso4 = {"@nome_curso4"}, mes_formacao4 = {"@mes_formacao4"}, ano_formacao4 = {"@ano_formacao4"}, " +
                         $"nome_curso5 = {"@nome_curso5"}, mes_formacao5 = {"@mes_formacao5"}, ano_formacao5 = {"@ano_formacao5"} " +
                         $"WHERE formacao_id={"@formacao_id"}";

            HelperDAO.ExecutaSQL(sql, CriaParametros(p, f));
        }

        public void Delete(int id)
        {
            string sql = $"set dateformat dmy; " +
                         $"DELETE FROM formacao " +
                         $"WHERE pessoa_id = {id} ";


            HelperDAO.ExecutaSQL(sql);
        }
        public FormacaoViewModel Consultar(int id)
        {
            string sql = "select * from formacao where pessoa_id = " + id;
                   

            DataTable table = HelperDAO.ExecutaSelect(sql, null);

            if (table.Rows.Count == 0)
                return null;
            else
            {
                return MontaCurriculoFormacao(table.Rows[0]);
            }
        }

        public List<FormacaoViewModel> Listar()
        {
            string sql = "select * from formacao";
            DataTable table = HelperDAO.ExecutaSelect(sql, null);
            List<FormacaoViewModel> lista = new List<FormacaoViewModel>();
            foreach (DataRow registro in table.Rows)
                lista.Add(MontaCurriculoFormacao(registro));

            return lista;
        }
    }
}