using System.Collections.Generic;
using TODO_App.Models;

namespace TODO_App.Repozytorium.Interfaces
{
    public interface ITaskManager
    {
        public List<TaskModel> GetAll();
        public TaskModel Get(int taskId);
        public void Add(TaskModel taskID);
        public void Delete(int taskID);
        public void Update(int taksID, TaskModel task);
    }
}
