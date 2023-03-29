using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using KalFinalProject.Models;

namespace KalFinalProject.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository repo;

        public BookController(IBookRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var books = repo.GetAllBooks();
            return View(books);
        }

        public IActionResult ViewBook(int id)
        {
            var book = repo.GetBook(id);
            return View(book);
        }

        public IActionResult UpdateBook(int id)
        {
            Book prod = repo.GetBook(id);
            if (prod == null)
            {
                return View("BookNotFound");
            }
            return View(prod);
        }

        public IActionResult UpdateBookToDatabase(Book book)
        {
            repo.UpdateBook(book);

            return RedirectToAction("Viewbook", new { id = book.BookID });
        }

        /* public IActionResult InsertBook()
        {
            var bookk = repo.AssignCategory();
            return View(bookk);
        } */
        public IActionResult InsertBookToDatabase(Book bookToInsert)
        {
            repo.InsertBook(bookToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBook(Book book)
        {
            repo.DeleteBook(book);
            return RedirectToAction("Index");
        }
    }
}
