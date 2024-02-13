using Microsoft.AspNetCore.Mvc;
using Programacaodozero.Models;
using Programacaodozero.Services;

namespace Programacaodozero.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("login")]
        [HttpPost]
        public LoginResult Login( LoginRequest request)
        {
            var result = new LoginResult();

            if(request== null)
            {
                result.sucesso = false;
                result.mensagem = "Paramentro request veio nulo";
            }
            else if (request.email == "")
            {
                result.sucesso = false;
                result.mensagem = "E-mail obrigatório";
            }
            else if (request.senha == "")
            {
                result.sucesso = false;
                result.mensagem = "senha obrigatória";
            }
            else
            {
                var conectionString = _configuration.GetConnectionString("programacaoDoZeroDb");


                var usuarioService = new UsuarioService(conectionString);

                result = usuarioService.Login(request.email, request.senha);
            }

            return result;
        }

        [Route("cadastro")]
        [HttpPost]
        public CadastroResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if(request == null ||
               string.IsNullOrWhiteSpace(request.nome) ||
               string.IsNullOrWhiteSpace(request.sobrenome) ||
               string.IsNullOrWhiteSpace(request.telefone) ||
               string.IsNullOrWhiteSpace(request.genero) ||
               string.IsNullOrWhiteSpace(request.email) ||
               string.IsNullOrWhiteSpace(request.senha))
            {
                result.mensagem = "Todos os campos são obrigatórios";

                return result;
            }

            // codigo para cadastro
            var conectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

            var usuarioService = new UsuarioService(conectionString);

                result = usuarioService.Cadastro(
                    request.nome, 
                    request.sobrenome,
                    request.telefone, 
                    request.email, 
                    request.genero, 
                    request.senha);

            return result;
        }

        [Route("esqueceusenha")]
        [HttpPost]
        public EsqueceuSenhaResult esqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();

            if(request == null || string.IsNullOrWhiteSpace(request.email))

            {
                result.sucesso = false;
                result.mensagem = "Email obrigatório";

                return result;
            }
            var conectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

            result = new UsuarioService(conectionString).EsqueceuSenha(request.email);

            return result;
            
        }

        [HttpGet]
        [Route("obterUsusario")]
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            ObterUsuarioResult result = new ObterUsuarioResult();

            if (usuarioGuid == null)
            {
                result.mensagem = "Guid vazio";
            }
            else
            {
                var conectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuario = new UsuarioService(conectionString).ObterUsuario(usuarioGuid);

                if(usuario == null)
                {
                    result.mensagem = "Ususário não existe";
                }
                else
                {
                    result.sucesso = true;
                    result.nome = usuario.nome;
                }
            }
            return result;
        }
    }
}
