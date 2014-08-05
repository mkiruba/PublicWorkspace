using SimpleUserRegistration.Business;
using SimpleUserRegistration.UI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Autofac;
using Autofac.Configuration;

namespace SimpleUserRegistration.UI.Controllers
{
    public class UserRegistrationController : ApiController
    {        
        private readonly IUserService _userService;
        
        public UserRegistrationController()
        {
            _userService = new UserService();
        }
        // GET api/default1
        public IEnumerable<User> Get()
        {
          
            return _userService.GetUsers().Select(x => new User
            {
                Id = x.Id,
                Name = x.Name,
                EmailAddress = x.EmailAddress,
                AddressLine1 = x.AddressLine1,
                AddressLine2 = x.AddressLine2,
                Postcode = x.Postcode
            });
        }

        // GET api/default1/5
        public IEnumerable<User> Get(int id)
        {
            return _userService.GetUser(id).Select(x => new User
            {
                Id = x.Id,
                Name = x.Name,
                EmailAddress = x.EmailAddress,
                AddressLine1 = x.AddressLine1,
                AddressLine2 = x.AddressLine2,
                Postcode = x.Postcode
            });        
        }

        // POST api/default1
        public void Post([FromBody]User value)
        {
            _userService.AddUser(new Business.DTO.User
            {
                Name = value.Name,
                EmailAddress = value.EmailAddress,
                AddressLine1 = value.AddressLine1,
                AddressLine2 = value.AddressLine2,
                Postcode = value.Postcode
            });            
        }

        // PUT api/default1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/default1/5
        public void Delete(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
