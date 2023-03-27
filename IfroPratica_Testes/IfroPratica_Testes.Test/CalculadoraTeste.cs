namespace IfroPratica_Testes.Test
{
    public class CalculadoraTeste
    {
        [Fact(DisplayName = "Somar Dois Numeros Inteiro")]
        public void SomarDoisNumerosInteiros()
        {
            var result = Calculadora.Somar(10, 10);

            Assert.Equal(20, result);
        }

        [Fact(DisplayName = "Subtrair Dois Numeros Inteiro")]
        public void SubtrairDoisNumerosInteiros()
        {
            var result = Calculadora.Subtrair(10, 10);

            Assert.Equal(0, result);
        }

        [Fact(DisplayName = "Multiplicar Dois Numeros Inteiro")]
        public void MultiplicarDoisNumerosInteiros()
        {
            var result = Calculadora.Multiplicar(10, 10);

            Assert.Equal(100, result);
        }

        [Fact(DisplayName = "Dividir Dois Numeros Inteiro")]
        public void DividirDoisNumerosInteiros()
        {
            var result = Calculadora.Dividir(10, 10);

            Assert.Equal(1, result);
        }

        //[Fact(DisplayName = "Dividir Dois Numeros Inteiro com Retorno Quebrado")]
        //public void DividirDoisNumerosFracionados()
        //{
        //    var result = Calculadora.Dividir(7, 2);

        //    Assert.Equal(3.5, result);
        //}
    }
}