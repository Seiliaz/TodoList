var todolist = new List<string>();
void PrintTodos() {
    for (int i = 0; i < todolist.Count; ++i) {
        Console.WriteLine($"{i + 1}. {todolist[i]}");
    }
}
bool shallExit = false;
Console.Clear();
Console.WriteLine("Hello");
var choices = new string[] {"s", "a", "r", "e"};
while (!shallExit) {
    string choice;
    do {
        Console.WriteLine("\nWhat do you want to do?\n[S]ee all todos\n[A]dd a todo\n[R]emove a todo\n[E]xit");
        choice = (Console.ReadLine() ?? "").ToLower();
        if (!choices.Contains(choice)) {
            Console.Clear();
            Console.WriteLine("Invalid choice.");
        }
    } while (!choices.Contains(choice));
    Console.Clear();
    switch (choice) {
        case "a":
            string todo;
            do
            {
                Console.WriteLine("Enter the TODO description.");
                todo = Console.ReadLine() ?? "";
                Console.Clear();
                if (todo == "") Console.WriteLine("The description cannot be empty.");
                if (todolist.Contains(todo)) Console.WriteLine("the TODO description must be unique.");
            } while (todolist.Contains(todo) || todo == "");
            todolist.Add(todo);
            break;
        case "s":
            PrintTodos();
            break;
        case "r":
            Console.WriteLine("Select the index of the TODO you want to remove");
            PrintTodos();
            int index;
            bool parseResult;
            do
            {
                string userChoice = Console.ReadLine() ?? "";
                parseResult = int.TryParse(userChoice, out index);
                if (userChoice == "") Console.WriteLine("Index cannot be empty.");
                else if (!parseResult) Console.WriteLine("Index must be a number.");
                else if (0 > index || index > todolist.Count + 1) Console.WriteLine("Invalid index number.");
                else if (parseResult) {
                    todolist.RemoveAt(index - 1);
                    Console.WriteLine("Removed successfully");
                }
            } while (!parseResult || 0 > index || index > todolist.Count + 1);
            break;
        case "e":
            Console.Clear();
            shallExit = true;
            break;
    }
}
