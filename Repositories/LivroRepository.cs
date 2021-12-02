using Microsoft.EntityFrameworkCore;
using Sharks.Checkpoint02.Models;
using Sharks.Checkpoint02.Persistencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sharks.Checkpoint02.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private SharksContext _context;

        public LivroRepository(SharksContext context)
        {
            _context = context;
        }

        public void Atualizar(Livro livro)
        {
            _context.Livros.Update(livro);
        }

        public IList<Livro> BuscarPor(Expression<Func<Livro, bool>> filtro)
        {
            return _context.Livros.Where(filtro).Include(m => m.Editora).ToList();
        }

        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Where(m => m.LivroId == id).Include(m => m.Editora).FirstOrDefault();
        }

        public void Cadastrar(Livro livro)
        {
            _context.Livros.Add(livro);
        }

        public IList<Livro> Listar()
        {
            return _context.Livros.Include(m => m.Editora).ToList();
        }

        public void Remover(int id)
        {
            var livro = _context.Livros.Find(id);
            _context.Livros.Remove(livro);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

    }
}
