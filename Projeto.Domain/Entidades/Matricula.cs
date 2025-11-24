using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Entidades
{
    public class Matricula
    {
        public Matricula(int idaluno, int idcurso, DateTime dataMatricula,  bool ativo)
        {
            idAluno = idaluno;
            idCurso = idcurso;
            DataMatricula = dataMatricula;
            Ativo = ativo;
        }
        public int idAluno { get; private set; }
        public int idCurso { get; private set; }
        public int idMatricula { get; private set; }
        public DateTime DataMatricula { get; private set; }
        public bool Ativo { get; private set; }
    }
}