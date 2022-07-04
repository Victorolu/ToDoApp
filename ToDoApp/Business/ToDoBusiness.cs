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

        public async Task<int> AddEntry(ToDoEntry entry)
        {
            try
            
            {
                entry.CreatedBy = DateTime.Now;
                _dbContext.ToDoEntries.Add(entry);
                await _dbContext.SaveChangesAsync();
                return entry.Id;
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
                var entryObject = _dbContext.ToDoEntries.SingleOrDefault(x => x.Id == id);
                if (entryObject != null)
                {
                    _dbContext.ToDoEntries.Attach(entryObject);
                    _dbContext.ToDoEntries.Remove(entryObject);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Could not find record");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public async Task UpdateEntry(ToDoEntry entry)
        {
            //This should be used to update fields like EntryText, IsActive or ExpireBy
            try
            {
                var entryObject = _dbContext.ToDoEntries.SingleOrDefault(x => x.Id == entry.Id);
                if (entryObject != null)
                {
                    entryObject.EntryText = entry.EntryText != null ? entry.EntryText : entryObject.EntryText;
                    entryObject.IsActive = entry.IsActive;
                    _dbContext.ToDoEntries.Update(entryObject);
                    await _dbContext.SaveChangesAsync();
                } else
                {
                    throw new Exception("Could not find record");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
