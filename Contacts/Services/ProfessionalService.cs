using Contacts.Data;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Services
{
    public class ProfessionalService
    {
        private readonly ContactsContext _context;

        public ProfessionalService(ContactsContext context)
        {
            _context = context;
        }

        public async Task<List<Professional>> FindAllAsync()
        {
            return await _context.Professionals.ToListAsync();
        }

        public async Task InsertAsync(Professional obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
