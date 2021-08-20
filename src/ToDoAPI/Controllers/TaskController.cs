using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Data;
using System.Collections.Generic;
using ToDoAPI.Models;
using System.Net.Http;
using Microsoft.AspNetCore.JsonPatch;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/Tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepo _myTask;
        public TaskController(ITaskRepo myTask)
        {
            _myTask = myTask;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Task>> Get()
        {
            return Ok(_myTask.GetTasks());
        }
        [HttpPost]
        public ActionResult<Task> Create(Task task)
        {
            var TaskExists = _myTask.GetTaskById(task.ID);


            if (ModelState.IsValid)
            {
                if (TaskExists != null)
                {
                    return BadRequest();
                }
                _myTask.AddTask(task);
                _myTask.SaveChanges();
                return CreatedAtAction(nameof(Get), task);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _myTask.DeleteTask(id);
                _myTask.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPatch("{id}")]
        public ActionResult Update(int id, [FromBody] JsonPatchDocument<Task> patchTask)
        {

            if (patchTask != null)
            {
                var TaskExists = _myTask.GetTaskById(id);

                patchTask.ApplyTo(TaskExists, ModelState);
                _myTask.SaveChanges();

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(TaskExists);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}