using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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
                status = "Not Done",
                createdAt = DateTime.Now
            };

            todo.Add(item);
            helper.save(todo);
            Console.WriteLine("To-Do added successfully!");

        }

        public void EditList(int id, ToDoModel description)
        {
            ViewTodos();
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
            ViewTodos();
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

        public void MarkTaskStatus(int id, string statusTag)
        {
            ViewTodos();
            List<ToDoModel> toDoModels = helper.LoadToDos();
            ToDoModel itemList = toDoModels.FirstOrDefault(t => t.id == id);
            if (itemList == null)
            {
                Console.WriteLine("No item found");
            }
            else if (statusTag == "a")
            {
                itemList.status = "Done";
                itemList.updateAt = DateTime.Now;
            }
            else if(statusTag == "b")
            {
                itemList.status = "Not Done";
                itemList.updateAt = DateTime.Now;
            }else if(statusTag == "c")
            {
                itemList.status = "In Progress";
                itemList.updateAt = DateTime.Now;
            }
            else
            {
                Console.WriteLine("Enter a valid option.");
            }
            toDoModels.Add(itemList);
            helper.save(toDoModels);
            Console.WriteLine("Successfully Completed");
        }

        public void ListDoneTasks(string taskStatus)
        {
            ViewTodos();
            List<ToDoModel> doneList = helper.LoadToDos();
            List<ToDoModel> listAllDone = doneList.Where(t => t.status == "Done").ToList();
            List<ToDoModel> listAllNotDone = doneList.Where(t => t.status == "Not Done").ToList();
            List<ToDoModel> listAllInProgress = doneList.Where(t => t.status == "In Progress").ToList();
            if (listAllDone == null)
            {
                Console.WriteLine("no task found");
            }
            else if(taskStatus == "a")
            {
                if (listAllDone.Any()) { 
                    foreach (ToDoModel item in doneList)
                    {
                        Console.WriteLine($"{item.id}:{item.Description}:{item.updateAt}");
                    }
                }
                else
                {
                    Console.WriteLine("No 'Done' task found");
                }
            }
            else if(taskStatus == "b")
            {
                if (listAllNotDone.Any()) { 
                    foreach (ToDoModel item in listAllNotDone)
                    {
                        Console.WriteLine($"{item.id}:{item.Description}:{item.updateAt}");
                    }
                }
                else
                {
                    Console.WriteLine("No task found with 'Not Done' status");
                }

            }else if(taskStatus == "c") {
                foreach (ToDoModel item in listAllInProgress)
                {
                    Console.WriteLine($"{item.id}:{item.Description}:{item.updateAt}");
                }
            }
            else if (taskStatus == "d")
            {
                ViewTodos();
            }else
            {
                Console.WriteLine("Select valid option among a, b and c");
            }
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
