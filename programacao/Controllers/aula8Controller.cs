using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Programacaodozero.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class aula8Controller : ControllerBase
    {
        [Route("olaMundo")]
        [HttpGet]
        public string OlaMundo()
        {
            var mensagem = "Ola mundo via API";

            return mensagem;
        }

        [Route("olaMundoPersonalizado")]
        [HttpGet]
        public string olaMundoPersonalizado( string nome)
        {
            var mensagem = "Olá Mundo via API " + nome;

            return mensagem;
        }

        [Route("somar")]
        [HttpGet]
        public string Somar(int valor1, int valor2)
        {
            var soma = valor1 + valor2;
            var mensagem = "A Soma é: " + soma;

            return mensagem;
        }
    }
}
