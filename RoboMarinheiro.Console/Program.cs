using System;
using System.Net;
using System.Text;
using RoboMarinheiro.Dominio.Entidades;
using RoboMarinheiro.Repositorio.Web;

namespace RoboMarinheiro.ConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            string uri = string.Empty;
            string regex = string.Empty;

            if (args.Length > 0)
            {
                uri = args[0];
            }
            else
            {
                Console.Write("URL: ");
                uri = Console.ReadLine();
            }

            if (args.Length > 1)
            {
                regex = args[1];
            }
            else
            {
                Console.Write("extrair via regex: ");
                regex = Console.ReadLine();
            }

            Console.WriteLine("");
            Console.WriteLine(uri);
            Console.WriteLine(regex);
            Console.WriteLine("");

            var htmlRepositorio = new HtmlRepositorio();
            var marinheiro = new Marinheiro(htmlRepositorio);
            string resultado = string.Empty;

            //baixar
            resultado = Navegar(marinheiro, uri);

            //extrair
            string resultadoExtracao = string.Empty;
            resultadoExtracao = ExtrairRegex(regex, resultado);

            //imprime
            Console.WriteLine(resultadoExtracao);
        }

        private static string Navegar(Marinheiro marinheiro, string uri)
        {
            string resultado = string.Empty;
            try
            {
                resultado = marinheiro.BuscarConteudo(uri);
            }
            catch (WebException ex)
            {
                var sb = new StringBuilder();
                sb.Append("   uri: " + uri);
                sb.Append("  erro: " + ex.Message);
                Console.WriteLine(sb.ToString());
            }
            catch (UriFormatException ex)
            {
                var sb = new StringBuilder();
                sb.Append("uri: " + uri);
                sb.Append("  erro: " + ex.Message);
                Console.WriteLine(sb.ToString());
            }
            return resultado;
        }

        private static string ExtrairRegex(string regex, string resultado)
        {
            StringBuilder resultadoExtracao = new StringBuilder();
            var extrator = new Extrator();
            var todosPrimeirosGrupos = extrator.ExtrairTodosPrimeirosGrupos(resultado, regex);
            foreach (var texto in todosPrimeirosGrupos)
            {
                resultadoExtracao.Append(texto);
                resultadoExtracao.Append(Environment.NewLine);
            }
            return resultadoExtracao.ToString();
        }
    }
}