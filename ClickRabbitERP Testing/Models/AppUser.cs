using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClickRabbitERP_Testing.Models
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        public string NameOfIdentifier { get; set; }
        public string  Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Roles { get; set; }
        public List<string> RoleList
        {
            get
            {
                return Roles?.Split(',').ToList()??new List<string>(); ;
            }
        }
    }
}
