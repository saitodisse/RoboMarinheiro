using RoboMarinheiro.Dominio.Repositorios;

namespace RoboMarinheiro.Dominio
{
    public class RoboMarinheiro
    {
        private readonly IHtmlRepositorio _htmlRepositorio;

        public RoboMarinheiro(IHtmlRepositorio htmlRepositorio)
        {
            _htmlRepositorio = htmlRepositorio;
        }

        public string BuscarConteudo(string uri)
        {
            return _htmlRepositorio.Baixar(uri);
        }
    }
}