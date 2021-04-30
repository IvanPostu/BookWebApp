using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookWebClient.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public JsonResult GetBooks(int offset, int limit)
        {

            using (var _client = new BookService.BookServiceClient())
            {
                var books = _client.getAllBooks();

                return Json(new { books = books }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetBookInfo(int bookId)
        {
            using (var _client = new BookService.BookServiceClient())
            {
                var book = _client.buyBook(bookId);

                return Json(new { book = book }, JsonRequestBehavior.AllowGet);
            }
        }
    }

}