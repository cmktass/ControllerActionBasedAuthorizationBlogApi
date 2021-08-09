﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace cmkts.blog.viewmodel.ViewModels
{
    public class UserVM
    {
        [Required,MaxLength(40,ErrorMessage ="Maximum 30 karakter olabilir.")]
        public string FirstName { get; set; }

        [Required, MaxLength(40, ErrorMessage = "Maximum 30 karakter olabilir.")]
        public string LastName { get; set; }

        [Required, MaxLength(11, ErrorMessage = "11 karakterli olmalı"),MinLength(11,ErrorMessage ="11 karakterli olmalı")]
        public string Gsm { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        public DateTime RegisteredAt { get; set; }
        public string ProfileImage { get; set; }
        public string Resume { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Job { get; set; }
        public string ProfileText { get; set; }
        public string ProfileDescription { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
