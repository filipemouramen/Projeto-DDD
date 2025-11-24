using Projeto.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Interfaces
{
    public interface IAlunoRepository 
    {
        public void Adicionar(Aluno aluno);

        public void Atualizar(Aluno aluno);

        void Deletar(int IDaluno);

        public List<Aluno> ObterTodos();

        public Aluno ObterPorId (int IDaluno);

        public Aluno ObterPorCpf(string cpf);

        public Aluno ObterPorMatricula(string matricula);
    }
}
