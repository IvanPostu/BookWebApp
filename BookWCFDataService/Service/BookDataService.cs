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
        private static Book[] BOOKS = {
            new Book(){ Content="Content1", Title="hello1", Id=1 },
            new Book(){ Content="Content2", Title="hello2", Id=2 },
            new Book(){ Content="Content3", Title="hello3", Id=3 },
            new Book(){ Content="Content4", Title="hello4", Id=4 },
            new Book(){ Content="Content5", Title="hello5", Id=5 },
            new Book(){ Content="Content6", Title="hello6", Id=6 },
            new Book(){ Content="Content7", Title="hello7", Id=7 },
            new Book(){ Content="Content8", Title="hello8", Id=8 },
            new Book(){ Content="Content9", Title="hello9", Id=9 },
            new Book(){ Content="Content10", Title="hello10", Id=10 },
        };

        public List<Book> GetAllBooks()
        {
            List<Book> result = new List<Book>(BOOKS.Length);
            result.AddRange(BOOKS);

            return result;
        }

        public Book GetBookById(int id)
        {
            return BOOKS.FirstOrDefault((b) => b.Id == id);
        }
    }
}
