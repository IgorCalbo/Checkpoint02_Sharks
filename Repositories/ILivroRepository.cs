using Sharks.Checkpoint02.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sharks.Checkpoint02.Repositories
{
    public interface ILivroRepository
    {
        void Cadastrar(Livro livro);
        void Atualizar(Livro livro);
        Livro BuscarPorId(int id);
        IList<Livro> Listar();
        void Remover(int id);
        IList<Livro> BuscarPor(Expression<Func<Livro, bool>> filtro);
        void Salvar();
    }
}