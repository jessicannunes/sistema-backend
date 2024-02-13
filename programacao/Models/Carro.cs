namespace Programacaodozero.Models
{
    public class Carro : Veiculo
    {
        //Construtor da classe
        public Carro()
        {
            qtdRodas = 4;
        }
        public int qtdRodas { get; set; }


        public override void Acelerar()
        {
            injetarCombustivel(4);
        }

        private void injetarCombustivel(int qtdCombustivel)
        {
            base.TanqueCombustivel = base.TanqueCombustivel - qtdCombustivel;
        }
    }

}
