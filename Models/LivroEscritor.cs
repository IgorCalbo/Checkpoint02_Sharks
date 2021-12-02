using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharks.Checkpoint02.Models
{
    [Table("Tbl_Livro_Escritor")]
    public class LivroEscritor
    {
        public int LivroId { get; set; }
        public Livro Livro { get; set; }

        public int EscritorId { get; set; }
        public Escritor Escritor { get; set; }
    }
}
