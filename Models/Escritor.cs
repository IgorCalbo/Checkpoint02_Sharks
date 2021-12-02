using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharks.Checkpoint02.Models
{
    [Table("Tbl_Escritor")]
    public class Escritor
    {
        [Column("Id")]
        public int EscritorId { get; set; }

        [Required, MaxLength(80)]
        public string Nome { get; set; }

        public GeneroEscritor Genero { get; set; }

        [Column("Dt_Nascimento", TypeName = "Date"), DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        // Um-para-um
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

        // Muitos-Para-Muitos
        public IList<LivroEscritor> LivrosEscritores { get; set; }
    }

    public enum GeneroEscritor
    {
        Feminino, Masculino, Outros
    }
}
