using TodoCRUD.Models;

namespace TodoCRUD.Core.Interfaces
{
    public interface ITodoRepository
    {
        public TodoModel? Get(int id);
        public IEnumerable<TodoModel> GetAll();
        public IEnumerable<TodoModel> GetAllParents();
        public IEnumerable<TodoModel> GetAllChildrens(int id);
        public void Create(TodoModel todo);
        public void Update(TodoModel todo);
        public void Delete(int id);
    }
}
