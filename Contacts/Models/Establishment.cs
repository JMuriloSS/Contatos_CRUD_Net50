using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Models
{
    public class Establishment
    {
        //2 - Criar um CRUD com tela de listagem, NOVO/EDITAR e excluir de Estabelecimento com os seguintes dados:
        //Nome
        //Endereço
        //Telefone

        public int Id { get; set; }
        [Required(ErrorMessage = "{0} requerido")]
        [Display(Name = "Nome")]
        [StringLength(80)]
        public string Name { get; set; }
        [Display(Name = "Endereço")]
        [StringLength(150)]
        public string Address { get; set; }
        [Display(Name = "Telefone", Description = "Telefone Comercial")]
        [Required(ErrorMessage = "Formato incorreto digite (99) 9999-99999")]
        [RegularExpression(@"\(?\d{2,}\)?[ -]?\d{4,}[\-\s]?\d{5}")]
        public string Phone { get; set; }

        public Establishment()
        {
        }

        public Establishment(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }
    }
}
