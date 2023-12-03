using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoOop
{
    public interface ITaskManager
    {
        Task Add(Task task);
        Task Edit(int id,Task editedtask);
        Task Get(int id);
        List<Task> GetAll();
        bool Delete(int id);
    }
}