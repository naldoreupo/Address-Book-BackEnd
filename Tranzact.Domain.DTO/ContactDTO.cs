using System;
using System.Collections.Generic;
using System.Text;

namespace Tranzact.Domain.DTO
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
    }
}
