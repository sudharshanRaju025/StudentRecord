﻿namespace StudentRecord.Models
{
    public class AddStudentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string Phone { get; set; }
        public string Email { get; set; } 

        public bool subscribed { get; set; } 
    }
}
