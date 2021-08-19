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
            try
            {
                return await GetAll();

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<Contact> SaveContact(Contact Contact)
        {
            try
            {
                return await Save(Contact);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteContact(int id)
        {
            return await Delete(id);
        }

        public async Task<bool> UpdateContact(Contact Contact)
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

        public async Task<Contact> GetContactById(int id)
        {
            try
            {
                return await GetById(id);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
