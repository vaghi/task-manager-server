using TaskManagerBackend.Models;

namespace TaskManagerBackend.Services;

public interface ITaskService
{
    IEnumerable<TaskItem> GetAll();
    TaskItem Add(string title);
    bool UpdateStatus(int id, bool completed);
}
