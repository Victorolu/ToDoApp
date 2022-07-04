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
