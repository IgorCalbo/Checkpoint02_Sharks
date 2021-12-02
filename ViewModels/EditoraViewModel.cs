using Sharks.Checkpoint02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharks.Checkpoint02.ViewModels
{
    public class EditoraViewModel
    {
        public Editora Editora { get; set; }

        public IList<Editora> Lista { get; set; }
    }
}
