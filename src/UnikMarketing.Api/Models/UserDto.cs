using System.Collections.Generic;

namespace UnikMarketing.Api.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public CriteriaDto Criteria { get; set; }
    }
}