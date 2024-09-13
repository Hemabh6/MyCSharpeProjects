using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Controller;

namespace ToDo.Model
{
    public class ToDoModel
    {
       public  int id {  get; set; }
       public string Description { get; set; }
        public string status { get; set; }
       public DateTime createdAt { get; set; }
       public  DateTime updateAt { get; set; }
    }
}
