using System.Collections.Concurrent;
using TaskManagerBackend.Models;

namespace TaskManagerBackend.Services;

public class TaskService : ITaskService
{
    private readonly ConcurrentDictionary<int, TaskItem> _tasks = new();
    private int _nextId = 1;
    private readonly object _lock = new();

    public IEnumerable<TaskItem> GetAll()
    {
        return _tasks.Values;
    }

    public TaskItem Add(string title)
    {
        lock (_lock)
        {
            var task = new TaskItem
            {
                Id = _nextId++,
                Title = title,
                Completed = false
            };
            _tasks.TryAdd(task.Id, task);
            return task;
        }
    }

    public bool UpdateStatus(int id, bool completed)
    {
        if (_tasks.TryGetValue(id, out var task))
        {
            task.Completed = completed;
            return true;
        }
        return false;
    }
}
