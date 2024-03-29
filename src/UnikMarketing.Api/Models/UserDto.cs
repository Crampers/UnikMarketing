﻿using System;
using System.Collections.Generic;

using UnikMarketing.Domain;

namespace UnikMarketing.Api.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public ICollection<RequestDto> Requests { get; set; }
        public CriteriaDto Criteria { get; set; }
    }
}
