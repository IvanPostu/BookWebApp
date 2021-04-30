using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookWebClient
{
    public class BookDto
    {
        public String Title { get; set; }
        public String Content { get; set; }
        public int Id { get; set; }
        public int AuthorId { get; set; }

    };
}