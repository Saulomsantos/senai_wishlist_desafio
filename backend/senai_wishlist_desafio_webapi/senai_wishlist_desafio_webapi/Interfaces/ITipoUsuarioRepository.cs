using senai_wishlist_desafio_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishlist_desafio_webapi.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Retora uma lista de tipos usuários</returns>
        List<TiposUsuarios> ListarTiposUsuarios();

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario">Recebe um objeto tipoUsuario</param>
        void CadastarTipoUsuario(TiposUsuarios tipoUsuario);

        /// <summary>
        /// Altera um tipo de usuário existente
        /// </summary>
        /// <param name="usuario">Recebe um objeto tipoUsuario</param>
        void EditarTipoUsuario(TiposUsuarios tipoUsuario);
    }
}
