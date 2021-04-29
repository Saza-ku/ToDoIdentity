using System;
namespace ToDoIdentity.Models
{
    public class ViewModel
    {
        public string UserName { get; set; }
        public ToDoItem[] Items { get; set; }
    }
}
