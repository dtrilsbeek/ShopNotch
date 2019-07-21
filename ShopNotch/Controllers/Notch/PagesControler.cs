/*
using Data.Models;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ShopNotch.Controllers.Notch
{
	[Area("Notch")]
	public class PagesController : Controller
    {
        private readonly PageLogic _pageLogic;

        public PagesController(IEntityLogic<Product> logic)
        {
	        _pageLogic = logic as PageLogic;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(_pageLogic.GetAll());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
				return NotFound();
			}

			var page = _pageLogic.GetById((int)id);
			if (page == null)
			{
				return NotFound();
			}

			return View(page);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Price,Sku,StockQty,Weight,Length,Width,Height")] Page page)
        {
            if (ModelState.IsValid)
            {
                _pageLogic.Add(page);
                
                return RedirectToAction(nameof(Index));
            }
            return View(page);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) { return NotFound(); }

            var product = _pageLogic.GetById((int)id);

            if (product == null) { return NotFound(); }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Price,Sku,StockQty,Weight,Length,Width,Height")] Page page)
        {
            if (id != page.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
				_pageLogic.Update(page);

                return RedirectToAction(nameof(Index));
            }
            return View(page);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = _pageLogic.GetById((int) id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var page = _pageLogic.GetById(id);

			_pageLogic.Delete(page);
            
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
			return false; //(_productLogic.GetById(id))
        }
        
        public IActionResult Duplicate(int? id)
        {
	        if (id == null) { return NotFound(); }

	        var page = _pageLogic.GetById((int) id);
	        if (page == null) { return NotFound(); }

			page.Id = 0;
			_pageLogic.Add(page);

			return RedirectToAction(nameof(Index));
		}
    }
}
*/
