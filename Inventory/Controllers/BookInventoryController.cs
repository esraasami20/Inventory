using Inventory.Models;
using Inventory.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class BookInventoryController : Controller
    {
        // GET: Book
        //Private instance of BookInventory collection
        private BookInventoryCollection _bookInventoryCollection = new BookInventoryCollection();
        //
        // GET: /book/

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookInventory book)
        {
            this._bookInventoryCollection.InsertBookInventory(book);
            return RedirectToAction("List", _bookInventoryCollection.SelectAll());
        }

        public ActionResult List()
        {

            return View(
                _bookInventoryCollection.SelectAll());
        }
        public ActionResult Details(string bookInventoryId)
        {
            return View(this._bookInventoryCollection.Get(bookInventoryId));
        }
        public ActionResult Edit(string bookInventoryId)
        {
            return View(_bookInventoryCollection.Get(bookInventoryId));
        }

        [HttpPost]
        public ActionResult Edit(string bookInventoryId, BookInventory book)
        {
            this._bookInventoryCollection.UpdateBookInventory(bookInventoryId, book);

            return RedirectToAction("List",
                 _bookInventoryCollection.SelectAll());
        }
        public ActionResult Delete(string bookInventoryId)
        {
            return View(_bookInventoryCollection.Get(bookInventoryId));
        }

        [HttpPost]
        public ActionResult Delete(string bookInventoryId, BookInventory book)
        {
            this._bookInventoryCollection.DeleteBookInventory(bookInventoryId, book);

            return RedirectToAction("List",
                 _bookInventoryCollection.SelectAll());
        }



    }
}