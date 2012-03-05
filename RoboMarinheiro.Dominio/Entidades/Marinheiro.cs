using System.Net;
using RoboMarinheiro.Dominio.Repositorios;

namespace RoboMarinheiro.Dominio.Entidades
{
    public class Marinheiro
    {
        private readonly IHtmlRepositorio _htmlRepositorio;

        public Marinheiro(IHtmlRepositorio htmlRepositorio)
        {
            _htmlRepositorio = htmlRepositorio;
        }

        public string BuscarConteudo(string uri, WebProxy webProxy)
        {
            return _htmlRepositorio.Ler(uri, "POST", webProxy);
        }
    }
}