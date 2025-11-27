using Microsoft.AspNetCore.Mvc;
using Projeto.API.DTO.Request;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.API.DTO.Request;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;

namespace Projeto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var listaAlunos = _alunoService.ObterTodos();

            if (listaAlunos is null) return NotFound("nenhum aluno encontrado!");

            return Ok(listaAlunos);
        }

        [HttpGet("{idAluno}")]
        public IActionResult ObterPorId(int idAluno)
        {
            var aluno = _alunoService.ObterPorId(idAluno);

            if (aluno is null) return NotFound("Aluno não encontrado!");

            return Ok(aluno);
        }

        [HttpGet("cpf/{cpf}")]
        public IActionResult ObterPorCpf(string cpf)
        {
            var aluno = _alunoService.ObterPorCpf(cpf);

            if (aluno is null) return NotFound("Aluno não encontrado!");

            return Ok(aluno);
        }

        [HttpGet("matricula/{matricula}")]
        public IActionResult ObterPorMatricula(string matricula)
        {
            var aluno = _alunoService.ObterPorMatricula(matricula);

            if (aluno is null) return NotFound("Aluno não encontrado!");

            return Ok(aluno);
        }

        [HttpDelete("{idAluno}")]
        public IActionResult Deletar(int idAluno)
        {
            var aluno = _alunoService.ObterPorId(idAluno);

            if (aluno is null) return NotFound("Aluno não encontrado!");

            _alunoService.Deletar(aluno.AlunoID);

            return Ok("Aluno deletado com sucesso!");
        }

        [HttpPost]
        public IActionResult Adicionar(NovoAlunoRequest novoAlunoRequest)
        {
            _alunoService.Adicionar(
                AlunoFactory.NovoAluno(
                    novoAlunoRequest.nome,
                    novoAlunoRequest.cpf,
                    novoAlunoRequest.matricula,
                    novoAlunoRequest.email
                    ));

            return Ok("Aluno adicionado com sucesso!");
        }

        [HttpPut]
        public IActionResult Atualizar(AtualizarAlunoRequest atualizarAlunoRequest)
        {
            _alunoService.Atualizar(
                AlunoFactory.AlunoExistente(
                    atualizarAlunoRequest.idaluno,
                    atualizarAlunoRequest.nome,
                    atualizarAlunoRequest.cpf,
                    atualizarAlunoRequest.matricula,
                    atualizarAlunoRequest.email
                    ));

            return Ok("Aluno atualizado com sucesso!");
        }
    }
}