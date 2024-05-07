namespace ConsoleTodoList;

public class TodoManager
{
    private readonly List<TodoItem> _todoList;
    private int _currentId;

    public TodoManager()
    {
        _todoList = new List<TodoItem>();
        _currentId = 1;
    }

    public void AddTodoItem(string task)
    {
        _todoList.Add(new TodoItem { Id = _currentId++, Task = task, IsDone = false});
    }

    public IEnumerable<TodoItem> GetTodoItems(string filter)
    {
        IEnumerable<TodoItem> todoItems = _todoList;
        if (filter == "pending")
            todoItems = _todoList.Where(item => !item.IsDone);
        else if (filter == "done")
            todoItems = _todoList.Where(item => item.IsDone);
        return todoItems;
    }

    public bool MarkTodoItemAsDone(int id)
    {
        var todoItem = _todoList.FirstOrDefault(item => item.Id == id);
        if (todoItem != null)
        {
            todoItem.IsDone = true;
            return true;
        }
        return false;
    }

    public bool DeleteTodoItem(int id)
    {
        var todoItem = _todoList.FirstOrDefault(item => item.Id == id);
        if (todoItem != null)
        {
            _todoList.Remove(todoItem);
            return true;
        }

        return false;
    }
}