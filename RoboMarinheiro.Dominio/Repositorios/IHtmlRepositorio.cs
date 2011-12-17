namespace RoboMarinheiro.Dominio.Repositorios
{
    public interface IHtmlRepositorio
    {
        string Ler(string caminho, string method);
    }
}