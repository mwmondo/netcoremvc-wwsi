using TodoCRUD.Core.Interfaces;
using TodoCRUD.Models;

namespace TodoCRUD.Core.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public void Create(TodoModel todo)
        {
            using (var context = new TodoContext())
            {
                todo.TodoId = 0;
                
                if (todo.TodoIdParent == 0)
                    todo.TodoIdParent = null;

                context.Add(todo);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new TodoContext())
            {
                TodoModel? todo = context.Todos.FirstOrDefault(f => f.TodoId == id);
                if (todo != null)
                {
                    List<TodoModel> todoList = context.Todos.Where(f => f.TodoIdParent == todo.TodoId).ToList();
                    context.Remove(todo);

                    for (int i = 0; i < todoList.Count; i++)
                        context.Remove(todoList[i]);

                    context.SaveChanges();
                }
            }
        }

        public TodoModel? Get(int id)
        {
            using (var context = new TodoContext())
            {
                TodoModel? todo = context.Todos.FirstOrDefault(f => f.TodoId == id);
                return todo;
            }
        }

        public IEnumerable<TodoModel> GetAll()
        {
            using (var context = new TodoContext())
            {
                List<TodoModel> todos = context.Todos.ToList();
                return todos;
            }
        }

        public IEnumerable<TodoModel> GetAllChildrens(int id)
        {
            using (var context = new TodoContext())
            {
                List<TodoModel> todos = context.Todos.Where(w => w.TodoIdParent == id).ToList();
                return todos;
            }
        }

        public IEnumerable<TodoModel> GetAllParents()
        {
            using (var context = new TodoContext())
            {
                List<TodoModel> todos = context.Todos.Where(w => w.TodoIdParent == null).ToList();
                return todos;
            }
        }

        public void Update(TodoModel todo)
        {
            using (var context = new TodoContext())
            {
                TodoModel? todoToUpdate = context.Todos.FirstOrDefault(f => f.TodoId == todo.TodoId);
                if (todoToUpdate != null)
                {
                    todoToUpdate.TodoTitle = todo.TodoTitle;
                    todoToUpdate.TodoDescription = todo.TodoDescription;
                    todoToUpdate.TodoStatus = todo.TodoStatus;
                    todoToUpdate.TodoIdParent = todo.TodoIdParent;

                    context.SaveChanges();
                }
            }
        }
    }
}
