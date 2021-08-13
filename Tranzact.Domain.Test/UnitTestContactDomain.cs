using AutoMapper;
using Moq;
using System;
using Tranzact.Domain.Interfaces;
using Tranzact.Infrastructure.Interfaces;
using Tranzact.Infrastructure.Models;
using Xunit;

namespace Tranzact.Domain.Test
{
    public class UnitTestContactDomain
    {

        public Mock<InterfaceContactInfraestructure> mockInterfaceContactInfraestructure = new Mock<InterfaceContactInfraestructure>();
        public Mock<IMapper> _mapper = new Mock<IMapper>();

        [Fact]
        public void Save_ValidContact_ReturnValidResponse()
        {
            //Arrange
            var contact = new Contact() {
                Id = 10
            };
            mockInterfaceContactInfraestructure.Setup(m => m.SaveContact(It.IsAny<Contact>())).ReturnsAsync(contact);

            //Act
            InterfaceContactDomain contacDomain = new ContactDomain(_mapper.Object, mockInterfaceContactInfraestructure.Object);
            var result = contacDomain.Save(new DTO.ContactDTO());


            //assert
            Assert.Equal(10, result.Result.Data);

        }
    }
}
