using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication2
{
    public interface IRelatorio
    {
        Task Imprimir(HttpContext context);
    }
}