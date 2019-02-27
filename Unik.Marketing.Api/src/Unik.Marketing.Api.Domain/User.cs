namespace Unik.Marketing.Api.Domain
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public Criteria Criteria { get; set; } = new Criteria();
    }
}