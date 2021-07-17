using Inventory.Models;
using Inventory.Models.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        //Private instance of book collection
        private BookCollection _bookCollection = new BookCollection();
        private BookInventoryCollection _bookInventory = new BookInventoryCollection();
        private MongodbRepo  _db= new MongodbRepo("mongodb://127.0.0.1:27017", "QueryMongoDb");

        public ActionResult Create()
        {
            var _collection = _db.Db.GetCollection<BookInventory>("BookInventoryCollection");
            var _id = _collection.AsQueryable()/*.Select(a => a._id)*/.ToList();
            ViewBag.BookInventoryId = new SelectList(_id, "_id", "InventoryName");
            return View();
        }


        [HttpPost]
        public ActionResult Create(Book book)
        {
            this._bookCollection.InsertBook(book);
            return RedirectToAction("List", _bookCollection.SelectAll());
        }


        public ActionResult List()
        {
            return View(
                _bookCollection.SelectAll());
        }


        public ActionResult Details(string bookId)
        {
            return View(this._bookCollection.Get(bookId));
        }

        public ActionResult Edit(string bookId)
        {

            var _collection = _db.Db.GetCollection<BookInventory>("BookInventoryCollection");
            var _id = _collection.AsQueryable().ToList();
            ViewBag.BookInventoryId = new SelectList(_id, "_id", "InventoryName");
            return View(_bookCollection.Get(bookId));
        }


        [HttpPost]
        public ActionResult Edit(string bookId, Book book)
        {
            this._bookCollection.UpdateBook(bookId, book);

            return RedirectToAction("List",
                 _bookCollection.SelectAll());
        }

        public ActionResult Delete(string bookId)
        {
            return View(_bookCollection.Get(bookId));
        }


        [HttpPost]
        public ActionResult Delete(string bookId, Book book)
        {
            this._bookCollection.DeleteBook(bookId, book);

            return RedirectToAction("List",
                 _bookCollection.SelectAll());
        }
    }
}