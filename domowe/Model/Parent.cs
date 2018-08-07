using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domowe.Model
{
    [Table("Parent")]
    public class Parent
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
                
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
