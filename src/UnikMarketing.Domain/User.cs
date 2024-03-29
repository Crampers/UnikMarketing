﻿using System.Collections.Generic;

namespace UnikMarketing.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public ICollection<Request> Requests { get; } = new List<Request>();
        public Criteria Criteria { get; set; } = new Criteria();
    }
}