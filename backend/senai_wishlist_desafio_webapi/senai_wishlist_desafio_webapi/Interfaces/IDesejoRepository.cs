using senai_wishlist_desafio_webapi.Domains;
using System.Collections.Generic;

namespace senai_wishlist_desafio_webapi.Interfaces
{
    interface IDesejoRepository
    {
        /// <summary>
        /// Lista todos os desejos
        /// </summary>
        /// <returns>Retorna uma lista com todos os desejos</returns>
        List<Desejos> ListarDesejos();

        /// <summary>
        /// Cadastra um novo desejo
        /// </summary>
        /// <param name="desejo">Recebe um objeto desejo</param>
        void CadastrarDesejo(Desejos desejo);
    }
}
