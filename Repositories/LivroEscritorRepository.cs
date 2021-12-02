using Sharks.Checkpoint02.Models;
using Sharks.Checkpoint02.Persistencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharks.Checkpoint02.Repositories
{
    public class LivroEscritorRepository : ILivroEscritorRepository
    {
        private SharksContext _context;

        public LivroEscritorRepository(SharksContext context)
        {
            _context = context;
        }

        public void Cadastrar(LivroEscritor livroEscritor)
        {
            _context.LivrosEscritores.Add(livroEscritor);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

    }
}
