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
    public class AvaliacaoController : ControllerBase
    {

        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoController(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        /// <summary>
        /// Insere um objeto para cadastro.
        /// </summary>
        /// <returns>Insere Cadastro</returns>
        /// <response code="200">Cadastro inserido</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        [HttpPost("Cria")]
        public IActionResult AvaliacaoAdd(AvaliacaoModel dados)
        {
            try
            {
                return Ok(_avaliacaoRepository.AvaliacaoAdd(dados));
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("AvaliacaoAdd", "Erro ao buscar os Avaliacaos", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "AvaliacaoAdd", ex.Message));
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
        public IActionResult AvaliacaoGetAll()
        {
            try
            {
                return Ok(_avaliacaoRepository.AvaliacaoGetAll());
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
        public IActionResult AvaliacaoUpd(AvaliacaoModel dados)
        {
            try
            {
                return Ok(_avaliacaoRepository.AvaliacaoUpd(dados));
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
        public IActionResult AvaliacaoDel(int id)
        {
            try
            {
                return Ok(_avaliacaoRepository.AvaliacaoDel(id));
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("CadastroDel", "Erro ao buscar todas as avarias", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "CadastroDel", ex.Message));
            }
        }
    }
}
