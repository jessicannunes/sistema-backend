using Programacaodozero.Common;
using Programacaodozero.Entiries;
using Programacaodozero.Models;
using Programacaodozero.Repositories;

namespace Programacaodozero.Services
{
    public class UsuarioService
    {
        private string _conectionString;

        public UsuarioService(string conectionString)
        {
            _conectionString = conectionString;
        }

        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioExistente = new UsuarioRepository(_conectionString).ObterUsuarioPorEmail(email);


            if(usuarioExistente != null)
            {
                // ususario existe
                if(usuarioExistente.senha == senha)
                {
                    //senha valida
                    result.sucesso = true;
                    result.usuarioGuid = usuarioExistente.usuarioGuid;
                }
                else
                {   
                    //senha invalida
                    result.sucesso = false;
                    result.mensagem = "Ususario ou senha inválido";
                }
            }
            else
            {
                // usuario nao existe
                result.sucesso = false;
                result.mensagem = "Ususario ou senha inválido";
            }

            return result;
        }

        public CadastroResult Cadastro(
            string nome, 
            string sobrenome,
            string telefone,
            string email, 
            string genero, 
            string senha
            )
        {
            var result = new CadastroResult();

            var ususarioRepository = new UsuarioRepository(_conectionString);

            var usuario = ususarioRepository.ObterUsuarioPorEmail(email);

            if(usuario != null)
            {
                // ja existe cadastro
                result.sucesso = false;
                result.mensagem = "Ususario já existe no sistema";
            }
            else
            {
                // usuario nao existe

                usuario = new Usuario();

                usuario.nome = nome;
                usuario.sobrenome = sobrenome;
                usuario.telefone = telefone;
                usuario.email = email;
                usuario.genero = genero;
                usuario.senha = senha;
                usuario.usuarioGuid = Guid.NewGuid();

               var insertResult =  ususarioRepository.Inserir(usuario);

                if(insertResult > 0)
                {
                    result.sucesso = true;
                    result.usuarioGuid = usuario.usuarioGuid;
                }

                else
                {
                    result.sucesso = false;
                    result.mensagem = "erro ao inscerir usuario. Tente novamente";
                }
            }

            return result;
        }

        public EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var usuarioRespository = new UsuarioRepository(_conectionString);

            var usuario = usuarioRespository.ObterUsuarioPorEmail(email);

            if(usuario != null)
            {
                // nao existe
                result.sucesso = false;
                result.mensagem = "Usuario não existe para este email";
            }
            else
            {
                // usuario existe

                var assunto = "Recuperação de Senha";

                var corpo = "Sua senha é " + usuario.senha;

                var emailSender = new Emailsender();

                emailSender.Enviar(assunto, corpo, usuario.email);

                result.sucesso = true;

            }

            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_conectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }

    }

}
