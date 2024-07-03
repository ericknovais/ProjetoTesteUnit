using JornadaMilhasV1.Modelos;

namespace Jornadamilhas.Teste
{
    public class OfertaViagemConstrutor
    {
        [Theory]
        [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100, true)]
        [InlineData(null, "S�o Paulo", "2024-01-01", "2024-01-02", -1, false)]
        [InlineData("Vit�ria", "S�o Paulo", "2024-01-01", "2024-01-01", 0, false)]
        [InlineData("Rio de Janeiro", "S�o Paulo", "2024-01-01", "2024-01-02", -500, false)]
        public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
        {
            // cen�rio -- arrange
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));


            //a��o - act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //Valida��o - assert
            Assert.Equal(validacao, oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemErroDeRotaOuPeriodoInvalidosQuandoRotaNula()
        {
            //Padr�o AAA
            // cen�rio -- arrange
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;

            //a��o - act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //Valida��o - assert
            Assert.Contains("A oferta de viagem n�o possui rota ou per�odo v�lidos.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemErroPeridoInvalido()
        {
            //arrenge
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 10), new DateTime(2024, 2, 5));
            double preco = 100.0;

            //act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //assert
            Assert.Contains("Erro: Data de ida n�o pode ser maior que a data de volta.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Theory]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", -100)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 0)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", -1000)]
        public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorOuIgualZero(string origem, string destino, string dataIda, string dataVolta, double preco)
        {
            //arrenge
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

            //act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //assert
            Assert.Contains("O pre�o da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
        }
    }
}