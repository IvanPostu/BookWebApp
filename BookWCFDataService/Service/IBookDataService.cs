using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BookWCFDataService.Service
{
    [ServiceContract]
    public interface IBookDataService
    {
        [OperationContract]
        Book GetBookById(int id);

        [OperationContract]
        List<Book> GetAllBooks();

    }
}
