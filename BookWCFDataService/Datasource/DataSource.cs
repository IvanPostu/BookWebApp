﻿using Models;
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

        public Boolean saveBook(Book book)
        {
            int insertedId = -1;

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("AddBook", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@title", book.Title));
                cmd.Parameters.Add(new SqlParameter("@content", book.Content));
                cmd.Parameters.Add(new SqlParameter("@author_id", book.Author.Id));
                cmd.Parameters.Add(new SqlParameter("@inserted_id", SqlDbType.Int));
                cmd.Parameters["@inserted_id"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                insertedId = (Int32)cmd.Parameters["@inserted_id"].Value;
            }


            return insertedId != -1;
        }

        public Boolean updateBook(Book book)
        {
            int rowsCount = -1;

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UpdateBook", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add(new SqlParameter("@book_id", book.Id));
                cmd.Parameters.Add(new SqlParameter("@title", book.Title));
                cmd.Parameters.Add(new SqlParameter("@content", book.Content));
                cmd.Parameters.Add(new SqlParameter("@author_id", book.Author.Id));

                rowsCount = cmd.ExecuteNonQuery();
            }

            return rowsCount == 1;
        }

        public Boolean DeleteBookById(Int32 id)
        {
            int rowsCount = -1;

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DeleteBookById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@book_id", id));

                rowsCount = cmd.ExecuteNonQuery();
            }

            return true;
        }

    }
}
