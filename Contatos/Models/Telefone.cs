using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Models
{
    public class Telefone
    {
        [Key]
        //[Column(TypeName = "NUMBER(14)")]
        public int Id { get; set; }

        //[Column(TypeName = "NUMBER(14)")]
        public int ContatoId { get; set; }
        [ForeignKey("ContatoId")]
        public Contato? Contato { get; set; }


        [StringLength(16)]
        public string? Numero { get; set; }
    }
}
