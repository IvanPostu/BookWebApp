using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWCFDataService
{
    public class MyException : Exception
    {
        public MyException(String msg): base(msg)
        {
        }

        public int ErrorCode { get; set; }

    }
}
