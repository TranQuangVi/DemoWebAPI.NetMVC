using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1.API
{
    public class BookController : ApiController
    {

        private List<Book> ListBooks()
        {
            List<Book> list = new List<Book>();
            for (int i = 1; i < 6; i++)   // Tạo ra 6 User
            {
                Book book = new Book();
                book.Id = i;
                book.Title = "Sách " + i;
                book.Author = "Tác giả " + i;
                book.Year = 2022;
                book.Price = 100000;
                book.Cover = "Images/book" + i + ".jpg";
                list.Add(book);
            }
            return list;
        }

        // lấy tất cả sách
        [HttpGet] 
        public List<Book> GetListBooks()
        {
            return ListBooks();
        }

       [HttpGet]
        public Book GetBook(int id)
        {
            return ListBooks().Where(b => b.Id==id).FirstOrDefault();
        }

 
        [HttpPost]// POST api/values   thêm mới
        public HttpResponseMessage CreateNew(Book book)
        {
            try
            {
                var list = ListBooks();
                list.Add(book);   
                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // Put: Edit thông tin sách
        [HttpPut]
        public HttpResponseMessage UpdateBook(Book book)
        {
            try
            {
                var list = ListBooks();
                int index = list.FindIndex(p => p.Id == book.Id);
                list[index] = book;   
                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE: Xóa sách
        [HttpDelete]
        public HttpResponseMessage DeleteBook(Book book)
        {
            try
            {
                var list = ListBooks();
                int index = list.FindIndex(p => p.Id == book.Id);
                list.RemoveAt(index);
                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
