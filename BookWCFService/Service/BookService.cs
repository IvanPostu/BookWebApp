﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BookWCFBusinessService.Service
{
    public class BookService : IBookService
    {


        public Book buyBook(int id)
        {
            //Book b = new Book() {
            //    Author=new Author() { 
            //        Email="qq@mail.ru",
            //        FullName="qq",
            //        Id=2
            //    },
            //    Content="adfda",
            //    Id=2,
            //    Title="adf"
            //};

            //return b;

            using (var service = new BookWCFService.BookDataService.BookDataServiceClient())
            {
                var result = service.GetBookById(id);

                return result;
            }
        }

        public List<Book> getAllBooks()
        {
            using (var service = new BookWCFService.BookDataService.BookDataServiceClient())
            {
                var result = service.GetAllBooks();

                return result.ToList();
            }
        }
    }
}
