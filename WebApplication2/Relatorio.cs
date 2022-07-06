using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class Relatorio : IRelatorio
    {
        private readonly ICatalogo catalogo;

        public Relatorio(ICatalogo catalogo)
        {
            this.catalogo = catalogo;
        }

        public async Task Imprimir(HttpContext context)
        {
            foreach (var Livro in catalogo.GetLivros())
            {
                await context.Response.WriteAsync($"{Livro.Codigo,-10}{Livro.Nome,-40}{Livro.Preco.ToString("C"),10}\r\n");
            }
        }
    }
}
