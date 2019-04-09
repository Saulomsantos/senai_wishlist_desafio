using System;
using System.Collections.Generic;

namespace senai_wishlist_desafio_webapi.Domains
{
    public partial class Desejos
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }

        public Usuarios Usuario { get; set; }
    }
}
