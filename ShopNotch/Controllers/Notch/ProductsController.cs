using Data.Models;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ShopNotch.Controllers.Notch
{
	[Area("Notch")]
	public class ProductsController : Controller
    {
        private readonly ProductLogic _productLogic;

        public ProductsController(ILogic<Product> logic)
        {
	        _productLogic = logic as ProductLogic;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(_productLogic.GetAll());
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
				return NotFound();
			}

			var product = _productLogic.GetById((int)id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Price,Sku,StockQty,Weight,Length,Width,Height")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productLogic.Add(product);
                
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) { return NotFound(); }

            var product = _productLogic.GetById((int)id);

            if (product == null) { return NotFound(); }

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Price,Sku,StockQty,Weight,Length,Width,Height")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
				_productLogic.Update(product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productLogic.GetById((int) id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _productLogic.GetById(id);

			_productLogic.Delete(product);
            
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
			return false; //(_productLogic.GetById(id))
        }
        
        public IActionResult Duplicate(int? id)
        {
	        if (id == null) { return NotFound(); }

	        var product = _productLogic.GetById((int) id);
	        if (product == null) { return NotFound(); }

			product.Id = 0;
			_productLogic.Add(product);

			return RedirectToAction(nameof(Index));
		}
    }
}
