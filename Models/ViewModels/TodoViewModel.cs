using System.Collections.Generic;
using Todo.Controllers;

namespace Todo.Models.ViewModels
{
    public class TodoViewModel
    {
        public List<list> TodoList { get; set; }
        public list Todo { get; set; }
    }
}