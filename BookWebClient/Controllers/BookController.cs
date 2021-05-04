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
                var books = _client.GetAllBooks();

                return Json(new { books = books }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult Delete(int Id)
        {

            using (var _client = new BookService.BookServiceClient())
            {
                _client.deleteBook(new Models.Book() { Id = Id });

                return Json(new { }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult Save(int? Id, String Title, String Content, int AuthorId)
        {
            

            using (var _client = new BookService.BookServiceClient())
            {
                Models.Result result;

                if(Id == null)
                {
                    result = _client.saveBook(new Models.Book() { Author = new Models.Author() { Id = AuthorId }, Title = Title, Content = Content });
                }
                else
                {
                    result = _client.updateBook(new Models.Book() { Author = new Models.Author() { Id = AuthorId }, Title = Title, Content = Content, Id= Id ?? 0 });
                }

                return Json(new { result = result }, JsonRequestBehavior.AllowGet);
            }
        }
    }

}