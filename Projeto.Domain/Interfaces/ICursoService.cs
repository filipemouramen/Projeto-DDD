using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain.Entidades;

namespace Projeto.Domain.Interfaces
{
    public interface ICursoService
    {
        public void Adicionar(Curso curso);
        public void Atualizar(Curso curso);
        void Deletar(int IDcurso);
        public bool VerificarSeAtivo(int IDcurso);
        public List<Curso> ObterTodos();
        public Curso ObterPorId(int IDcurso);
    }
}