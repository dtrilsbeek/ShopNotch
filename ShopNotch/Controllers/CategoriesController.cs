using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Logic;
using Logic.Interfaces;
using ShopNotch.Models;

namespace ShopNotch.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryLogic _categoryLogic;

        public CategoriesController(ILogic<Category> logic)
        {
	        _categoryLogic = logic as CategoryLogic;
        }

        // GET: Categories
        public IActionResult Index()
        {
			CreateViewModel model = new CreateViewModel(_categoryLogic.GetAll());

            return View( model );
        }

        // GET: Categories/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryLogic.GetById((int) id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
	        IEnumerable<Category> categories = _categoryLogic.GetAll();

	        var enumerable = categories.ToList();
	        CreateViewModel model = new CreateViewModel(enumerable)
	        {
		        CategoryNames = GetAllNames(enumerable)
	        };

	        //IEnumerable<Category> parentCategories = _categoryLogic.GetParentCategories();

	        if (model.ParentId != null)
			{
				model.ParentName = _categoryLogic.GetById((int) model.ParentId).Name;
			}



			return View(model);
        }

        private List<SelectListItem> GetAllNames(IEnumerable<Category> categories)
        {
	        List<SelectListItem> list = new List<SelectListItem>();

	        foreach (Category category in categories)
	        {
		        list.Add(new SelectListItem(category.Name, category.Id.ToString()));
	        }

	        return list;
        }

		// POST: Categories/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryLogic.Add(category);

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryLogic.GetById((int) id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,ParentId")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _categoryLogic.Update(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryLogic.GetById((int) id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
	        var category = _categoryLogic.GetById(id);
            _categoryLogic.Delete(category);

            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
	        return (_categoryLogic.GetById(id) != null);
        }
    }
}
