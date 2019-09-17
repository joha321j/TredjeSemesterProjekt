﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vitec.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZIP { get; set; }
        public int PhoneNumber { get; set; }
        public string Salt { get; set; }
        public string HashedPassword { get; set; }
    }
}