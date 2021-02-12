﻿using System.ComponentModel.DataAnnotations;
using Codesmith.MvcSample.BusinessObjects;

namespace Codesmith.MvcSample.Web.Models
{
    public class UserEditModel
    {
        [Required]
        public int UserId { get; set; }
        [Required, MinLength(3), MaxLength(255)]
        public string Username { get; set; }
        [Required, Compare("Password"), MinLength(6), MaxLength(255)]
        //public UserRoleType Role { get; set; }

        public string Password { get; set; }
        [Required, MinLength(6), MaxLength(255)]
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }
    }
}