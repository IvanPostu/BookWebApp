using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWCFBusinessService.Service
{
    public class BookService : IBookService
    {
        public void deleteBook(Book book)
        {
            using (var service = new BookWCFService.BookDataService.BookDataServiceClient())
            {
                service.deleteBook(book);
            }
        }

        public List<Book> GetAllBooks()
        {
            using (var service = new BookWCFService.BookDataService.BookDataServiceClient())
            {
                var books = service.GetAllBooks();
                return books.ToList();
            }
        }

        public void saveBook(Book book)
        {
            using (var service = new BookWCFService.BookDataService.BookDataServiceClient())
            {
                service.saveBook(book);
            }
        }

        public Result updateBook(Book book)
        {
            Result result;

            using (var service = new BookWCFService.BookDataService.BookDataServiceClient())
            {
                result = service.updateBook(book);
            }

            return result;
        }
    }
}
