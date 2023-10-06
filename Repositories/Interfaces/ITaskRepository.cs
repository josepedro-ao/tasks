using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetAllTasks();
        Task<TaskItem> GetTaskById(int id);
        Task<TaskItem> AddTask(TaskItem task);
        Task<TaskItem> UpdateTask(TaskItem task, int id);
        Task<bool> DeleteTask(int id);

    }
}
