using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebQuestao1.Models
{
    public class CandidatoIdioma
    {
        [Key]
        public int CandidatoIdiomaID { get; set; }

        public int CandidatoID { get; set; }
        [ForeignKey("CandidatoID")]
        public virtual Candidato Candidato { get; set; }

        public int LinguaEstrangeiraID { get; set; }
        [ForeignKey("LinguaEstrangeiraID")]
        public virtual LinguaEstrangeira LinguaEstrangeira { get; set; }

    }
}
