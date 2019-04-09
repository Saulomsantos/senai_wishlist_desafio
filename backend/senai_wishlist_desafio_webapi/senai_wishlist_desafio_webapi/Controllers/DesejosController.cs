using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_wishlist_desafio_webapi.Domains;
using senai_wishlist_desafio_webapi.Interfaces;
using senai_wishlist_desafio_webapi.Repositories;

namespace senai_wishlist_desafio_webapi.Controllers
{   [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DesejosController : ControllerBase
    {
        private IDesejoRepository DesejoRepository { get; set; }

        public DesejosController()
        {
            DesejoRepository = new DesejoRepository();
        }

        /// <summary>
        /// Lista todos os desejos
        /// </summary>
        /// <returns>Retorna um status code com uma lista de desejos em caso de sucesso</returns>
        [Authorize]
        [HttpGet]
        public IActionResult ListarDesejos()
        {
            try
            {
                return Ok(DesejoRepository.ListarDesejos());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Cadastra um novo desejo
        /// </summary>
        /// <param name="desejo">Recebe um objeto desejo</param>
        /// <returns>Retorna um status code</returns>
        [Authorize]
        [HttpPost]
        public IActionResult CadastrarDesejo(Desejos desejo)
        {
            try
            {
                DesejoRepository.CadastrarDesejo(desejo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}