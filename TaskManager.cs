using System.Net.Http.Headers;

namespace ToDoOop
{
    public class TaskManager : ITaskManager
    {
        private static List <Task> Tasks = new List<Task>();
        public Task Add(Task task)
        {
            Tasks.Add(task);
            return task;
        }
        public List<Task> GetAll()
        {
            return Tasks;
        }
        public Task Get(int id)
        {
            foreach (var task in Tasks)
            {
                if(task.Id == id)
                {
                    return task;
                }
            }
            return null;
        }

        public Task Edit(int id,Task editedtask)
        {
            foreach (var task in Tasks)
            {
                if(task.Id == id)
                {
                    task.TaskName = editedtask.TaskName;
                    task.Date = editedtask.Date;
                    return task;
                }
            }
            return null;
        }
        public bool Delete(int id)
        {
            var task = Get(id);
            if(task != null)
            {
                Tasks.Remove(task);
                return true;
            }
            return false;
        }
    }
}