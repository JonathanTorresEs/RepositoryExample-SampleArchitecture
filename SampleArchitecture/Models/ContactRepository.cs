using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleArchitecture.Models
{
    public class ContactRepository
    {
        private DBContext dbcontext;

        public ContactRepository()
        {
            dbcontext = new DBContext();
        }

        public Contact GetContact(int id)
        {
            var c = dbcontext.Contacts.Find(id);

            return new Contact()
            {
                Id = c.Id,
                Name = c.Name,
                LastName = c.Name,
                isActive = c.IsActive
            };
        }
    }
}
