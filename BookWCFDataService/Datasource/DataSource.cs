using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWCFDataService.Datasource
{
    public class DataSource
    {
        private readonly string CONNECTION_STRING;

        public DataSource()
        {
            CONNECTION_STRING = "Data Source=DESKTOP-B1TKCSB;Initial Catalog=books_demo;User Id=sa;Password=qwerty$1;Connection Timeout=15";
        }

        public List<Book> SelectBooksWithAutors()
        {
            List<Book> result = new List<Book>();


            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetBooks", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@with_autors", 1));

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Book b = new Book();
                        Author a = new Author();

                        a.FullName = (String)rdr["fullname"];
                        b.Author = a;
                        b.Content = (String)rdr["content"];
                        b.Title = (String)rdr["title"];
                        b.Id = (int)rdr["book_id"];

                        result.Add(b);
                    }
                }
            }

            return result;
        }


    

}
}
