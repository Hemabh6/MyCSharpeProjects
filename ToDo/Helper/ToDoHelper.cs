using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model;

namespace ToDo.Helper
{
    public class ToDoHelper
    {
        private string filetoread = "C:\\Users\\{{YOUR PC NAME}}\\Documents\\C#\\mylearning\\C#\\ToDo\\toDoTask.txt.txt";

        public List<ToDoModel> LoadToDos()
        {

            List<ToDoModel> todos = new List<ToDoModel> ();
            if (File.Exists(filetoread))
            {
                foreach(var line in File.ReadAllLines(filetoread))
                {
                    var parts = line.Split("|");
                    todos.Add(new ToDoModel
                    {
                        id = int.Parse(parts[0]),
                        Description = parts[1],
                        status = parts[2],
                        updateAt = DateTime.Now,
                        createdAt = DateTime.Now,
                    }
                    );
                }
            }
            return todos;
        }

        public void save(List<ToDoModel> toDoModels)
        {
            List<string> lists = toDoModels.Select(t => $"{t.id}|{t.Description}|{t.status}|{t.updateAt}|{t.createdAt}").ToList();
            File.WriteAllLines(filetoread, lists);
        }

    }


}
