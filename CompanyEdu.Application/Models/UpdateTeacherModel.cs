﻿namespace CompanyEdu.Application.Models
{
    public class UpdateTeacherModel
    {
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Fullname { get; set; }
    }
}