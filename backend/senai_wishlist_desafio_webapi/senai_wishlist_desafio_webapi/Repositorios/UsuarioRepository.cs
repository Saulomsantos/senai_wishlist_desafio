using senai_wishlist_desafio_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishlist_desafio_webapi.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;" +
           "initial catalog=EscrevaAquioNomedoBD;" +
            "integrated security=true";
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = " SELECT ID, NOME, EMAIL, SENHA, TIPOUSUARIOID FROM USUARIOS" +
                                        "WHERE EMAIL = @EMAIL AND SENHA= @SENHA";

                using(SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@SENHA", senha);
                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                            
                            while (sdr.Read())
                        {
                            usuario.Id = Convert.ToInt32(sdr["ID"]);
                            usuario.Nome = sdr["NOME"].ToString();
                            usuario.Email = sdr["EMAIL"].ToString();
                            usuario.TipoUsuarioId = Convert.ToInt32(sdr["TIPOUSUARIOID"]);
                        }
                        return usuario;
                    }
                }
                return null;
            }
        }
        
        public void Cadastrar(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryInsert = "INSERT INTO USUARIOS(NOME, EMAIL,SENHA,TIPOUSUARIOID) VALUES" +
                                                            "(@NOME, @EMAIL,@SENHA,@TIPOUSUARIOID)";

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
                    cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
                    cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);
                    cmd.Parameters.AddWithValue("@TIPOUSUARIOID", usuario.TipoUsuarioId);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        //TODO fazer o listar usuarios aqui ; só falta isso e arrumar domains; lembrar tipousuarioid
    }
}
