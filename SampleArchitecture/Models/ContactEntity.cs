using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SampleArchitecture.Models
{
    public class ContactEntity
    {
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Name { get; set; }

    [Required]
    [StringLength(20)]
    public string LastName { get; set; }

    public bool IsActive { get; set; }
    
    
    }
}