using JornadaMilhasV1.Modelos;

namespace Jornadamilhas.Teste
{
    public class OfertaViagemTeste
    {
        [Fact]
        public void TestandoOfertaValida()
        {
            // cen�rio -- arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;
            var validacao = true;

            //a��o - act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
            
            //Valida��o - assert
            Assert.Equal(validacao, oferta.EhValido);

        }

        [Fact]
        public void TestandoOfertaComRotaNula()
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
    }
}