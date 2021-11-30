using ClickRabbitERP_Testing.Data;
using ClickRabbitERP_Testing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClickRabbitERP_Testing.Services
{
    public class UserService
    {
        private readonly ERPDbContext _context;
        public UserService(ERPDbContext context)
        {
            _context = context;
        }

        public AppUser GetUserById(int id)
        {
            var appUser = _context.AppUser.Find(id);
            return appUser;
        }

      
        public bool TryValidateUser(string username, string password, out List<Claim> claims)
        {
            claims = new List<Claim>();
            var appUser = _context.AppUser
                .Where(a => a.Username == username)
                .Where(a => a.Password == password).FirstOrDefault();
            if (appUser is null)
            {
                return false;
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                claims.Add(new Claim("username", username));
                claims.Add(new Claim(ClaimTypes.GivenName, appUser.FirstName)) ;
                claims.Add(new Claim(ClaimTypes.Surname, appUser.LastName));
                claims.Add(new Claim(ClaimTypes.Email, appUser.Email));
                claims.Add(new Claim(ClaimTypes.MobilePhone, appUser.Mobile));
                
                foreach (var r in appUser.RoleList)
                {
                    claims.Add(new Claim(ClaimTypes.Role, r));
                }
                return true;
            }
        }
    }
}
