using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;

namespace BookWebClientRestAPI.Controllers
{
    public class BookController : ApiController
    {
        // GET: api/Book
        public IEnumerable<BookService.Book> Get()
        {
            using (var service = new BookService.BookServiceClient())
            {
                BookService.Book[] books = service.getAllBooks();

                return books;
            }

        }

        // GET: api/Book/5
        public BookService.Book Get(int id)
        {
            using (var service = new BookService.BookServiceClient())
            {
                BookService.Book book = service.buyBook(id);

                return book;
            }
        }

       
    }
}
