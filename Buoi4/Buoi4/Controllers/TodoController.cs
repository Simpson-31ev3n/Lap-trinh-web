using Microsoft.AspNetCore.Mvc;
using Buoi4.Models;
using System.Collections.Generic;
using System.Linq;

namespace Buoi4.Controllers
{
    public class TodoController : Controller
    {
        // Fake database
        private static List<TodoItem> todos = new List<TodoItem>()
        {
            new TodoItem { Id = 1, Title = "Đi chợ", IsCompleted = true },
            new TodoItem { Id = 2, Title = "Chơi thể thao", IsCompleted = false },
            new TodoItem { Id = 3, Title = "Chơi game", IsCompleted = false },
            new TodoItem { Id = 4, Title = "Học bài", IsCompleted = true },
        };

        // ============================ LIST ============================
        public IActionResult Index()
        {
            return View(todos);
        }

        // ============================ DETAILS ============================
        public IActionResult Details(int id)
        {
            var item = todos.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        // ============================ CREATE ============================
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TodoItem model)
        {
            if (ModelState.IsValid)
            {
                model.Id = todos.Any() ? todos.Max(x => x.Id) + 1 : 1;
                todos.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // ============================ EDIT ============================
        public IActionResult Edit(int id)
        {
            var item = todos.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(TodoItem model)
        {
            if (ModelState.IsValid)
            {
                var item = todos.FirstOrDefault(x => x.Id == model.Id);
                if (item != null)
                {
                    item.Title = model.Title;
                    item.IsCompleted = model.IsCompleted;
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // ============================ DELETE ============================
        public IActionResult Delete(int id)
        {
            var item = todos.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var item = todos.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                todos.Remove(item);
            }
            return RedirectToAction("Index");
        }
    }
}
