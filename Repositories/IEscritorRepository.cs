using Sharks.Checkpoint02.Models;
using System.Collections.Generic;

namespace Sharks.Checkpoint02.Repositories
{
    public interface IEscritorRepository
    {
        void Cadastrar(Escritor escritor);
        IList<Escritor> Listar();
        IList<Escritor> BuscarPorLivroId(int id);
        void Salvar();
    }
}