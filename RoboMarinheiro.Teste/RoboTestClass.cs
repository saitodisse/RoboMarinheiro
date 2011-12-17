using Moq;
using NUnit.Framework;
using RoboMarinheiro.Dominio.Repositorios;
using RoboMarinheiro.Repositorio.Web;

namespace RoboMarinheiro.Dominio.Teste
{
    [TestFixture]
    public class RoboTestClass
    {
        [Test]
        public void deve_retornar_conteudo_da_uri_passada()
        {
            var htmlRepositorioMock = new Mock<IHtmlRepositorio>();
            htmlRepositorioMock.Setup(x => x.Baixar(  It.IsAny<string>()
                                                     ,It.IsAny<string>())
                                                   ).Returns("<html />");

            var robo = new RoboMarinheiro(htmlRepositorioMock.Object);
            string conteudo = robo.BuscarConteudo("http://www.w3schools.com/html/tryit.asp?filename=tryhtml_intro");
            Assert.IsNotNullOrEmpty(conteudo);
        }
    }
}