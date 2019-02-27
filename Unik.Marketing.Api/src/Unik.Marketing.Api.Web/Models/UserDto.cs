namespace Unik.Marketing.Api.Web.Models
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