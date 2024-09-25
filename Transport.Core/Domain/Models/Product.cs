using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Transport.Core.Domain.Models
{
    [Table("Product", Schema = "dbo")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ProductId")]
        public int ProductId { get; set; }

        [Required]
        [Column("ProductName")]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [Column("ProductCode")]
        public string ProductCode { get; set; } = string.Empty;

        [Column("ProductDescription")]
        public string ProductDescription { get; set; } = string.Empty;

        [Column("ProductPrice")]
        public int ProductPrice { get; set; }

        public int CategoryId { get; set; }
    }
}
