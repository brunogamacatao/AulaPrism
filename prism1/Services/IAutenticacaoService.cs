using System;
using System.Threading.Tasks;

namespace prism1.Services
{
    public interface IAutenticacaoService
    {
        Task<bool> Autentica(string email, string senha);
        string Token { get; set; }
    }
}
