using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using prism1.Models;

namespace prism1.Services
{
    public interface IInfracoesService
    {
        Task<Infracao> Adiciona(Infracao infracao, System.IO.Stream photoStream);
        Task<IEnumerable<Infracao>> Lista();
    }
}
