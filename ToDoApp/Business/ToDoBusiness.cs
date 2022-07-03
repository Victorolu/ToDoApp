using ToDoApp.Interfaces;
using ToDoApp.Models;

namespace ToDoApp.Business
{
    public class ToDoBusiness : IToDoBusiness
    {
        private readonly ApplicationDbContext _dbContext;

        public ToDoBusiness(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ToDoEntry> GetAllEntries()
        {
            List<ToDoEntry> entries = new List<ToDoEntry>();
            entries = _dbContext.ToDoEntries.ToList();
            return entries;
        }

        public async Task AddEntry(ToDoEntry entry)
        {
            try
            {
                _dbContext.ToDoEntries.Add(entry);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task DeleteEntry(int id)
        {
            try
            {
                ToDoEntry entry = new ToDoEntry() { Id = id };
                _dbContext.ToDoEntries.Attach(entry);
                _dbContext.ToDoEntries.Remove(entry);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public async Task UpdateEntry(ToDoEntry entry)
        {
            try
            {
                _dbContext.ToDoEntries.Update(entry);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
