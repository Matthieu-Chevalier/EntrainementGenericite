using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Models

{
    public abstract class AbstractEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }=String.Empty;
    }
}
