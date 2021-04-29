﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoIdentity.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        public string ToDo { get; set; }
        public string UserId { get; set; }
    }
}
