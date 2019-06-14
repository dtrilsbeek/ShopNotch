using System.Collections.Generic;
using Data.Models;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ShopNotch.Models;
using ShopNotch.Models.Classes;

namespace ShopNotch.Controllers.Notch
{
	[Area("Notch")]
	public class ProductsController : Controller
    {
        private readonly IProductLogic _productLogic;
        private readonly ICategoryLogic _categoryLogic;
        private Mapper _mapper;

        public ProductsController(IProductLogic productLogic, ICategoryLogic categoryLogic)
        {
	        _productLogic = productLogic;
	        _categoryLogic = categoryLogic;
			_mapper = new Mapper();
        }

        public IActionResult Index()
        {
	        var products = _productLogic.GetAll();
	        var model = new ProductViewModel
	        {
		        Products = new List<ProductModel>()
	        };

	        foreach (var product in products)
	        {
		        model.Products.Add(_mapper.GetProductModel(product));
	        }

            return View(model);
        }

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

			return View(_mapper.GetProductModel(product));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Price,Sku,StockQty,Weight,Length,Width,Height")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productLogic.Add(product);
                
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.GetProductModel(product));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) { return NotFound(); }

            var product = _productLogic.GetById((int)id);

            if (product == null) { return NotFound(); }

			var model = new ProductViewModel
			{
				Product = _mapper.GetProductModel(product),
				Tree = _categoryLogic.GetCategoryTree()
			};

            return View(model);
        }

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
            return View(_mapper.GetProductModel(product));
        }

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

            return View(_mapper.GetProductModel(product));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _productLogic.GetById(id);

			_productLogic.Delete(product);
            
            return RedirectToAction(nameof(Index));
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
