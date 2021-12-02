using Sharks.Checkpoint02.Models;
using Sharks.Checkpoint02.Persistencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharks.Checkpoint02.Repositories
{
    public class EditoraRepository : IEditoraRepository
    {
        private SharksContext _context;

        public EditoraRepository(SharksContext context)
        {
            _context = context;
        }

        public void Cadastrar(Editora editora)
        {
            _context.Editoras.Add(editora);
        }
        
        public IList<Editora> Listar()
        {
            return _context.Editoras.OrderBy(m => m.Nome).ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

    }
}
