using System;
using ToDo.Controller;
using ToDo.Helper;
using ToDo.Model;

class Program
{
    static void Main(string[] args)
    {

        ToDo_Item controller = new ToDo_Item();
        ToDoHelper helper = new ToDoHelper();
        while (true)
        {
            Console.WriteLine("1. Add To-Do");
            Console.WriteLine("2. Edit To-Do");
            Console.WriteLine("3. Delete To-Do");
            Console.WriteLine("4. Mark as Complete");
            Console.WriteLine("5. View All To-Dos");
            Console.WriteLine("6. Delete All");
            Console.WriteLine("7. Exit");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter a description for the new to-do item:");
                    string description = Console.ReadLine();
                    ToDoModel newToDo = new ToDoModel
                    {
                        id = helper.LoadToDos().Count > 0 ? helper.LoadToDos().Max(tc => tc.id) + 1 : 1,
                        Description = description,
                        status = "Incomplete",
                        createdAt = DateTime.Now,
                        updateAt = DateTime.Now
                    };
                    controller.AddToDo(newToDo);
                    break;
                case "2":
                    Console.WriteLine("Enter the ID of the to-do you want to edit:");
                    int editId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the new description:");
                    string newDescription = Console.ReadLine();
                    ToDoModel newToDo1 = new ToDoModel
                    {
                        id = helper.LoadToDos().Count > 0 ? helper.LoadToDos().Max(tc => tc.id) + 1 : 1,
                        Description = newDescription,
                        status = "Incomplete",
                        createdAt = DateTime.Now,
                        updateAt = DateTime.Now
                    };
                    controller.EditList(editId, newToDo1);
                    break;
                case "3":
                    Console.WriteLine("Enter the ID of the to-do you want to delete:");
                    int deleteId = int.Parse(Console.ReadLine());
                    controller.DeleteList(deleteId);
                    break;
                case "4":
                    Console.WriteLine("Enter the ID of the to-do you want to mark as complete:");
                    int completeId = int.Parse(Console.ReadLine());
                    controller.MarkAsComplete(completeId);
                    break;
                case "5":
                    controller.ViewTodos();
                    break;
                case "6":
                    controller.DeleteAll();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
