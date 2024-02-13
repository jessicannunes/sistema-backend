namespace Programacaodozero.Models
{
    public class Moto : Veiculo
    {
        public Moto()
        {
            qtdRodas = 2;
            TanqueCombustivel = 15;
        }

        public override void Acelerar()
        {
            injetarCombustivel(1);
        }

        private void injetarCombustivel( int qtdCombustivel)
        {
            base.TanqueCombustivel = base.TanqueCombustivel - qtdCombustivel;
        }
        public int qtdRodas { get; set; }
    }


}
