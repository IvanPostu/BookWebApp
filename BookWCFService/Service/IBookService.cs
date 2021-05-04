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

        [OperationContract(IsOneWay = false)]
        Result saveBook(Book book);

        [OperationContract(IsOneWay = false)]
        Result updateBook(Book book);

        [OperationContract(IsOneWay = false)]
        Result deleteBook(Book book);

    }
}
