using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Domain.Interfaces;
using Tranzact.Infrastructure.Interfaces;
using Tranzact.Transversal;
using Tranzact.Infrastructure.Models;
using Tranzact.Domain.DTO;
using AutoMapper;

namespace Tranzact.Domain
{
    public class ContactDomain : InterfaceContactDomain
    {
        private readonly InterfaceContactInfraestructure _contactInfraestructure;
        private readonly IMapper _mapper;
        public ContactDomain(IMapper mapper, InterfaceContactInfraestructure contactInfraestructure)
        {
            _mapper = mapper;
            _contactInfraestructure = contactInfraestructure;
        }


        public async Task<ContactDTO> GetContact(int id)
        {
            try
            {
                var contact = _mapper.Map<ContactDTO>(await _contactInfraestructure.GetContactById(id));
                return contact;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Response<ContactDTO>> GetAll()
        {
            try
            {
                var list = _mapper.Map<List<ContactDTO>>(await _contactInfraestructure.GetAllContacts());

                return new Response<ContactDTO>()
                {
                    Status = true,
                    List = list
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Response<int>> Save(ContactDTO Contact)
        {
            try
            {
                var entity = await _contactInfraestructure.SaveContact(_mapper.Map<Contact>(Contact));

                return new Response<int>()
                {
                    Status = true,
                    Data = entity.Id
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Response<bool>> Delete(int id)
        {
            try
            {
                var update = await _contactInfraestructure.DeleteContact(id);

                return new Response<bool>()
                {
                    Status = true,
                    Data = update
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Response<bool>> Update(ContactDTO Contact)
        {
            try
            {
                var update = await _contactInfraestructure.UpdateContact(_mapper.Map<Contact>(Contact));

                return new Response<bool>()
                {
                    Status = true,
                    Data = update
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
