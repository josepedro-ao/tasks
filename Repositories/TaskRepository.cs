using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _dbContext;
        public TaskRepository(AppDbContext appDbContext) {
            _dbContext = appDbContext;
        }
        public async Task<List<TaskItem>> GetAllTasks()
        {
            return await _dbContext.Tasks.ToListAsync(); 
        }
        public async Task<TaskItem> GetTaskById(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<TaskItem> AddTask(TaskItem task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskItem taskById = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (taskById == null)
            {
                throw new Exception($"Task {id} não foi encontrada!");
            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync(); 

            return true;
        }

        public async Task<TaskItem> UpdateTask(TaskItem task, int id)
        {
            TaskItem taskById = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if(taskById == null)
            {
                throw new Exception($"Task {id} não foi encontrada!");
            }

            taskById.Title = task.Title;
            taskById.Description = task.Description;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }
    }
}
