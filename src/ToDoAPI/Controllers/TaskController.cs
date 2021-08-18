using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Data;

namespace ToDoAPI.Controllers
{
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepo _myTask;
        public TaskController(ITaskRepo myTask)
        {
            _myTask = myTask;
        }
    }
}