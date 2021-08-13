using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Domain.DTO;
using Tranzact.Transversal;

namespace Tranzact.Domain.Interfaces
{
    public interface InterfaceContactDomain
    {
        Task<ContactDTO> Get(int id);
        Task<Response<ContactDTO>> GetAll();
        Task<Response<int>> Save(ContactDTO Contact);
        Task<Response<bool>> Update(ContactDTO Contact);
        Task<Response<bool>> Delete(int id);
    }
}
