using System;
using System.Configuration;
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

            var useProxy = Convert.ToBoolean(ConfigurationManager.AppSettings["useProxy"]);
            var proxyAddress = ConfigurationManager.AppSettings["proxyAddress"];
            var domain = ConfigurationManager.AppSettings["domain"];
            var userName = ConfigurationManager.AppSettings["userName"];
            var password = ConfigurationManager.AppSettings["password"];

            resultado = Navegar(marinheiro, uri, useProxy, proxyAddress, userName, password, domain);

            //extrair
            string resultadoExtracao = string.Empty;
            if (!string.IsNullOrEmpty(regex))
            {
                resultadoExtracao = ExtrairRegex(regex, resultado);
            }
            else
            {
                resultadoExtracao = resultado;
            }

            //imprime
            Console.WriteLine(resultadoExtracao);
            Console.ReadLine();
        }

        private static string Navegar(Marinheiro marinheiro, string uri, bool usarProxy, string address, string userName, string password, string domain)
        {
            string resultado = string.Empty;
            try
            {
                WebProxy webProxy = null;

                if (usarProxy)
                {
                    NetworkCredential networkCredential = new NetworkCredential(userName, password, domain);
                    webProxy = new WebProxy(address, false, null, networkCredential);
                }

                resultado = marinheiro.BuscarConteudo(uri, webProxy);
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