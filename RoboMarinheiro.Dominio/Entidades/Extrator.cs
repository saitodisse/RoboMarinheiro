using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RoboMarinheiro.Dominio.Entidades
{
    public class Extrator
    {
        public string ExtrairPrimeiroGrupo(string texto, string expressao)
        {
            var regex = new Regex(expressao);
            var matchCollection = regex.Matches(texto);
            foreach (Match match in matchCollection)
            {
                return match.Groups[1].Value;
            }
            return string.Empty;
        }

        public string[] ExtrairTodosPrimeirosGrupos(string texto, string expressao)
        {
            var regex = new Regex(expressao);
            var matchCollection = regex.Matches(texto);
            var lista = new List<string>();
            foreach (Match match in matchCollection)
            {
                lista.Add(match.Groups[1].Value);
            }
            return lista.ToArray();
        }
    }
}
