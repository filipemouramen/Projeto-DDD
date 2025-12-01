using Microsoft.Extensions.Configuration;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Repository
{
    public class CursoRepository(IConfiguration configuration) : ICursoRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string não pode ser nula.");
        public void Adicionar(Curso curso)
        {
            var sql = "INSERT INTO desenvolvimento.Curso (nome, nomeCoordenador, cargaHoraria, ativo) VALUES (@nome, @nomeCoordenador, @cargaHoraria, @ativo)";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nome", curso.Nome);
            cmd.Parameters.AddWithValue("@nomeCoordenador", curso.NomeCoordenador);
            cmd.Parameters.AddWithValue("@cargaHoraria", curso.CargaHoraria);
            cmd.Parameters.AddWithValue("@ativo", curso.Ativo);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Atualizar(Curso curso)
        {
            var sql = "UPDATE desenvolvimento.Curso SET nome = @nome, nomeCoordenador = @nomeCoordenador, cargaHoraria = @cargaHoraria, ativo = @ativo WHERE idCurso = @idCurso";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idCurso", curso.idCurso);
            cmd.Parameters.AddWithValue("@nome", curso.Nome);
            cmd.Parameters.AddWithValue("@nomeCoordenador", curso.NomeCoordenador);
            cmd.Parameters.AddWithValue("@cargaHoraria", curso.CargaHoraria);
            cmd.Parameters.AddWithValue("@ativo", curso.Ativo);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Deletar(int IDcurso)
        {
            var sql = "DELETE FROM desenvolvimento.Curso WHERE idCurso = @idCurso";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idCurso", IDcurso);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public Curso ObterPorId(int IDcurso)
        {
            var sql = "SELECT idCurso, nome, nomeCoordenador, cargaHoraria, ativo FROM desenvolvimento.Curso WHERE idCurso = @idCurso";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idCurso", IDcurso);

            conn.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Curso(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetDouble(3),
                    reader.GetBoolean(4)
                );
            }
            throw new Exception("Curso não encontrado ou inexistente.");
        }

        public List<Curso> ObterTodos()
        {
            var listaCursos = new List<Curso>();
            var sql = "SELECT idCurso, nome, nomeCoordenador, cargaHoraria, ativo FROM desenvolvimento.Curso";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            conn.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var curso = new Curso(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetDouble(3),
                    reader.GetBoolean(4)
                );
                listaCursos.Add(curso);
            }
            return listaCursos;
        }

        public bool VerificarSeAtivo(int IDcurso)
        {
            throw new NotImplementedException();
        }
    }
}