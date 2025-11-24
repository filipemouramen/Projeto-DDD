using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.Service
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly ICursoRepository _cursoRepository;

        public MatriculaService(IMatriculaRepository matriculaRepository, IAlunoRepository alunoRepository, ICursoRepository cursoRepository)
        {
            _matriculaRepository = matriculaRepository;
            _alunoRepository = alunoRepository;
            _cursoRepository = cursoRepository;
        }

        public void Adicionar(Matricula matricula)
        {
            var aluno = _alunoRepository.ObterPorId(matricula.idAluno);
            if (aluno == null)
                throw new Exception("Aluno não encontrado ou inexistente.");

            var curso = _cursoRepository.ObterPorId(matricula.idCurso);
            if (curso == null)
                throw new Exception("Curso não encontrado ou inexistente.");

            if (!curso.Ativo)
                throw new Exception("Não é possível matricular em um curso inativo.");

            var matriculasAlunos = _matriculaRepository.ObterPorAluno(matricula.idAluno);
            bool jaMatriculado = matriculasAlunos.Any(m => m.idCurso == matricula.idCurso);

            if (jaMatriculado)
                throw new Exception("Aluno já está matriculado neste curso.");

            var novaMatricula = new Matricula(matricula.idAluno, matricula.idCurso, DateTime.Now, true);

            _matriculaRepository.Adicionar(novaMatricula);
        }

        public void Atualizar(Matricula matricula)
        {
            Matricula buscaMatricula = _matriculaRepository.ObterPorId(matricula.idMatricula);

            if (buscaMatricula == null)
                throw new Exception("Matrícula não encontrada ou inexistente.");

            _matriculaRepository.Atualizar(matricula);
        }

        public void Deletar(int IDmatricula)
        {
            Matricula buscaMatricula = _matriculaRepository.ObterPorId(IDmatricula);

            if (buscaMatricula == null)
                throw new Exception("Matrícula não encontrada ou inexistente.");

            _matriculaRepository.Deletar(IDmatricula);
        }

        public bool VerificarSeAtivo(int IDmatricula)
        {
            if (_matriculaRepository.ObterPorId(IDmatricula) == null)
                throw new Exception("Matrícula não encontrada ou inexistente.");

            return _matriculaRepository.VerificarSeAtivo(IDmatricula);
        }

        public List<Matricula> ObterTodos()
        {
            return _matriculaRepository.ObterTodos();
        }

       public Matricula ObterPorId(int IDmatricula)
        {
            var matricula = _matriculaRepository.ObterPorId(IDmatricula);

            if (matricula == null)
                throw new Exception("Matrícula não encontrada ou inexistente.");

            if (!matricula.Ativo)
                throw new Exception("Matrícula inativa.");

            return matricula;
        }

        public List<Matricula> ObterPorAluno(int IDAluno)
        {
            var matriculas = _matriculaRepository.ObterPorAluno(IDAluno);

            if (matriculas == null || !matriculas.Any())
                throw new Exception("Nenhuma matrícula encontrada para o aluno informado.");

            return matriculas;
        }

        public List<Matricula> ObterPorCurso(int IDCurso)
        {
            var matriculas = _matriculaRepository.ObterPorCurso(IDCurso);
            if (matriculas == null || !matriculas.Any())
                throw new Exception("Nenhuma matrícula encontrada para o curso informado.");

            return matriculas;
        }
    }
}