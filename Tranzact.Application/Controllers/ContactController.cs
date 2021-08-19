using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private readonly ILogger<ContactController> _logger;
        public ContactController(InterfaceContactDomain contactDomain, ILogger<ContactController> logger)
        {
            _contactDomain = contactDomain;
            _logger = logger;
        }

        /// <summary>
        /// Return a specific contact by id.
        /// </summary>
        /// <param name="id"></param>   
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Run endpoint {endpoint} {verb}", "/api/GetContact", "GET");

                if (id <= 0)
                    return BadRequest();

                var result = await _contactDomain.GetContact(id);

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while processing request from {id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting contact");
            }
        }

        /// <summary>
        /// Return all contacts.
        /// </summary>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _contactDomain.GetAll();

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while processing request from GetAllAsync");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting contacts");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] ContactDTO contactDTO)
        {
            try
            {
                _logger.LogInformation("Run endpoint {endpoint} {verb}", "/api/GetContact", "POST");

                if (contactDTO == null)
                    return BadRequest();

                var result = await _contactDomain.Save(contactDTO);

                return Ok(result);

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while processing request ", contactDTO);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new contact");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, ContactDTO contactDTO)
        {
            try
            {
                contactDTO.Id = id;

                var result = await _contactDomain.Update(contactDTO);

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while processing request ", contactDTO);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Delete a specific contact by id.
        /// </summary>
        /// <param name="id"></param>   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                var result = await _contactDomain.Delete(id);

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while processing request from {id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting contact");
            }
        }
    }
}
