using KalFinalProject.Models;

namespace KalFinalProject
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAllBooks();
        public Book GetBook(int id);
        public void UpdateBook(Book book);
        public void InsertBook(Book bookToInsert);
        //public Book AssignCategory();
        public void DeleteBook(Book book);
        public IEnumerable<Genre> GetGenres();

        public Book AssignGenre();


    }
}
