using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Collections.Generic; 

namespace Projeto.Data.Repository
{
    public class AlunoRepository(IConfiguration configuration) : IAlunoRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string não pode ser nula.");

        public void Adicionar(Aluno aluno)
        {
            var sql = "INSERT INTO desenvolvimento.Aluno (cpf,nome,email,matricula) VALUES (@cpf, @nome, @email, @matricula)";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@cpf", aluno.CPF);
            cmd.Parameters.AddWithValue("@nome", aluno.Nome);
            cmd.Parameters.AddWithValue("@email", aluno.Email);
            cmd.Parameters.AddWithValue("@matricula", aluno.Matricula);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Atualizar(Aluno aluno)
        {
            var sql = "UPDATE desenvolvimento.Aluno SET nome = @nome, cpf = @cpf, matricula = @matricula, email = @email WHERE **AlunoID** = @idAluno";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idAluno", aluno.AlunoID);
            cmd.Parameters.AddWithValue("@nome", aluno.Nome);
            cmd.Parameters.AddWithValue("@cpf", aluno.CPF);
            cmd.Parameters.AddWithValue("@matricula", aluno.Matricula);
            cmd.Parameters.AddWithValue("@email", aluno.Email);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Deletar(int idAluno)
        {
            var sql = "DELETE FROM desenvolvimento.Aluno WHERE **AlunoID** = @idAluno";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idAluno", idAluno);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public Aluno ObterPorCpf(string cpf)
        {
            var sql = "SELECT AlunoID, nome, cpf, matricula, email FROM desenvolvimento.Aluno WHERE cpf = @cpf";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            conn.Open();
            using var reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return new Aluno(
                    reader.GetInt32(0),
                    reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                    reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                    reader.IsDBNull(4) ? string.Empty : reader.GetString(4)
                );
            }
            return null;
        }

        public Aluno ObterPorId(int idAluno)
        {
            var sql = "SELECT AlunoID, nome, cpf, matricula, email FROM desenvolvimento.Aluno WHERE **AlunoID** = @idAluno";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idAluno", idAluno);

            conn.Open();
            using var reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return new Aluno(
                    reader.GetInt32(0),
                    reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                    reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                    reader.IsDBNull(4) ? string.Empty : reader.GetString(4)
                );
            }

            return null;
        }

        public Aluno ObterPorMatricula(string matricula)
        {
            var sql = "SELECT AlunoID, nome, cpf, matricula, email FROM desenvolvimento.Aluno WHERE matricula = @matricula";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@matricula", matricula);
            conn.Open();
            using var reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return new Aluno(
                    reader.GetInt32(0),
                    reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                    reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                    reader.IsDBNull(4) ? string.Empty : reader.GetString(4)
                );
            }
            return null;
        }

        public List<Aluno> ObterTodos()
        {
            var lista = new List<Aluno>();
            var sql = "SELECT AlunoID, nome, cpf, matricula, email FROM desenvolvimento.Aluno";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var aluno = new Aluno(
                    reader.GetInt32(0),
                    reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                    reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                    reader.IsDBNull(4) ? string.Empty : reader.GetString(4)
                );
                lista.Add(aluno);
            }
            return lista;
        }
    }
}