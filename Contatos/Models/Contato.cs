using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Models
{
    public class Contato
    {
        [Key]
        //[Column(TypeName = "NUMBER(14)")]
        public int Id { get; set; }

        [StringLength(100)]
        public string? Nome { get; set; }

        [Range(0, 999)]
        //[Column(TypeName = "NUMBER(3)")] para oracle
        public int Idade { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
    }
}
