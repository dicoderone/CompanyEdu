﻿namespace CompanyEdu.Application.Models
{
    public class UpdateGroupModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? TeacherId { get; set; }
    }
}
