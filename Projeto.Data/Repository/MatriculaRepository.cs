using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace Projeto.Data.Repository
{
    public class MatriculaRepository(IConfiguration configuration) : IMatriculaRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string não pode ser nula.");
        public void Adicionar(Matricula matricula)
        {
            var sql = @"INSERT INTO Matriculas (idAluno, idCurso, DataMatricula, Ativo) VALUES (@idAluno, @idCurso, @DataMatricula, @Ativo)";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idAluno", matricula.idAluno);
            cmd.Parameters.AddWithValue("@idCurso", matricula.idCurso);
            cmd.Parameters.AddWithValue("@DataMatricula", matricula.DataMatricula);
            cmd.Parameters.AddWithValue("@Ativo", matricula.Ativo);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Matricula> ObterPorAluno(int IDaluno)
        {
            var sql = @"SELECT idAluno, idCurso, DataMatricula, Ativo FROM Matriculas WHERE idAluno = @idAluno";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idAluno", IDaluno);

            conn.Open();

            using var reader = cmd.ExecuteReader();

            var matriculas = new List<Matricula>();
            while (reader.Read())
            {
                matriculas.Add(new Matricula(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetDateTime(2),
                    reader.GetBoolean(3)
                ));
            }
            return matriculas;
        }

        public List<Matricula> ObterPorCurso(int IDcurso)
        {
            var listaCurso = new List<Matricula>();
            var sql = @"SELECT idAluno, idCurso, DataMatricula, Ativo FROM Matriculas WHERE idCurso = @idCurso";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idCurso", IDcurso);

            conn.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listaCurso.Add(new Matricula(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetDateTime(2),
                    reader.GetBoolean(3)
                ));
            }
            return listaCurso;
        }

        public List<Matricula> ObterTodos()
        {
            var listaAlunos = new List<Matricula>();
            var sql = "SELECT idAluno, idCurso, DataMatricula, Ativo FROM Matriculas";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            conn.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var matricula = new Matricula(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetDateTime(2),
                    reader.GetBoolean(3)
                );
                listaAlunos.Add(matricula);
            }
            return listaAlunos;
        }
    }
}