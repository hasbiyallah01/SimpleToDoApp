namespace ToDoOop
{
    public class Menu
    {
        TaskManager _manager = new TaskManager();
        public void mainMenu()
        {
            bool IsContinue = true;
            while(IsContinue)
            {
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Task");
                Console.WriteLine("3. Edit Task");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Exit");
                int option = int.Parse(Console.ReadLine()!);
                switch(option)
                {
                    case 1:
                    AddTask();
                    break;
                    case 2:
                    ViewTasks();
                    break;
                    case 3:
                    Edit();
                    break;
                    case 4:
                    DeleteTask();
                    break;
                    case 5:
                    IsContinue = false;
                    break;
                    default:
                    Console.WriteLine("Invalid Input");
                    break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddTask()
        {
            Console.Write("Enter Task: ");
            string taskName = Console.ReadLine();
            Console.Write("Enter Date to carry out Task (yyyy-MM-dd): ");
            string input = Console.ReadLine();
            if(DateTime.TryParse(input,out DateTime date))
            {
                Task task = new Task(_manager.GetAll().Count+1, taskName, date);
                if(_manager.Add(task) != null)
                {
                    Console.WriteLine($"Task {task.TaskName} successfully Added!");
                }
                else
                {
                    Console.WriteLine("An error occured while adding Task!");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a date in yyyy-MM-dd format.");
            }
        }
    
        private void ViewTask(bool isView = true)
        {
            var tasks = _manager.GetAll();
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
            }
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i+1}. {tasks[i].TaskName}\t-\t{tasks[i].Date.ToString("dddd d, MMMM, yyyy")}");
            }
        }

        private void Edit()
        {
            ViewTask(false);
            Console.Write("Enter No. of Task to Edit: ");
            int input = int.Parse(Console.ReadLine());

            if(input > _manager.GetAll().Count)
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            Console.Write("Enter new Task: ");
            string name = Console.ReadLine();

            Console.Write("Enter new Date to carry out task (yyyy-MM-dd): ");
            string dateString = Console.ReadLine();  

            
            if (DateTime.TryParse(dateString, out DateTime date))
            {
                var task = _manager.GetAll()[input-1];
                task.TaskName = name;
                task.Date = date;
                
                if(_manager.Edit(task.Id, task) != null)
                {
                    Console.WriteLine($"Task {task.TaskName} successfully Edited!");
                }
                else
                {
                    Console.WriteLine("An error occured while editing Task!");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a date in yyyy-MM-dd format.");
            }
        }

        

        private void ViewTasks()
        {
            Console.WriteLine("List of Tasks:");
            ViewTask();
        }


        private void DeleteTask()
        {
            Console.WriteLine("Delete Task:");
            ViewTask();
            Console.Write("Enter the number of the task to delete: ");
            int input = int.Parse(Console.ReadLine());

            if (input > _manager.GetAll().Count || input <= 0)
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            int taskIdToDelete = _manager.GetAll()[input - 1].Id;

            if (_manager.Delete(taskIdToDelete))
            {
                Console.WriteLine($"Task with ID {taskIdToDelete} successfully deleted!");
            }
            else
            {
                Console.WriteLine("An error occurred while deleting the task!");
            }
        }

    }
}