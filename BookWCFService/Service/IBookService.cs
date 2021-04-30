using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BookWCFBusinessService.Service
{
    [ServiceContract]
    public interface  IBookService
    {


        [OperationContract]
        List<Book> GetAllBooks();

        [OperationContract(IsOneWay = true)]
        void saveBook(Book book);

        [OperationContract(IsOneWay = true)]
        void updateBook(Book book);

        [OperationContract(IsOneWay = true)]
        void deleteBook(Book book);

    }
}
