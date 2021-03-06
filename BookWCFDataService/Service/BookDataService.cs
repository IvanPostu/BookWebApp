using BookWCFDataService.Datasource;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWCFDataService.Service
{
    public class BookDataService : IBookDataService
    {
        private DataSource _dataSource;

        public BookDataService()
        {
            _dataSource = new DataSource();
        }

        public Result deleteBook(Book book)
        {
            return _dataSource.DeleteBookById(book.Id);
        }

        public List<Book> GetAllBooks()
        {
            var datasource = new DataSource();

            List<Book> result = datasource.SelectBooksWithAutors();

            return result;
        }

        public Result saveBook(Book book)
        {
            return _dataSource.saveBook(book);

        }

        public Result updateBook(Book book)
        {
            Result result =  _dataSource.updateBook(book);

            return result;
        }
    }
}
