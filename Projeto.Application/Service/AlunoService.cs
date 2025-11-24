using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public void Adicionar(Aluno aluno)
        {
            Aluno buscaAluno = _alunoRepository.ObterPorCpf(aluno.CPF);
     
            if (buscaAluno != null)
            {
                throw new Exception("Já existe um aluno cadastrado com esse CPF.");
            }

            buscaAluno = _alunoRepository.ObterPorMatricula(aluno.Matricula);

            if (buscaAluno != null)
            {
                throw new Exception("Já existe um aluno cadastrado com essa Matrícula.");
            }

            _alunoRepository.Adicionar(aluno);
        }

        public void Atualizar(Aluno aluno)
        {
            Aluno buscaAluno = _alunoRepository.ObterPorId(aluno.AlunoID);

            if (buscaAluno == null)
            {
                throw new Exception("Aluno não encontrado.");
            }

            buscaAluno = _alunoRepository.ObterPorCpf(aluno.CPF);

            if (buscaAluno != null && buscaAluno.AlunoID != aluno.AlunoID)
            {
                throw new Exception("Já existe um aluno cadastrado com esse CPF.");
            }

            buscaAluno = _alunoRepository.ObterPorMatricula(aluno.Matricula);

            if (buscaAluno != null && buscaAluno.AlunoID != aluno.AlunoID)
            {
                throw new Exception("Já existe um aluno cadastrado com essa Matrícula.");
            }
        }

        public void Deletar(int IDaluno)
        {
            Aluno buscaAluno = _alunoRepository.ObterPorId(IDaluno);

            if (buscaAluno == null)
            {
                throw new Exception("Aluno não encontrado.");
            }
            _alunoRepository.Deletar(IDaluno);
        }

        public Aluno ObterPorCpf(string cpf)
        {
            return _alunoRepository.ObterPorCpf(cpf);
        }

        public Aluno ObterPorId(int IDaluno)
        {
            return _alunoRepository.ObterPorId(IDaluno);
        }

        public Aluno ObterPorMatricula(string matricula)
        {
            return _alunoRepository.ObterPorMatricula(matricula);
        }

        public List<Aluno> ObterTodos()
        {
            return _alunoRepository.ObterTodos();
        }
    }
}