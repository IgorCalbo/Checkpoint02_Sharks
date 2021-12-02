using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sharks.Checkpoint02.Models
{
    [Table("Tbl_Livro")] // Nome da tabela
    public class Livro
    {
        [Column("Id"), HiddenInput] // Nome da coluna
        public int LivroId { get; set; }

        [Required, MaxLength(80)]
        public string Nome { get; set; }

        [Column("Dt_Lancamento"), Required, DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }
        public int Paginas { get; set; }
        public bool Infantil { get; set; }
        public Genero? Genero { get; set; }

        // Relacionamento Muitos-Para-Um
        public Editora Editora { get; set; }
        public int? EditoraId { get; set; }

        // Relacionamento Muitos-Para-Muitos
        public IList<LivroEscritor> LivrosEscritores { get; set; }
    }

    public enum Genero
    {
        Drama, Suspense, Romance, Aventura, Distopia, Conto, Fantasia, Terror
    }
}
