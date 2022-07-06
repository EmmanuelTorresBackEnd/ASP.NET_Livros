using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class Catalogo : ICatalogo
    {
        public List<Livro> GetLivros()
        {
            var livros = new List<Livro>();
            livros.Add(new Livro("001", "Inicio do Asp.Net", 12.99m));
            livros.Add(new Livro("002", "Fique rico com C#", 15.99m));
            livros.Add(new Livro("003", "Imersao ao .NET", 19.99m));

            return livros;
        }
    }
}
