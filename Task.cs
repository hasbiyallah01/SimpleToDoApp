namespace ToDoOop
{
    public class Task
    {
        public int Id{get; set;}
        public string TaskName{get; set;}
        public DateTime Date{get; set;}
        public Task(int id,string taskname,DateTime date)
        {
            Id = id;
            TaskName = taskname;
            Date = date;
        }
    }
}