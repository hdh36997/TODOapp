using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TODO_App.Models;
using TODO_App.Repozytorium.Interfaces;

namespace TODO_App.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskManager _taskManager;
        public TaskController(ITaskManager taskManager) //DI
        {
            _taskManager = taskManager;
        }
        public IActionResult Index()
        {
            return View(_taskManager.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int taskID)
        {
            var task = _taskManager.Get(taskID);
            return View(task);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(TaskModel task)
        {
            _taskManager.Add(task);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int taskID)
        {
            return View(_taskManager.Get(taskID));
        }
        [HttpPost]
        public IActionResult Delete(int taskID, TaskModel task)
        {
            _taskManager.Delete(taskID);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int taskID)
        {
            return View(_taskManager.Get(taskID));

        }
        [HttpPost]
        public IActionResult Update(int taskID, TaskModel task)
        {
            _taskManager.Update(taskID, task);
            return RedirectToAction(nameof(Index));
        }

        


    }
}
