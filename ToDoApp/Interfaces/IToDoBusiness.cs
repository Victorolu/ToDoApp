using ToDoApp.Models;

namespace ToDoApp.Interfaces
{
    public interface IToDoBusiness
    {
        List<ToDoEntry> GetAllEntries();

        Task AddEntry(ToDoEntry entry);

        Task DeleteEntry(int id);

        Task UpdateEntry(ToDoEntry entry);
    }
}
