using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebQuestao1.Models
{
    public class Candidato
    {
        [Key]
        public int CandidatoID { get; set; }
        [Required]
        [Display(Name = "Nome")]
        [MaxLength(200)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(14)]
        [Display(Name = "CPF")]
        public string CPF { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(17)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        [Display(Name = "Habilitação")]
        public bool Habilitacao { get; set; }
        [MaxLength(15)]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }
        [Display(Name = "Idiomas")]
        public virtual List<CandidatoIdioma> Idiomas { get; set; }
        [NotMapped]
        public List<int> IdiomasIds { get; set; }

        #region Endereço
        public string Estado { get; set; }

        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }

        public string Complemento { get; set; }
        #endregion
        [Display(Name = "Cargo")]
        public int CargoID { get; set; }

        [ForeignKey("CargoID")]
        public virtual Cargo Cargo { get; set; }
        [Display(Name = "Salário Proposto")]
        [RegularExpression(@"^\d+\,\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal? SalarioProposto { get; set; }

        [Display(Name = "Horários")]
        public virtual List<HorarioTrabalho> Horarios { get; set; }
        
        [NotMapped]
        public string[] DiasDaSemana = { "Segunda", "Terça", "Quarta", "Quinta", "Sexta" };

    }
}
