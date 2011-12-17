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
            IHtmlRepositorio htmlRepositorio = new HtmlRepositorio();
            var robo = new RoboMarinheiro(htmlRepositorio);
            string conteudo = robo.BuscarConteudo("http://www.w3schools.com/html/tryit.asp?filename=tryhtml_intro");
            Assert.IsNotNullOrEmpty(conteudo);
        }
    }
}