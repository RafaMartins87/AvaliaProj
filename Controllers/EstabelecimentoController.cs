using CadastrosGerais.Common;
using CadastrosGerais.Models;
using CadastrosGerais.Repository;
using Microsoft.AspNetCore.Authorization;
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
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;

        public EstabelecimentoController(IEstabelecimentoRepository estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }

        /// <summary>
        /// Insere um objeto para cadastro.
        /// </summary>
        /// <returns>Insere Cadastro</returns>
        /// <response code="200">Cadastro inserido</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        [HttpPost("Cria")]
        public IActionResult EstabelecimentoAdd(EstabelecimentoModel dados)
        {
            try
            {
                return Ok(_estabelecimentoRepository.EstabelecimentoAdd(dados));
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("EstabelecimentoAdd", "Erro ao buscar os estabelecimentos", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "EstabelecimentoAdd", ex.Message));
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
        public IActionResult EstabelecimentoGetAll()
        {
            try
            {
                return Ok(_estabelecimentoRepository.EstabelecimentoGetAll());
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
        public IActionResult EstabelecimentoUpd(EstabelecimentoModel dados)
        {
            try
            {
                return Ok(_estabelecimentoRepository.EstabelecimentoUpd(dados));
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
        public IActionResult EstabelecimentoDel(int id)
        {
            try
            {
                return Ok(_estabelecimentoRepository.EstabelecimentoDel(id));
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("CadastroDel", "Erro ao buscar todas as avarias", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "CadastroDel", ex.Message));
            }
        }
    }
}
