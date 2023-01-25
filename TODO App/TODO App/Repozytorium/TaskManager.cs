using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO_App.Models;
using TODO_App.Repozytorium.Interfaces;

namespace TODO_App.Repozytorium
{
    public class TaskManager : ITaskManager
    {
        private readonly DbTaskContext _context;
        public TaskManager(DbTaskContext context) //DI
        {
            _context = context;
        }
        public List<TaskModel> GetAll()
        {
            var tasks = _context.Tasks.ToList();
            return tasks;
        }
        public TaskModel Get(int taskID)
        {
            var task = _context.Tasks.Find(taskID);
            return task;
        }
        public void Add(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
        public void Delete(int taskID)
        {
            var task = _context.Tasks.Find(taskID);
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
        public void Update(int taskID, TaskModel task)
        {
            var old = _context.Tasks.Find(taskID);
            old.Name = task.Name;
            old.Descripiton= task.Descripiton;
            old.Done= task.Done;
            _context.SaveChanges();
        }

    }
}
