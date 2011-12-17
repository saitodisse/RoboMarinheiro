using NUnit.Framework;

namespace RoboMarinheiro.Dominio.Teste
{
    [TestFixture]
    public class RoboTestClass
    {
        [Test]
        public void deve_retornar_conteudo_da_uri_passada()
        {
            var robo = new RoboMarinheiro();
            string conteudo = robo.BuscarConteudo("http://www.w3schools.com/html/tryit.asp?filename=tryhtml_intro");
            Assert.IsNotNullOrEmpty(conteudo);
        }
    }
}