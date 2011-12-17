using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboMarinheiro.Dominio.Repositorios
{
    public interface IHtmlRepositorio
    {
        string Baixar(string caminho, string method);
    }

}
