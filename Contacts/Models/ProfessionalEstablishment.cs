using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Models
{
    public class ProfessionalEstablishment
    {
        [Key]
        public int ProfissionalEstablishmenId { get; set; }
        [Display(Name = "Profissional")]
        public int ProfessionalId { get; set; }
        [Display(Name = "Profissional")]
        public Professional Professional { get; set; }
        [Display(Name = "Estabelecimento")]
        public int EstablishmentId { get; set; }
        [Display(Name = "Estabelecimento")]
        public Establishment Establishment { get; set; }

    }
}
