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
        //private static Book[] BOOKS = {
        //    new Book(){ Content="Content1", Title="hello1", Id=1, 
        //        Author=new Author() {
        //            Email="q1@mail.ru",
        //            FullName="Martin A",
        //            Id=2
        //        }, },
        //    new Book(){ Content="Content2", Title="hello2", Id=2, 
        //        Author=new Author() {
        //            Email="q2@mail.ru",
        //            FullName="Martin B",
        //            Id=2
        //        }, },
        //    new Book(){ Content="Content3", Title="hello3", Id=3, 
        //        Author=new Author() {
        //            Email="q3@mail.ru",
        //            FullName="Martin C",
        //            Id=2
        //        }, },
        //    new Book(){ Content="Content4", Title="hello4", Id=4, 
        //        Author=new Author() {
        //            Email="q4@mail.ru",
        //            FullName="Martin D",
        //            Id=2
        //        }, },
        //    new Book(){ Content="Content5", Title="hello5", Id=5, 
        //        Author=new Author() {
        //            Email="q5@mail.ru",
        //            FullName="Martin E",
        //            Id=2
        //        }, },
        //    new Book(){ Content="Content6", Title="hello6", Id=6, 
        //        Author=new Author() {
        //            Email="q6@mail.ru",
        //            FullName="Martin F",
        //            Id=2
        //        }, },
        //    new Book(){ Content="Content7", Title="hello7", Id=7, 
        //        Author=new Author() {
        //            Email="q7@mail.ru",
        //            FullName="Martin G",
        //            Id=2
        //        }, },
        //};

        public List<Book> GetAllBooks()
        {
            var datasource = new DataSource();

            List<Book> result = datasource.SelectBooksWithAutors();

            return result;
        }

        public Book GetBookById(int id)
        {
            return null;// BOOKS.FirstOrDefault((b) => b.Id == id);
        }
    }
}
