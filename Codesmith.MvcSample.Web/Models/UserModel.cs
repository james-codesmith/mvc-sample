﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Codesmith.MvcSample.BusinessObjects;

namespace Codesmith.MvcSample.Web.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        //public UserRoleType Role { get; set; }
        public bool IsActive { get; set; }

    }
}