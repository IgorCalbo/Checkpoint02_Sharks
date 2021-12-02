using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharks.Checkpoint02.Models
{
    [Table("Tbl_Editora")]
    public class Editora
    {
        [Column("Id")]
        public int EditoraId { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; }

        [Column("Dt_Inicio", TypeName = "Date"), DataType(DataType.Date), Display(Name = "Data Início")]
        public DateTime DataInicio { get; set; }

        // Relacionamento Um-Para-Muitos
        public IList<Livro> Livros { get; set; }
    }
}
