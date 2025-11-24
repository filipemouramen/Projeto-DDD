using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Entidades
{
    public class Curso
    {
        public Curso(int idcurso, string nome, string nomeCoordenador, double cargahoraria, bool ativo)
        {
            idCurso = idcurso;
            Nome = nome;
            NomeCoordenador = nomeCoordenador;
            CargaHoraria = cargahoraria;
            Ativo = ativo;
        }

        public int idCurso { get; private set; }
        public string Nome { get; private set; }
        public string NomeCoordenador { get; private set; }
        public double CargaHoraria { get; private set; }
        public bool Ativo { get; private set; }
    }

    public static class CursoFactory
    {
        public static Curso NovoCurso(
            string pnome,
            string pnomeCoordenador,
            double pcargaHoraria
            )
        {
            return new Curso(0, pnome, pnomeCoordenador, pcargaHoraria, true);
        }
    }
}