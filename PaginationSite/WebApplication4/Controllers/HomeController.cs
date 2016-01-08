using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Repository;
using PagedList;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string currentFilter, string sortOrder, string searchString, int? page)
        {
            JB_FoodStoreEntities context = new JB_FoodStoreEntities();

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;


            FoodRespository productRepo = new FoodRespository();
            IEnumerable<Product> products = productRepo.GetProducts(searchString, sortOrder);

            // Store current sort filter parameter.
            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sortOrder;

            // Provide toggle option for name sort.
            if (String.IsNullOrEmpty(sortOrder))
                ViewBag.NameSortParm = FoodRespository.NAME;
            else
                ViewBag.NameSortParm = "";

            // Provide toggle  optionfor date sort.
            if (sortOrder == FoodRespository.MFGDISCOUNT)
                ViewBag.DateSortParm = FoodRespository.MFG_DESC;
            else
                ViewBag.DateSortParm = FoodRespository.MFGDISCOUNT;


            const int PAGE_SIZE = 2;
            int pageNumber = (page ?? 1);
            // Truncate results to fit in the view provided.
            products = products.ToPagedList(pageNumber, PAGE_SIZE);
            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}