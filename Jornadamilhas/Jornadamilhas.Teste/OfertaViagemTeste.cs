using JornadaMilhasV1.Modelos;

namespace Jornadamilhas.Teste
{
    public class OfertaViagemTeste
    {
        [Fact]
        public void TestandoOfertaValida()
        {
            // cenário -- arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;
            var validacao = true;

            //ação - act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
            
            //Validação - assert
            Assert.Equal(validacao, oferta.EhValido);

        }

        [Fact]
        public void TestandoOfertaComRotaNula()
        {
            //Padrão AAA
            // cenário -- arrange
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;

            //ação - act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //Validação - assert
            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);

        }
    }
}