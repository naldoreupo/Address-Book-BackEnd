using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Infrastructure.Interfaces;
using Tranzact.Infrastructure.Models;
using Tranzact.Transversal;

namespace Tranzact.Infrastructure
{
    public class ContactInfraestructure : BaseRepository<Contact>, InterfaceContactInfraestructure
    {
        public async Task<List<Contact>> GetAllContacts()
        {
            return await GetAll();
       
        }

        public async Task<Contact> SaveContact(Contact Contact)
        {
            try
            {
                return  await Save(Contact);       
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        Task<bool> InterfaceContactInfraestructure.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task<bool> InterfaceContactInfraestructure.Update(Contact Contact)
        {
            try
            {
                return await Update(Contact);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
