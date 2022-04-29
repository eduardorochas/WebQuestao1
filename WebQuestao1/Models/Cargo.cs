using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace WebQuestao1.Models
{
    public class Cargo
    {
        public int CargoID { get; set; }
        [MaxLength(200)]
        public string Nome { get; set; }
    }
}