using CadastrosGerais.Common;
using CadastrosGerais.Models;
using CadastrosGerais.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CadastrosGerais.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsAllowAll")]
    public class NotaAvaliacaoController : ControllerBase
    {
        private readonly INotaAvaliacaoRepository _notaAvaliacaoRepository;

        public NotaAvaliacaoController(INotaAvaliacaoRepository NotaAvaliacaoRepository)
        {
            _notaAvaliacaoRepository = NotaAvaliacaoRepository;
        }

        /// <summary>
        /// Insere um objeto para cadastro.
        /// </summary>
        /// <returns>Insere Cadastro</returns>
        /// <response code="200">Cadastro inserido</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        [HttpPost("Cria")]
        public IActionResult NotaAvaliacaoAdd(NotaAvaliacaoModel dados)
        {
            try
            {
                return Ok(_notaAvaliacaoRepository.NotaAvaliacaoAdd(dados));
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("NotaAvaliacaoAdd", "Erro ao buscar os NotaAvaliacaos", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "NotaAvaliacaoAdd", ex.Message));
            }
        }

        /// <summary>
        /// Get todos.
        /// </summary>
        /// <returns>Exibe todos os cadastros</returns>
        /// <response code="200">Ok</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        /// 
        [HttpGet("GetAll")]
        public IActionResult NotaAvaliacaoGetAll()
        {
            try
            {
                return Ok(_notaAvaliacaoRepository.NotaAvaliacaoGetAll());
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("CadastroGet", "Erro ao buscar todas as avarias", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "CadastroGet", ex.Message));
            }
        }

        /// <summary>
        /// Atualiza dados.
        /// </summary>
        /// <returns>Insere Cadastro</returns>
        /// <response code="200">Cadastro inserido</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        /// 
        [HttpPost("Update")]
        public IActionResult NotaAvaliacaoUpd(NotaAvaliacaoModel dados)
        {
            try
            {
                return Ok(_notaAvaliacaoRepository.NotaAvaliacaoUpd(dados));
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("CadastroUpd", "Erro ao buscar todas as avarias", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "CadastroUpd", ex.Message));
            }
        }

        /// <summary>
        /// Deletar dados.
        /// </summary>
        /// <returns>Insere Cadastro</returns>
        /// <response code="200">Cadastro inserido</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        /// 
        [HttpDelete("Deleta")]
        public IActionResult NotaAvaliacaoDel(int id)
        {
            try
            {
                return Ok(_notaAvaliacaoRepository.NotaAvaliacaoDel(id));
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("CadastroDel", "Erro ao buscar todas as avarias", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "CadastroDel", ex.Message));
            }
        }
    }
}
