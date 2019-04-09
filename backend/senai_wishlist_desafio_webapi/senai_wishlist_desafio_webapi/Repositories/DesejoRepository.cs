using senai_wishlist_desafio_webapi.Domains;
using senai_wishlist_desafio_webapi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_wishlist_desafio_webapi.Repositories
{
    public class DesejoRepository : IDesejoRepository
    {
        /// <summary>
        /// Define o objeto ctx para chamar os métodos do context
        /// </summary>
        WishlistContext ctx = new WishlistContext();

        /// <summary>
        /// Cadastra um novo desejo
        /// </summary>
        /// <param name="desejo">Recebe um objeto desejo</param>
        public void CadastrarDesejo(Desejos desejo)
        {
            // Adiciona o desejo e salva no banco
            ctx.Desejos.Add(desejo);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os desejos
        /// </summary>
        /// <returns>Retorna uma lista de desejos</returns>
        public List<Desejos> ListarDesejos()
        {
            // Retorna uma lista com todos os desejos
            return ctx.Desejos.ToList();
        }
    }
}
