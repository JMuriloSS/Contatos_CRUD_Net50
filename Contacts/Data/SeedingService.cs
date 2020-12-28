using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Data
{
    public class SeedingService
    {
        private readonly ContactsContext _context;

        public SeedingService(ContactsContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Professionals.Any() ||
                _context.Establishments.Any() ||
                _context.ProfessionalEstablishments.Any())
            {
                return; // DB has been seeded
            }

            Professional p01 = new Professional("Fulano da Silva", "Rua Teste, 21", "(11) 9123-45252", "(11) 3999-12456", "Analista de Suporte");
            Professional p02 = new Professional("Ciclano Santos", "Av. Pires Neto, 3210", "(11) 9123-44545", "(11) 3999-35698", "Desenvolvedor Jr.");
            Professional p03 = new Professional("Cris Sales", "Rua Lima Jorge, 111", "(11) 9358-51111", "(11) 4977-45645", "Desenvolvedor Sr.");
            Professional p04 = new Professional("John Allan", "Rua Exemplo, 14", "(11) 9300-55192", "(11) 3999-45789", "Gerente de TI");
            Professional p05 = new Professional("Andre Figueira", "Av. Leste, 20", "(11) 9155-55722", "(11) 3229-99884", "DBA");
            Professional p06 = new Professional("Selton Vigo", "Rua Nordeste, 43", "(11) 9356-45789", "(11) 3112-55688", "Coordenador de Projetos");
            Professional p07 = new Professional("Maria Flores", "Rua Marques Lopes, 467", "(11) 9511-55892", "(11) 3655-99877", "Analista de Sistemas Jr.");
            Professional p08 = new Professional("Roseli Castro", "Rua Oeste, 1320", "(11) 9238-52122", "(11) 3258-87451", "Desenvolvedor Sr.");
            Professional p09 = new Professional("Naldo Silveira", "Rua Sul, 12", "(11) 9343-55732", "(11) 3124-36589", "Engenheiro de Software");
            Professional p10 = new Professional("Tito Lins", "Rua Moema, 76", "(11) 9312-99722", "(11) 3895-32541", "Analista de Infraestrutura");
            Professional p11 = new Professional("Beltrano Neto", "Rua Belavista, 980", "(11) 9390-65478", "(11) 3357-85479", "Gerente de Projetos");
            Professional p12 = new Professional("Paulo Silva", "Rua Marta Gois, 965", "(11) 9238-53742", "(11) 3568-98574", "Aprendiz de TI");
            Professional p13 = new Professional("José Silva", "Av. das Tecnologias, 1220", "(11) 9658-53422", "(11) 3587-15789", "Diretor de TI");
            Professional p14 = new Professional("Beatriz Lima", "Rua Triangulo das Bermudas, 30", "(11) 9389-53657", "(11) 3345-76563", "Estagiário TI");
            Professional p15 = new Professional("Sampaio Correa", "Rua Apolo 11, 70", "(11) 9332-68512", "(11) 2434-35477", "Estagiário TI");


            Establishment e01 = new Establishment("ZYX Empresa I", "Av. Principal, 19", "(11) 3001-23457");
            Establishment e02 = new Establishment("TYP Empresa II", "Av. Série Nova, 210", "(11) 3002-11234");
            Establishment e03 = new Establishment("FDA Empresa III", "Av. das Flores, 319", "(11) 3003-21487");
            Establishment e04 = new Establishment("ACB Empresa IV", "Av. Silva Sampaio, 76", "(11) 3004-39874");
            Establishment e05 = new Establishment("FGT Empresa V", "Av. Pres. Nelson, 891", "(11) 3005-96589");
            Establishment e06 = new Establishment("TYU Empresa VI", "Av. Natalina Soares, 134", "(11) 3000-75893");
            Establishment e07 = new Establishment("ABC Empresa VII", "Av. Batista Melo, 10", "(11) 3006-93258");
            Establishment e08 = new Establishment("XYZ Empresa VIII", "Av. Souza Neves, 15", "(11) 3007-03478");
            Establishment e09 = new Establishment("POL Empresa IX", "Av. Lopes Torres, 990", "(11) 3008-11658");
            Establishment e10 = new Establishment("LOP Empresa X", "Rua Trevo Norte, 315", "(11) 3018-24578");
            Establishment e11 = new Establishment("JKL Empresa XI", "Av. Lauro Sergio, 670", "(11) 3218-32597");
            Establishment e12 = new Establishment("UIL Empresa XII", "Av. Noroeste, 67", "(11) 3334-31578");
            Establishment e13 = new Establishment("TRA Empresa XIII", "Av. Sul, 14", "(11) 3055-78542");
            Establishment e14 = new Establishment("AFG Empresa XIV", "Av. Norte, 91", "(11) 3056-65478");
            Establishment e15 = new Establishment("IOP Empresa XV", "Av. Sudeste, 1222", "(11) 3090-54789");

            _context.Professionals.AddRange(p01, p02, p03, p04, p05, p06, p07, p08, p09, p10, p11, p12, p13, p14, p15);

            _context.Establishments.AddRange(e01, e02, e03, e04, e05, e05, e06, e07, e08, e09, e10, e11, e12, e13, e14, e15);

            _context.SaveChanges();

        }
    }
}
