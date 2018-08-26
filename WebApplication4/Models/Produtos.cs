using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Produtos
    {
        [Key]
        public int Id { get; set; }
        public int Idade { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public string Mensagem { get; set; }
        //[Display(Name = "Preço")]
        //public float Preco { get; set; }
    }
}