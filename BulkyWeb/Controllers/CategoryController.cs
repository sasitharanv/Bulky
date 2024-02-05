using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
	public class CategoryController : Controller
	{
		public readonly ICategoryRepository _categoryRepo ;

		public CategoryController(ICategoryRepository db)
		{
			_categoryRepo = db;
		}
		public IActionResult Index()
		{
			List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
			return View(objCategoryList);
		}
		public IActionResult Create() {
			return View();
		}

		[HttpPost]
		public IActionResult Create(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString()) {
				ModelState.AddModelError("name", "The Display Order Cannot Exactly Match The Name");
			}

			if (ModelState.IsValid)
			{
				_categoryRepo.Add(obj);
				_categoryRepo.save();
				TempData["success"] = "Category Created Successfully";
				return RedirectToAction("Index"); 
			}
			return View();
		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category categoryFromdb = _categoryRepo.Get(u=>u.Id==id);
			if (categoryFromdb == null)
			{
				return NotFound();

			}

			return View(categoryFromdb);
		}
		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "The Display Order Cannot Exactly Match The Name");
			}

			if (ModelState.IsValid)
			{
				_categoryRepo.Update(obj);
				_categoryRepo.save();
				TempData["success"] = "Category Updated Successfully";

				return RedirectToAction("Index");
			}
			return View();
		}

		/*	public IActionResult Delete(int id) // Corrected the parameter to use an ID for deletion /// delete on that same page
			{
				Category categoryToDelete = _db.Categories.Find(id);
				if (categoryToDelete == null)
				{
					return NotFound();
				}

				_db.Categories.Remove(categoryToDelete);
				_db.SaveChanges();

				return RedirectToAction("Index"); // Redirect to the Index action after deleting
			}*/
		public IActionResult Delete(int? id) {

			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);

			if (categoryFromDb == null)
			{
				return NotFound();
			}

			return View(categoryFromDb);
		}

		[HttpPost,ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category? obj = _categoryRepo.Get(u => u.Id == id);
			if (obj == null)
			{
				return NotFound();
			}
			_categoryRepo.Remove(obj);
			_categoryRepo.save();

			TempData["success"] = "Category Deleted Successfully";


			return RedirectToAction("Index");
		}
					

	
	}
}
