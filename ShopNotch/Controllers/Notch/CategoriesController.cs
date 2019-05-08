﻿using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopNotch.Models;

namespace ShopNotch.Controllers.Notch
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
			CategoryViewModel model = new CategoryViewModel
			{
				Categories = _categoryLogic.GetAll(),
				Tree = _categoryLogic.GetCategoryTree()
			};

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

            CategoryViewModel model = new CategoryViewModel
            {
	            Category = category,
            };

			return View(model);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
	        IEnumerable<Category> categories = _categoryLogic.GetAll();

	        var enumerable = categories.ToList();
	        CategoryViewModel model = new CategoryViewModel()
	        {
		        Categories = enumerable,
		        CategoryNames = GetAllNames(enumerable)
	        };

			return View(model);
        }

		// POST: Categories/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel model)
        {
	        Category category = new Category
	        {
		        Id = 0,
		        Name = model.Name,
				ParentId = model.SelectedParent
	        };

			if (ModelState.IsValid)
            {
	            _categoryLogic.Add(category);
				
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Categories/Edit/5
        public IActionResult Edit(int? id)
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

            CategoryViewModel model = new CategoryViewModel
            {
	            Category = category,
            };

            model.CategoryNames = category.Parent != null ? GetAllNames(_categoryLogic.GetAll(), category.Parent) : GetAllNames(_categoryLogic.GetAll());

            return View(model);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CategoryViewModel model)
        {
            if (id != model.Category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
	            if (model.SelectedParent != null)
	            {
		            model.Category.ParentId = (int) model.SelectedParent;
	            }
                try
                {
                    _categoryLogic.Update(model.Category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(model.Category.Id))
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
            return View(model);
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

        private List<SelectListItem> GetAllNames(IEnumerable<Category> categories)
        {
	        List<SelectListItem> list = new List<SelectListItem>();

	        foreach (Category category in categories)
	        {
		        list.Add(new SelectListItem(category.Name, category.Id.ToString()));
	        }

	        return list;
        }
        private List<SelectListItem> GetAllNames(IEnumerable<Category> categories, Category selected)
        {
	        List<SelectListItem> list = new List<SelectListItem>();

	        foreach (Category category in categories)
	        {
		        if (category.Id == selected.Id)
		        {
			        list.Add(new SelectListItem(category.Name, category.Id.ToString(), true));
		        }
		        else
		        {
			        list.Add(new SelectListItem(category.Name, category.Id.ToString()));
		        }
	        }

	        return list;
        }

	}
}