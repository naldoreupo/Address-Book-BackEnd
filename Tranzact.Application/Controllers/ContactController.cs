using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tranzact.Domain.DTO;
using Tranzact.Domain.Interfaces;

namespace Tranzact.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly InterfaceContactDomain _contactDomain;
        public ContactController(InterfaceContactDomain contactDomain)
        {
            _contactDomain = contactDomain;
        }

        [HttpGet("{id}")]
        public async Task<Object> GetAsync(int id)
        {
            try
            {
                var result = await _contactDomain.Get(id);

                return Ok(result);
            }
            catch(Exception ex)
            {
                //logger  LogException(e);
                return StatusCode(500);
            }
        }

        [HttpGet("GetAll")]
        public async Task<Object> GetAllAsync()
        {
            try
            {
                var result = await _contactDomain.GetAll();

                return Ok(result);
            }
            catch (Exception ex)
            {
                //logger
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<Object> PostAsync(ContactDTO contactDTO)
        {
            try
            {
                var result = await _contactDomain.Save(contactDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                //logger
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<Object> PutAsync(int id ,ContactDTO contactDTO)
        {
            try
            {
                contactDTO.Id = id;

                var result = await _contactDomain.Update(contactDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                //logger
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<Object> DeleteAsync(int id)
        {
            try
            {
                var result = await _contactDomain.Delete(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                //logger
                return StatusCode(500);
            }
        }
    }
}
