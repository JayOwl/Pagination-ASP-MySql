using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Repository
{
    public class FoodRespository
    {
        public const string PRODUCT_ID = "Productid";
        public const string NAME = "Name";
        public const string MANUNAME = "ManuName";
        public const string MFG = "Mfg";
        public const string VENDOR = "Vender";
        public const string PRICE = "Price";
        public const string MFGDISCOUNT = "Mfgdiscount";
        public const string DATE_DESC = "Date_desc";

        IEnumerable<Product> SortStudents(IEnumerable<Product> products, string sortOrder)
        {
            switch (sortOrder)
            {
                case NAME:
                    products = products.OrderByDescending(s => s.name);
                    break;
                case MANUNAME:
                    products = products.OrderBy(s => s.Manufacturer);
                    break;
                case MFGDISCOUNT:
                    products = products.OrderByDescending(s => s.Manufacturer.mfgDiscount);
                    break;
                case PRICE:
                    products = products.OrderByDescending(s => s.price);
                    break;
                case VENDOR:
                    products = products.OrderByDescending(s => s.vendor);
                    break;
                default:
                    products = products.OrderByDescending(s => s.productID);
                    break;
            }
            return products;
        }

        IEnumerable<Product> FilterProducts(IEnumerable<Product> products, string searchString)
        {
            // Filter results based on search.
            if (!String.IsNullOrEmpty(searchString))
                products = products.Where(
                            s => s.name.ToUpper().Contains(searchString.ToUpper())
                              || s.mfg.ToUpper().Contains(searchString.ToUpper()));
            return products;
        }

        public IEnumerable<Product> GetProducts(string searchString, string sortOrder)
        {
            JB_FoodStoreEntities context = new JB_FoodStoreEntities();
            IEnumerable<Product> products = from s in context.Products
                                            select s;

            products = FilterProducts(products, searchString);
            products = SortProducts(products, sortOrder);

            return products;
        }
        public const string MFG_DESC = "Mfg_desc";

        IEnumerable<Product> SortProducts(IEnumerable<Product> products, string sortOrder)
        {
            switch (sortOrder)
            {
                case NAME:
                    products = products.OrderByDescending(s => s.name);
                    break;
                case MANUNAME:
                    products = products.OrderBy(s => s.Manufacturer);
                    break;
                case MFGDISCOUNT:
                    products = products.OrderByDescending(s => s.Manufacturer.mfgDiscount);
                    break;
                case PRICE:
                    products = products.OrderByDescending(s => s.price);
                    break;
                case VENDOR:
                    products = products.OrderByDescending(s => s.vendor);
                    break;
                default:
                    products = products.OrderByDescending(s => s.productID);
                    break;
            }
            return products;
        }

        IEnumerable<Product> FilterStudents(IEnumerable<Product> products, string searchString)
        {
            // Filter results based on search.
            if (!String.IsNullOrEmpty(searchString))
                products = products.Where(
                            s => s.name.ToUpper().Contains(searchString.ToUpper())
                              || s.mfg.ToUpper().Contains(searchString.ToUpper()));
            return products;
        }

        public IEnumerable<Product> GetStudents(string searchString, string sortOrder)
        {
            JB_FoodStoreEntities context = new JB_FoodStoreEntities();
            IEnumerable<Product> products = from s in context.Products
                                            select s;

            products = FilterStudents(products, searchString);
            products = SortStudents(products, sortOrder);

            return products;
        }
    }
}