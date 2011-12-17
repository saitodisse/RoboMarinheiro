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
    }
}
