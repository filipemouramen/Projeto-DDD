using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Entidades
{
    //Classe RICA - GET público e SET privados 
    public class Aluno
    {
        public Aluno(int idaluno, string nome, string cpf, string matricula, string email)
        {
            AlunoID = idaluno;
            Nome = nome;
            CPF = cpf;
            Matricula = matricula;
            Email = email;
        }

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Matricula { get; private set; }
        public string Email { get; private set; }
        public int AlunoID { get; private set; }
    }

    public static class AlunoFactory //classe pra criar outra classe
    {
        public static Aluno NovoAluno(
            string pnome,
            string pcpf,
            string pmatricula,
            string pemail
            )
        {
            return new Aluno(0, pnome, pcpf, pmatricula, pemail);
        }

        public static Aluno AlunoExistente(int pidAluno, string pnome, string pcpf, string pmatricula, string pemail)
        {
            return new Aluno(pidAluno, pnome, pcpf, pmatricula, pemail);
        }
    }
}