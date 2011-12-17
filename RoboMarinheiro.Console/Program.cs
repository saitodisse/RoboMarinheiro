using System;
using System.Net;
using System.Text;
using RoboMarinheiro.Dominio.Entidades;
using RoboMarinheiro.Dominio.Excessoes;
using RoboMarinheiro.Repositorio.Web;

namespace RoboMarinheiro.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("URL: ");
            string uri = Console.ReadLine();

            var htmlRepositorio = new HtmlRepositorio();
            var marinheiro = new Marinheiro(htmlRepositorio);
            string resultado = string.Empty;

            try
            {
                resultado = marinheiro.BuscarConteudo(uri);
            }
            catch (WebException ex)
            {
                var sb = new StringBuilder();
                sb.Append("pagina: " + uri);
                sb.Append("  erro: " + ex.Message);
                Console.WriteLine(sb.ToString());
            }
            catch (UriFormatException ex)
            {
                var sb = new StringBuilder();
                sb.Append("pagina: " + uri);
                sb.Append("  erro: " + ex.Message);
                Console.WriteLine(sb.ToString());
            }

            Console.Write(resultado);
            Console.ReadKey();
        }
    }
}