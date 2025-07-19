using System;

namespace ToDoConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ToDoItem> todoList = new List<ToDoItem>();

            while(true)
            {
                Console.WriteLine("\nToDo App Menu:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Mark Task as Completed");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an Option: (1-5): ");

                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        Console.WriteLine("Enter Task Description");
                        string description = Console.ReadLine();
                        try
                        {
                            todoList.Add(new ToDoItem(description));
                            Console.WriteLine("Task Added!");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nTasks:");
                        if(todoList.Count == 0)
                        {
                            Console.WriteLine("No Tasks Available");
                        }
                        else
                        {
                            foreach(ToDoItem task in todoList)
                            {
                                Console.WriteLine(task);
                            }
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nEnter Task ID: ");
                        if(int.TryParse(Console.ReadLine(), out int completeId))
                        {
                            ToDoItem taskToComplete = todoList.Find(t => t.Id == completeId);
                            if(taskToComplete != null)
                            {
                                taskToComplete.IsCompleted = true;
                                Console.WriteLine("Task Marked as Complete");
                            }
                            else
                            {
                                Console.WriteLine("Task Not Found!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID!");
                        }
                        break;

                    case "4":
                        Console.WriteLine("\nEnter Task ID: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            ToDoItem taskToDelete = todoList.Find(t => t.Id == deleteId);
                            if(taskToDelete != null)
                            {
                                todoList.Remove(taskToDelete);
                                Console.WriteLine("Task Removed!");
                            }
                            else
                            {
                                Console.WriteLine("Task Not Found!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID!");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Goodbye!..");
                        return;

                    default:
                        Console.WriteLine("Invalid Option! Choose 1-5");
                        break;
                        
                }
            }
        }
    }

    public class ToDoItem
    {
        public static int idCurr = 0;
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int Id { get; private set; }

        public ToDoItem(string description)
        {
            if(String.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be empty or whitespace.");
            }
            Description = description;
            IsCompleted = false;
            Id = idCurr++;
        }

        public override string ToString()
        {
            return $"[{Id}] {Description} {(IsCompleted ? "Completed" : "")}";
        }

    }
}