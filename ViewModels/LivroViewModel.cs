using Microsoft.AspNetCore.Mvc.Rendering;
using Sharks.Checkpoint02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharks.Checkpoint02.ViewModels
{
    public class LivroViewModel
    {
        public Livro Livro { get; set; }
        public IList<Escritor> Escritores { get; set; }
        public SelectList OpcoesEscritores { get; set; }
    }
}
