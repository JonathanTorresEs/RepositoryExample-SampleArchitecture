using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SampleArchitecture.Models
{
    public class DBContext : DbContext
    {

        public DbSet<ContactEntity> Contacts { get; set; }

    }
}