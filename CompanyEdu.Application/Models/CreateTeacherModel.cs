﻿using System.ComponentModel.DataAnnotations;

namespace CompanyEdu.Application.Models
{
    public class CreateTeacherModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        public string? Fullname { get; set; }
    }
}
