using Sharks.Checkpoint02.Models;
using System.Collections.Generic;

namespace Sharks.Checkpoint02.Repositories
{
    public interface IEditoraRepository
    {
        void Cadastrar(Editora editora);
        IList<Editora> Listar();
        void Salvar();
    }
}