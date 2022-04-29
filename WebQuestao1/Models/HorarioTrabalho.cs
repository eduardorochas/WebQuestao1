using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebQuestao1.Models
{
    public class HorarioTrabalho
    {
        public int HorarioTrabalhoID { get; set; }
        
        [Display(Name = "Dia da Semana")]
        public int DiaSemana { get; set; }
        [Display(Name = "Hora Início")]
        public string HoraInicio { get; set; }
        [Display(Name = "Hora Fim")]
        public string HoraFim { get; set; }
        [Display(Name = "Tempo de Descanso (h)")]
        public int TempoDescanso { get; set; }
        [Display(Name = "Carga Horária(h)")]
        
        public int CargaHoraria { get; set; }

        [Display(Name = "Candidato")]
        public int CandidatoID { get; set; }

        [ForeignKey("CandidatoID")]
        public virtual Candidato Candidato { get; set; }

    }
}
