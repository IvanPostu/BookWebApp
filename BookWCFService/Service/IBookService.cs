using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BookWCFService.Service
{
    [ServiceContract]
    public interface  IBookService
    {

        [OperationContract]
        Book buyBook(int id);

        [OperationContract]
        List<Book> getAllBooks();


    }
}
