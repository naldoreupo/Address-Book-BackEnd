using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Infrastructure.Models;
using Tranzact.Transversal;

namespace Tranzact.Infrastructure.Interfaces
{
    public interface InterfaceContactInfraestructure
    {

        Task<Contact> GetContactById(int id);
        Task<List<Contact>> GetAllContacts();
        Task<Contact> SaveContact(Contact Contact);
        Task<bool> UpdateContact(Contact Contact);
        Task<bool> DeleteContact(int id);

    }
}
