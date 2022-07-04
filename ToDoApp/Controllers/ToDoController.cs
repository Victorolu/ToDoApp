using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Interfaces;
using ToDoApp.Models;
using ToDoApp.ViewModels;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoBusiness _toDoBusiness;

        public ToDoController(IToDoBusiness toDoBusiness)
        {
            _toDoBusiness = toDoBusiness;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ToDoViewModel model = new ToDoViewModel();
            // You can choose to have these as mock data to load up the page or uncomment what is below to access data from database.
            //model.Entries = new List<ToDoEntry>()
            //{
            //    new ToDoEntry() { Id = 1, EntryText = "Water floor plants", IsActive = true, CreatedBy = DateTime.UtcNow, ExpiresBy = null },
            //    new ToDoEntry() { Id = 2, EntryText = "Call Doctor", IsActive = false, CreatedBy = DateTime.UtcNow, ExpiresBy = DateTime.UtcNow.AddDays(2) },
            //    new ToDoEntry() { Id = 3, EntryText = "Buy groceries", IsActive = true, CreatedBy = DateTime.UtcNow, ExpiresBy = null },
            //    new ToDoEntry() { Id = 4, EntryText = "Collect car keys", IsActive = true, CreatedBy = DateTime.UtcNow, ExpiresBy = null },
            //    new ToDoEntry() { Id = 5, EntryText = "Prepare for interview", IsActive = false, CreatedBy = DateTime.UtcNow, ExpiresBy = DateTime.UtcNow.AddDays(2) },
            //    new ToDoEntry() { Id = 6, EntryText = "Pray", IsActive = true, CreatedBy = DateTime.UtcNow, ExpiresBy = null },
            //    new ToDoEntry() { Id = 7, EntryText = "Write introduction of thesis", IsActive = true, CreatedBy = DateTime.UtcNow, ExpiresBy = null },
            //    new ToDoEntry() { Id = 8, EntryText = "Watch tutorials", IsActive = false, CreatedBy = DateTime.UtcNow, ExpiresBy = DateTime.UtcNow.AddDays(3)},
            //    new ToDoEntry() { Id = 9, EntryText = "Speak to pastor", IsActive = true, CreatedBy = DateTime.UtcNow, ExpiresBy = null }
            //};
            var entries = _toDoBusiness.GetAllEntries();
            model.Entries = entries;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ToDoEntry entry)
        {
            try
            {
                var entryId = await _toDoBusiness.AddEntry(entry);
                return Json(new
                {
                    success = true,
                    entryId
                });
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    succes = false,
                    errorMessage = ex.ToString()
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEntry(int id)
        {
            try
            {
                await _toDoBusiness.DeleteEntry(id);
                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    succes = false,
                    errorMessage = ex.ToString()
                });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody]ToDoEntry entry)
        {
            try
            {
                await _toDoBusiness.UpdateEntry(entry);
                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    succes = false,
                    errorMessage = ex.ToString()
                });
            }
        }
    }
}
