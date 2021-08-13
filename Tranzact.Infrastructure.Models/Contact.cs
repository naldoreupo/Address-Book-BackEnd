using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace Tranzact.Infrastructure.Models
{
    [Table("Contact")]
    public partial class Contact
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        public bool? IsActive { get; set; }
    }
}
