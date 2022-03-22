using CadCurriculoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CadCurriculoMVC.DAO
{
    public class PessoaDAO
    {
        private SqlParameter[] CriaParametros(PessoaViewModel p)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("id", p.Id),
                new SqlParameter("cpf", p.CPF),
                new SqlParameter("nome", p.Nome),
                new SqlParameter("telefone", p.Telefone),
                new SqlParameter("email", p.Email),
                new SqlParameter("pretensao_salarial", p.PretensaoSalarial),
                new SqlParameter("cargo_pretendido", p.CargoPretendido),
            };

            return parameters;
        }

        private PessoaViewModel MontaCurriculoDados(DataRow registro)
        {
            return new PessoaViewModel
            {
                Id = Convert.ToInt32(registro["id"]),
                CPF = registro["cpf"].ToString(),
                Nome = registro["nome"].ToString(),
                Telefone = registro["telefone"].ToString(),
                Email = registro["email"].ToString(),
                PretensaoSalarial = Convert.ToDouble(registro["pretensao_salarial"]),
                CargoPretendido = registro["cargo_pretendido"].ToString()                
            };
        }

        public void Insert(PessoaViewModel p)
        {
            string sql = $"set dateformat dmy; " +                         
                         $"insert into pessoa " +
                         $"(id, cpf, nome, telefone, email, pretensao_salarial, cargo_pretendido) " +
                         $"values " +
                         $"({"@id"}, {"@cpf"}, {"@nome"}, {"@telefone"}, " +
                         $"{"@email"}, {"@pretensao_salarial"}, {"@cargo_pretendido"})";

            HelperDAO.ExecutaSQL(sql, CriaParametros(p));
        }

        public void Update(PessoaViewModel p)
        {
            string sql = $"set dateformat dmy; " +
                         $"UPDATE pessoa " +
                         $"SET cpf = {"@cpf"}, nome = {"@nome"}, telefone = {"@telefone"}, " +
                         $" email = {"@email"}, pretensao_salarial = {"@pretensao_salarial"}, " +
                         $"cargo_pretendido = {"@cargo_pretendido"} " +
                         $"WHERE id={"@id"}";

            HelperDAO.ExecutaSQL(sql, CriaParametros(p));
        }

        public void Delete(int id)
        {
            string sql = $"set dateformat dmy; " +
                         $"DELETE FROM pessoa " +
                         $"WHERE id = {id}";


            HelperDAO.ExecutaSQL(sql);
        }

        public PessoaViewModel Consultar(int id)
        {
            string sql = "select * from pessoa where id = " + id;

            DataTable table = HelperDAO.ExecutaSelect(sql, null);

            if (table.Rows.Count == 0)
                return null;
            else
            {                
                return MontaCurriculoDados(table.Rows[0]);
            }
        }

        public List<PessoaViewModel> Listar()
        {
            string sql = "select * from pessoa";
            DataTable table = HelperDAO.ExecutaSelect(sql, null);
            List<PessoaViewModel> lista = new List<PessoaViewModel>();
            foreach (DataRow registro in table.Rows)
                lista.Add(MontaCurriculoDados(registro));

            return lista;
        }
    }
}