using CRUDAPI.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CRUDAPI.Infra
{
    public class PessoaRepository : AbstractRepository<Pessoa, int>
    {
        ///<summary>Exclui uma pessoa pela entidade
        ///<param name="entity">Referência de Pessoa que será excluída.</param>
        ///</summary>
        ///
        string StringConnection;
        private readonly IConfiguration _configuration;
        public PessoaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            StringConnection = _configuration.GetValue<string>("ConnectionStrings:ConexaoBD"); 
        }
        
        public override void Delete(Pessoa entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE Pessoa Where PessoaId=@PessoaId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PessoaId", entity.PessoaId);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        ///<summary>Exclui uma pessoa pelo ID
        ///<param name="id">Id do registro que será excluído.</param>
        ///</summary>
        public override void DeleteById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE Pessoa Where PessoaId=@PessoaId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PessoaId", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        ///<summary>Obtém todas as pessoas
        ///<returns>Retorna as pessoas cadastradas.</returns>
        ///</summary>
        public override List<Pessoa> GetAll()
        {
            string sql = "Select PessoaId, Nome, CPF, Email, Telefone, Sexo, DataNascimento FROM Pessoa ORDER BY Nome";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Pessoa> list = new List<Pessoa>();
                Pessoa p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p = new Pessoa();
                            p.PessoaId = (int)reader["PessoaId"];
                            p.Nome = reader["Nome"].ToString();
                            p.CPF = reader["CPF"].ToString();
                            p.Email = reader["Email"].ToString();
                            p.Telefone = reader["Telefone"].ToString();
                            p.Sexo = reader["Sexo"].ToString();
                            p.DataNascimento = Convert.ToDateTime(reader["DataNascimento"]);
                            list.Add(p);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return list;
            }
        }

        ///<summary>Obtém uma pessoa pelo ID
        ///<param name="id">Id do registro que obtido.</param>
        ///<returns>Retorna uma referência de Pessoa do registro encontrado ou null se ele não for encontrado.</returns>
        ///</summary>
        public override Pessoa GetById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "Select PessoaId, Nome, CPF, Email, Telefone, Sexo, DataNascimento FROM Pessoa WHERE PessoaId=@PessoaId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PessoaId", id);
                Pessoa p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new Pessoa();
                                p.PessoaId = (int)reader["PessoaId"];
                                p.Nome = reader["Nome"].ToString();
                                p.CPF = reader["CPF"].ToString();
                                p.Email = reader["Email"].ToString();
                                p.Telefone = reader["Telefone"].ToString();
                                p.Sexo = reader["Sexo"].ToString();
                                p.DataNascimento = Convert.ToDateTime(reader["DataNascimento"]);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return p;
            }
        }

        ///<summary>Salva a pessoa no banco
        ///<param name="entity">Referência de Pessoa que será salva.</param>
        ///</summary>
        public override void Save(Pessoa entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO Pessoa (Nome, CPF, Email, Telefone, Sexo, DataNascimento) VALUES (@Nome, @CPF, @Email, @Telefone, @Sexo, @DataNascimento)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@CPF", entity.CPF);
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                cmd.Parameters.AddWithValue("@Sexo", entity.Sexo);
                cmd.Parameters.AddWithValue("@DataNascimento", entity.DataNascimento);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        ///<summary>Atualiza a pessoa no banco
        ///<param name="entity">Referência de Pessoa que será atualizada.</param>
        ///</summary>
        public override void Update(Pessoa entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE Pessoa SET Nome=@Nome, CPF=@CPF, Email=@Email, Telefone=@Telefone, Sexo=@Sexo, DataNascimento=@DataNascimento Where PessoaId=@PessoaId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PessoaId", entity.PessoaId);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@CPF", entity.CPF);
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                cmd.Parameters.AddWithValue("@Sexo", entity.Sexo);
                cmd.Parameters.AddWithValue("@DataNascimento", entity.DataNascimento);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
