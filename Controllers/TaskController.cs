using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetAllTasks()
        {
            List<TaskItem> tasks = await _taskRepository.GetAllTasks();
            return Ok(tasks);  
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskItem>>> GetTaskById(int id)
        {
            TaskItem task = await _taskRepository.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<List<TaskItem>>> AddTask([FromBody] TaskItem taskItem)
        {
            TaskItem task = await _taskRepository.AddTask(taskItem);
            return Ok(task); 
        }

        [HttpPut]
        public async Task<ActionResult<List<TaskItem>>> UpdateTask([FromBody] TaskItem taskItem, int id)
        {
            taskItem.Id = id;
            TaskItem task = await _taskRepository.UpdateTask(taskItem, id);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TaskItem>>> DeleteTask(int id)
        {
            bool delete = await _taskRepository.DeleteTask(id);
            return Ok(delete); 
        }
    }
}
