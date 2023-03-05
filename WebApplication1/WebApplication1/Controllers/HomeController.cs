using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var list = await GetListBooks();
            return View(list);
        }
        private async Task<List<Book>> GetListBooks()    // Hàm Gọi API trả về list
        {
            string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
                Request.ApplicationPath.TrimEnd('/') + "/";   // Lấy base uri của website
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage res = await httpClient.GetAsync(baseUrl + "api/Book/GetListBooks");
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<Book> list = new List<Book>();
                    list = res.Content.ReadAsAsync<List<Book>>().Result;
                    return list;
                }
                return null;
            }
        }

        public async Task<ActionResult> Detail(int id)
        {
            var book = await GetBook(id);
            return View(book);
        }
        private async Task<Book> GetBook(int id)   // Hàm Gọi API trả về Book
        {
            string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
                Request.ApplicationPath.TrimEnd('/') + "/";   // Lấy base uri của website
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage res = await httpClient.GetAsync(baseUrl + "api/Book/GetBook/" +id);
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return res.Content.ReadAsAsync<Book>().Result;
                }
                return null;
            }
        }
    }
}


