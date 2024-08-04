﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.Events.Domain.Entities
{
    public class AuthResponse
    {
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty ;
        public bool Success { get; set; }
        public string token { get; set; } = string.Empty;
    }
}
