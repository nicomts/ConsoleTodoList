namespace ConsoleTodoList;

public class TodoManager
{
    public void AddTodoItem(string task)
    {
        using (var context = new TodoContext())
        {
            var todoItem = new TodoItem() { Task = task, IsDone = false };
            context.TodoItems.Add(todoItem);
            context.SaveChanges();
        }
    }

    public IEnumerable<TodoItem> GetTodoItems(string filter)
    {
        using (var context = new TodoContext())
        {
            IQueryable<TodoItem> todoItems = context.TodoItems;
            if (filter == "pending")
                todoItems = todoItems.Where(item => !item.IsDone);
            else if (filter == "done")
            {
                todoItems = todoItems.Where(item => item.IsDone);
            }

            return todoItems.ToList();
        }
    }
    
}