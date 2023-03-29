using Dapper;
using System.Collections.Generic;
using KalFinalProject.Models;
using System.Data;

namespace KalFinalProject
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbConnection _conn;
        public BookRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _conn.Query<Book>("Select * From books");

        }

        public Book GetBook(int id)
        {
            return _conn.QuerySingle<Book>("SELECT * FROM BOOKS WHERE BOOKID = @id", new { id = id });
        }

        public void UpdateBook(Book book)
        {
            _conn.Execute("UPDATE books SET Title = @title, Author = @author WHERE BookID = @id",
             new { title = book.Title, author = book.Author, id = book.BookID });
        }

        public void InsertBook(Book bookToInsert)
        {
            _conn.Execute("INSERT INTO books (TITLE, AUTHOR) VALUES (@title, @author)",
                new { title = bookToInsert.Title, author = bookToInsert.Author });
        }

        /* public Book AssignCategory()
        {
            var myBookList = GetBookCategories();
            var book = new Book();
            book.Categories = myBookList;
            
            return book;
        } */

        public void DeleteBook(Book book)
        {
            _conn.Execute("DELETE FROM Books WHERE BookID = @id;", new { id = book.BookID });
            
        }


    }

}
