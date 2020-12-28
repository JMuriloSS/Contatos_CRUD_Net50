using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Models
{

    //1 - Criar um CRUD com tela de listagem(pesquisa), NOVO/EDITAR e excluir de Profissional com os seguintes dados:
    //Nome
    //Endereço
    //Telefone - celular e residencial
    //Função
    public class Professional
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [Display(Name = "Nome")]
        [StringLength(80)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [Display(Name = "Endereço")]
        [StringLength(150)]
        public string Address { get; set; }
        [Display(Name = "Celular")]
        //[RegularExpression(@"\(?\d{2}\)?-?*\d{4}-? *-?\d{ 5}")]

        public string Cellphone { get; set; }
        [Display(Name = "Telefone", Description = "Telefone Residencial")]
        //[Required(ErrorMessage = "Formato incorreto digite (99) 9999-99999")]
        //[RegularExpression(@"\(?\d{2}\)?-?*\d{4}-? *-?\d{ 5}")]
        public string HomePhone { get; set; }

        [Display(Name = "Função")]
        public string Role { get; set; }

        public Professional()
        {
        }

        public Professional(string name, string address, string cellphone, string homePhone, string role)
        {
            Name = name;
            Address = address;
            Cellphone = cellphone;
            HomePhone = homePhone;
            Role = role;
        }
    }
}
