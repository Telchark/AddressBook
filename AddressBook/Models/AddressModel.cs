using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class AddressModel
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(500)]
        public string Street { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int BuildingNumber { get; set; }
        [Range(1, int.MaxValue)]
        public int? LocalNumber { get; set; }
        [Required]
        [MaxLength(500)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string ZipCode { get; set; }
        [Required]
        [MaxLength(500)]
        public string Country { get; set; }
    }
}
