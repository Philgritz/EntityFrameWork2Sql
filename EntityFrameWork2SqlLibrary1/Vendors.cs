using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameWork2SqlLibrary1
{
    public partial class Vendors
    {
        public Vendors()
        {
            Products = new HashSet<Products>();  //initialized product property, cant have two identical rows
        }

        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Code { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Address { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        [StringLength(2)]
        public string State { get; set; }
        [Required]
        [StringLength(5)]
        public string Zip { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }

        [InverseProperty("Vendor")]    //added property products, contains a collection of products from a vendor
        public virtual ICollection<Products> Products { get; set; }
    }
}
