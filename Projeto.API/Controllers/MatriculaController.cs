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

        [HttpPost]
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

        [HttpGet]
        public IActionResult ObterPorAluno(int IDAluno)
        {
            try
            {
                var alunosObtidos = _matriculaService.ObterPorAluno(IDAluno);
                return Ok(alunosObtidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ObterPorCurso(int IDCurso)
        {
            try
            {
                var cursosObtidos = _matriculaService.ObterPorCurso(IDCurso);
                return Ok(cursosObtidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}