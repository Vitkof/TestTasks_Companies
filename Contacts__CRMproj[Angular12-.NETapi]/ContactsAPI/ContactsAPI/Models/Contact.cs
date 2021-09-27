using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContactsAPI.Models
{
    public class Contact
    {
        private DateTime birthdate;

        [Key]
        [ScaffoldColumn(false)]
        [Column(TypeName = "INT")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string JobTitle { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get { return birthdate.Date; }
                                    set { birthdate = value; } }
    }
}