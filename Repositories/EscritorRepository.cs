using Microsoft.EntityFrameworkCore;
using Sharks.Checkpoint02.Models;
using Sharks.Checkpoint02.Persistencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharks.Checkpoint02.Repositories
{
    public class EscritorRepository : IEscritorRepository
    {
        private SharksContext _context;

        public EscritorRepository(SharksContext context)
        {
            _context = context;
        }

        public IList<Escritor> BuscarPorLivroId(int id)
        {
            return _context.LivrosEscritores
                .Where(m => m.LivroId == id)
                .Select(m => m.Escritor)
                .ToList();
        }

        public void Cadastrar(Escritor escritor)
        {
            _context.Escritores.Add(escritor);
        }

        public IList<Escritor> Listar()
        {
            return _context.Escritores.Include(m => m.Endereco).ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

    }
}
