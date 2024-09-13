using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Helper;
using ToDo.Model;

namespace ToDo.Controller
{
    public class ToDo_Item
    {
        private ToDoHelper helper = new ToDoHelper();
        public void AddToDo(ToDoModel description)
        {
            List<ToDoModel> todo = helper.LoadToDos();
            int newId = todo.Count > 0 ? todo.Max(t => t.id) + 1 : 1;
            ToDoModel item = new ToDoModel
            {
                id = newId,
                Description = description.Description,
                status = description.status,
                createdAt = DateTime.Now
            };

            todo.Add(item);
            helper.save(todo);
            Console.WriteLine("To-Do added successfully!");

        }

        public void EditList(int id, ToDoModel description)
        {
            List<ToDoModel> toDoModels = helper.LoadToDos();
            ToDoModel item = toDoModels.FirstOrDefault(t => t.id == id);
            if (item == null)
            {
                Console.WriteLine("No record Found With the Id {toDoModels.id}");
            }
            else
            {
                item.Description = description.Description;
                item.updateAt = DateTime.Now;

            }

            toDoModels.Add(item);
            helper.save(toDoModels);
            Console.WriteLine("Updated successfully");
        }
        public void DeleteList(int id)
        {
            List<ToDoModel> toDoList = helper.LoadToDos();
            ToDoModel listId = toDoList.FirstOrDefault(t => t.id == id);
            if(listId == null)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                toDoList.Remove(listId);
                helper.save(toDoList);
            }
            Console.WriteLine("Removed Successfully");
        }

        public void MarkAsComplete(int id)
        {
            List<ToDoModel> toDoModels = helper.LoadToDos();
            ToDoModel itemList = toDoModels.FirstOrDefault(t => t.id==id);
            if (itemList == null)
            {
                Console.WriteLine("No item found");
            }
            else
            {
                itemList.status = "Complete";
            }
            toDoModels.Add(itemList);
            helper.save(toDoModels);
            Console.WriteLine("Successfully Completed");
        }

        public void ViewTodos()
        {
            List<ToDoModel> todos = helper.LoadToDos();
            foreach (var todo in todos)
            {
                Console.WriteLine($"{todo.id}: {todo.Description} (Completed: {todo.status}):(Last Modified: {todo.updateAt})");
            }
        }

        public void DeleteAll() {
        
            List<ToDoModel> newList = helper.LoadToDos();
            newList.Clear();
            helper.save(newList);
        }
        public List<ToDoModel> LoadToDOs()
        {
           
            if(helper.LoadToDos() == null)
            {
               Console.WriteLine("No data found");
                return new List<ToDoModel>(); ;
            }
            helper.LoadToDos();
            return new List<ToDoModel>(); // Return an empty list or load from storage
        }

    }
}
