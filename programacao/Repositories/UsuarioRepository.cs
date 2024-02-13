using MySql.Data.MySqlClient;
using Programacaodozero.Entiries;

namespace Programacaodozero.Repositories
{
    public class UsuarioRepository
    {
        private string _conectionString;

        public UsuarioRepository(string conectionString)
        {
            _conectionString = conectionString;
        }

        public int Inserir(Usuario usuario)
        {
            var cn = new MySqlConnection(_conectionString);

            var cmd = new MySqlCommand();

            cmd.Connection = cn;
            
            cmd.CommandText = @"INSERT INTO usuario
                (nome, sobrenome, telefone, email, genero, senha, usuarioGuid )
                VALUES
                (@nome,@sobrenome,@telefone,@email,@genero,@senha, @usuarioGuid)";

            cmd.Parameters.AddWithValue("nome", usuario.nome);
            cmd.Parameters.AddWithValue("sobrenome", usuario.sobrenome);
            cmd.Parameters.AddWithValue("telefone", usuario.telefone);
            cmd.Parameters.AddWithValue("email", usuario.email);
            cmd.Parameters.AddWithValue("genero", usuario.genero);
            cmd.Parameters.AddWithValue("senha", usuario.senha);
            cmd.Parameters.AddWithValue("usuarioGuid", usuario.usuarioGuid);

            cn.Open();

            var affectedrows = cmd.ExecuteNonQuery();

            cn.Clone();

            return affectedrows;

        }

        public Usuario ObterUsuarioPorEmail(string email)
        {
            Usuario usuario = null;

            MySqlConnection cn = new MySqlConnection(_conectionString);

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = cn;
            cmd.CommandText = "SELECT * FROM usuario WHERE email = @email";
            cmd.Parameters.AddWithValue("email", email);
            cn.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario();
                usuario.Id = Convert.ToInt32(reader["id"]);
                usuario.nome = reader["nome"].ToString();
                usuario.sobrenome = reader["sobrenome"].ToString();
                usuario.telefone = reader["telefone"].ToString();
                usuario.email = reader["email"].ToString();
                usuario.genero = reader["genero"].ToString();
                usuario.senha = reader["senha"].ToString();
                usuario.usuarioGuid = new Guid(reader["usuarioGuid"].ToString());

            }
            return usuario;

        }

        public Usuario ObterPorGuid(Guid usuarioGuid)
        {
            Usuario usuario = null;

            var cn = new MySqlConnection(_conectionString);
            var cmd = new MySqlCommand();

            cmd.Connection = cn;
            cmd.CommandText = "SELECT * FROM usuario WHERE usuarioGuid = @usuarioGuid";

            cmd.Parameters.AddWithValue("usuarioGuid", usuarioGuid);

            cn.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario();
                usuario.Id = Convert.ToInt32(reader["id"]);
                usuario.nome = reader["nome"].ToString();
                usuario.sobrenome = reader["sobrenome"].ToString();
                usuario.telefone = reader["telefone"].ToString();
                usuario.email = reader["email"].ToString();
                usuario.genero = reader["genero"].ToString();
                usuario.senha = reader["senha"].ToString();
                usuario.usuarioGuid = new Guid(reader["usuarioGuid"].ToString());

                var guid = reader["usuarioGuid"].ToString();

                usuario.usuarioGuid = new Guid(guid);

            }

            cn.Close();

            return usuario;
        }
    }
}
