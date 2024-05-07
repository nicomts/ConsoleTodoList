using ConsoleTodoList;
var todoManager = new TodoManager();

if (args.Length == 0)
{
    ShowHelp();
    return;
}

string command = args[0];

switch (command)
{
   case "--new":
       NewTodoItem(todoManager, args);
       break;
   case "--list":
       ListTodoItem(todoManager, args.Length > 1 ? args[1] : null);
       break;
}

static void ShowHelp()
{
    Console.WriteLine("HERE GOES THE HELP");
}

static void NewTodoItem(TodoManager todoManager, string[] args)
{
    if (args.Length > 1)
        todoManager.AddTodoItem(string.Join(" ", args.Skip(1)));
    else
        Console.WriteLine("Please provide a task.");
}

static void ListTodoItem(TodoManager todoManager, string filter)
{
    var todoItems = todoManager.GetTodoItems(filter);
    foreach (var item in todoItems)
    {
        Console.WriteLine($"{item.Id}\t{item.Task}\t{(item.IsDone ? "Done" : "Pending")}");
    }
}
