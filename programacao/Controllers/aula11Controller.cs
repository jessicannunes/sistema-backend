
using Microsoft.AspNetCore.Mvc;
using Programacaodozero.Models;

namespace Programacaodozero.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class aula11Controller : ControllerBase
    {
        [Route("obterVeiculo")]
        [HttpGet]
        public Veiculo obterVeiculo()
        {
            var meuVeiculo = new Veiculo();

            meuVeiculo.Cor = "Amarelo";
            meuVeiculo.Marca = "Ford";
            meuVeiculo.Placa = "XTZ-5050";
            meuVeiculo.Modelo = "Ecosport";

            meuVeiculo.Acelerar();

            return meuVeiculo;
        }

        [Route("obterCarro")]
        [HttpGet]
        public Carro obterCarro()
        {
            var meuCarro = new Carro();

            meuCarro.Marca = "Honda";
            meuCarro.Modelo = "Fit";
            meuCarro.Placa = "TDX-2590";
            meuCarro.Cor = "Preto";

            meuCarro.Acelerar();

            return meuCarro;

        }
        [Route("obterMoto")]
        [HttpGet]
        public Moto obterMoto()
        {
            var moto = new Moto();

            moto.Marca = "yahamaha";
            moto.Modelo = "XTZ";
            moto.Placa = "KLB-3030";
            moto.Cor = "Vermelha";

            moto.Acelerar();

            return moto;

        }
    }
}
