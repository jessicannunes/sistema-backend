
namespace Programacaodozero.Models
{
    public class Veiculo
    {
        // Construtor
        public Veiculo()
        {
            TanqueCombustivel = 40;
        }

        // atributos ou propriedades
        public string Cor { get; set; }

        public string Placa { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int TanqueCombustivel { get; set; }

        //métodos - que são parecidos com funções mas não são
        public virtual void Acelerar()
        {
            injetarCombustivel(2);
        }

        public void Frear()
        {

        }
        private void injetarCombustivel( int qtdCombustivel)
        {
            TanqueCombustivel = TanqueCombustivel - qtdCombustivel;
        }
    }
}