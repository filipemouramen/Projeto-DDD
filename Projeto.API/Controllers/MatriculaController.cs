using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Service;
using Projeto.Domain.Interfaces;

namespace Projeto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpPost("{idAluno}/{idCurso}")]
        public IActionResult Adicionar(int idAluno, int idCurso)
        {
            try
            {
                _matriculaService.Adicionar(new Domain.Entidades.Matricula(idAluno, idCurso, DateTime.Now, true));
                return Ok("Matrícula realizada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                var matriculasObtidas = _matriculaService.ObterTodos();
                return Ok(matriculasObtidas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("aluno/{idAluno}")]
        public IActionResult ObterPorAluno(int idAluno)
        {
            try
            {
                var alunosObtidos = _matriculaService.ObterPorAluno(idAluno);
                return Ok(alunosObtidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("curso/{idCurso}")]
        public IActionResult ObterPorCurso(int idCurso)
        {
            try
            {
                var cursosObtidos = _matriculaService.ObterPorCurso(idCurso);
                return Ok(cursosObtidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}