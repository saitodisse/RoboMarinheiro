using System.Net;
using Moq;
using NUnit.Framework;
using RoboMarinheiro.Dominio.Entidades;
using RoboMarinheiro.Dominio.Repositorios;

namespace RoboMarinheiro.Dominio.Teste
{
    [TestFixture]
    public class MarinheiroTeste
    {
        [Test]
        public void deve_retornar_conteudo_da_uri_passada()
        {
            var htmlRepositorioMock = new Mock<IHtmlRepositorio>();
            htmlRepositorioMock.Setup(x => x.Ler(It.IsAny<string>(), It.IsAny<string>(), null)).Returns("<html />");

            var robo = new Marinheiro(htmlRepositorioMock.Object);
            string conteudo = robo.BuscarConteudo("http://www.w3schools.com/html/tryit.asp?filename=tryhtml_intro", null);
            Assert.IsNotNullOrEmpty(conteudo);
        }

        [Test]
        public void web_exception_estoura_pro_dominio()
        {
            var htmlRepositorioMock = new Mock<IHtmlRepositorio>();
            htmlRepositorioMock.Setup(x => x.Ler(It.IsAny<string>(), It.IsAny<string>(), null)).Throws<WebException>();

            var robo = new Marinheiro(htmlRepositorioMock.Object);
            Assert.Throws<WebException>(() => robo.BuscarConteudo("http://stackoverflow.com/que", null));
        }
    }
}