using Limb_Mission_11.Models;
using Limb_Mission_11.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Limb_Mission_11.Controllers
{
    public class HomeController : Controller
    {

        private IBookstoreRepository _repo;


        public HomeController(IBookstoreRepository temp)
        {
            _repo = temp;   
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var Blah = new BooksListViewModel
            {
                Books = _repo.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };



            return View(Blah);
        }

    }
}
