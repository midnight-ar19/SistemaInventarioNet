using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using EL;


namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CategoriaBLL bll = new CategoriaBLL();
            List<Categoria> categorias = bll.ObtenerTodas();

            foreach (Categoria c in categorias)
            {
                Console.WriteLine($"{c.IdCategoria} - {c.Nombre}");
            }
        }
    }
}
