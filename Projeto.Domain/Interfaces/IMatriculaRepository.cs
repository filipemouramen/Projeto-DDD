using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain.Entidades;

namespace Projeto.Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        public void Adicionar(Matricula matricula);
        public void Atualizar(Matricula matricula);
        void Deletar(int IDmatricula);
        public bool VerificarSeAtivo(int IDmatricula);
        public List<Matricula> ObterTodos();
        public Matricula ObterPorId(int IDmatricula);
        public List<Matricula> ObterPorAluno(int IDaluno);
        public List<Matricula> ObterPorCurso(int IDcurso);
    }
}