using Sharks.Checkpoint02.Models;

namespace Sharks.Checkpoint02.Repositories
{
    public interface ILivroEscritorRepository
    {
        void Cadastrar(LivroEscritor livroEscritor);
        void Salvar();
    }
}