using System;
using Moq;
using NUnit.Framework;
using RoboMarinheiro.Dominio.Entidades;
using RoboMarinheiro.Dominio.Repositorios;

namespace RoboMarinheiro.Dominio.Teste
{
    [TestFixture]
    public class RoboTestClass
    {
        [Test]
        public void deve_estourar_excessao_para_404()
        {
            var htmlRepositorioMock = new Mock<IHtmlRepositorio>();
            htmlRepositorioMock.Setup(x => x.Ler(It.IsAny<string>()
                                                 , It.IsAny<string>())
                ).Throws<Exception>();

            var robo = new Marinheiro(htmlRepositorioMock.Object);
            string conteudo = robo.BuscarConteudo("http://stackoverflow.com/que");
            Assert.IsNotNullOrEmpty(conteudo);
        }

        [Test]
        public void deve_retornar_conteudo_da_uri_passada()
        {
            var htmlRepositorioMock = new Mock<IHtmlRepositorio>();
            htmlRepositorioMock.Setup(x => x.Ler(It.IsAny<string>()
                                                 , It.IsAny<string>())
                ).Returns("<html />");

            var robo = new Marinheiro(htmlRepositorioMock.Object);
            string conteudo = robo.BuscarConteudo("http://www.w3schools.com/html/tryit.asp?filename=tryhtml_intro");
            Assert.IsNotNullOrEmpty(conteudo);
        }
    }
}