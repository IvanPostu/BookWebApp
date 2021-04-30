using BookWCFDataService.Datasource;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSource d = new DataSource();

            String title = "hello";
            String content = "w";
            Int32 authorId = 1;
            Book b = new Book()
            {
                Id = 2,
                Author = new Author()
                {
                    Email = "a@mail.ru",
                    FullName = "RickMorty",
                    Id = 1

                },
                Content = "zzzzz",
                Title = "hello"
            };

            d.DeleteBookById(3);

        }
    }
}
