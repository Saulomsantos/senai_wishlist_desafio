using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_wishlist_desafio_webapi.Domains;
using senai_wishlist_desafio_webapi.Interfaces;
using senai_wishlist_desafio_webapi.Repositories;
using senai_wishlist_desafio_webapi.ViewModels;

namespace senai_wishlist_desafio_webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                // Busca usuario por email e senha
                Usuarios usuarioBuscado = UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

                // Verifica se o usuario não foi encontrado 
                if (usuarioBuscado == null)
                {
                    return NotFound(new { mensagem = "Email ou Senha inválido." });
                }

                // Define os dados que serao fornecidos no token
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuarioId.ToString()),
                    new Claim("Teste","Saulo, Guilherme, Lucas")
                };

                // Chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("wishlist-chave-autenticacao"));

                // Credenciais do token - header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gerar o token
                var token = new JwtSecurityToken(
                    issuer: "wishlist.webapi",
                    audience: "wishlist.webapi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );

                // Retorna Ok com o Token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}