using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.API.DTO.Request;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;

namespace Projeto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpPost]
        public IActionResult Adicionar(NovoCursoRequest novoCursoRequest)
        {
            _cursoService.Adicionar(
                CursoFactory.NovoCurso(
                    novoCursoRequest.nome,
                    novoCursoRequest.nomeCoordenador,
                    novoCursoRequest.cargaHoraria
                    ));
            return Ok("Curso adicionado com sucesso!");
        }

        [HttpPut]
        public IActionResult Atualizar(AtualizarCursoRequest atualizarCursoRequest)
        {
            try
            {
                var cursoAtualizado = new Curso(
                    atualizarCursoRequest.cursoID,
                    atualizarCursoRequest.nome,
                    atualizarCursoRequest.nomeCoordenador,
                    atualizarCursoRequest.cargaHoraria,
                    atualizarCursoRequest.ativo
                    );

                _cursoService.Atualizar(cursoAtualizado);

                return Ok("Curso atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Deletar(int IDcurso)
        {
            try
            {
                _cursoService.Deletar(IDcurso);
                return Ok("Curso deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult VericarSeAtivo(int idcurso)
        {
            try
            {
                bool ativo = _cursoService.VerificarSeAtivo(idcurso);
                return Ok(ativo);
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
                var cursosobtidos = _cursoService.ObterTodos();
                return Ok(cursosobtidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}