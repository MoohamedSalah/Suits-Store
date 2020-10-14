using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suites.Entities;
using Suites.DataBase;
using System.Data.Entity;

namespace Suites.Serveres
{
 
    public class ProdectServes
    {
        public List<Prodect> Getprodects ()
        {
         
            using (var db = new SuitDBContext()) 
            {
                return db.prodects.Include(c=>c.Category).ToList();
            
            }

        }
        public List<Prodect> GetProducts(List<int> IDs)
        {
            using (var db = new SuitDBContext())
            {
                return db.prodects.Where(product => IDs.Contains(product.ID)).ToList();
            }
        }

        public List<Prodect> GetLatestProducts(int numberOfProducts)
        {
            using (var context = new SuitDBContext())
            {
                return context.prodects.OrderByDescending(x => x.ID).Take(numberOfProducts).Include(x => x.Category).ToList();
            }
        }


        public List<Prodect> GetProductsByCategory(int categoryID, int pageSize)
        {
            using (var context = new SuitDBContext())
            {
                return context.prodects.Where(x => x.Category.ID == categoryID).OrderByDescending(x => x.ID).Take(pageSize).Include(x => x.Category).ToList();
            }
        }

        public int GetMaximumPrice()
        {
            using (var context = new SuitDBContext())
            {
                int y = (int)(context.prodects.Max(x => x.prise));
                return y;
            }
        }


        public List<Prodect> SearchProducts(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int pageNo, int pageSize)
        {
            using (var context = new SuitDBContext())
            {
                var products = context.prodects.ToList();

                if (categoryID.HasValue)
                {
                    products = products.Where(x => x.categoryID == categoryID).ToList();
                }

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                }

                if (minimumPrice.HasValue)
                {
                    products = products.Where(x => x.prise  >= minimumPrice.Value).ToList();
                }

                if (maximumPrice.HasValue)
                {
                    products = products.Where(x => x.prise <= maximumPrice.Value).ToList();
                }

                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 2:
                            products = products.OrderByDescending(x => x.ID).ToList();
                            break;
                        case 3:
                            products = products.OrderBy(x => x.prise).ToList();
                            break;
                        default:
                            products = products.OrderByDescending(x => x.prise).ToList();
                            break;
                    }
                }

                return products.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public int SearchProductsCount(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy)
        {
            using (var context = new SuitDBContext())
            {
                var products = context.prodects.ToList();

                if (categoryID.HasValue)
                {
                    products = products.Where(x => x.categoryID  == categoryID).ToList();
                }

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                }

                if (minimumPrice.HasValue)
                {
                    products = products.Where(x => x.prise >= minimumPrice.Value).ToList();
                }

                if (maximumPrice.HasValue)
                {
                    products = products.Where(x => x.prise <= maximumPrice.Value).ToList();
                }

                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 2:
                            products = products.OrderByDescending(x => x.ID).ToList();
                            break;
                        case 3:
                            products = products.OrderBy(x => x.prise).ToList();
                            break;
                        default:
                            products = products.OrderByDescending(x => x.prise).ToList();
                            break;
                    }
                }

                return products.Count;
            }
        }

        public List<Prodect> GetProducts(int pageNo, int pageSize)
        {
            using (var context = new SuitDBContext())
            {
                return context.prodects.OrderByDescending(x => x.ID).Skip((pageNo - 1) * pageSize).Take(pageSize).Include(x => x.Category).ToList();
            }
        }

        public void Saveprodects(Prodect Prodect )
        {
            using (var db = new SuitDBContext())
            {
                db.prodects.Add(Prodect);
                db.SaveChanges();

            }
        }

        public Prodect Getoneprodect(int? ID)
        {
            using (var db = new SuitDBContext())
            {
                return db.prodects.Where(x=>x.ID ==ID).Include(x=>x.Category).SingleOrDefault();

            }

        }
        public void Updateprodects(Prodect Prodect)
        {
            using (var db = new SuitDBContext())
            {
                db.Entry(Prodect).State = EntityState.Modified;
                db.SaveChanges();

            }
        }
        public void  Deleteprodects(int ID)
        {
            using (var db = new SuitDBContext())
            {
                Prodect Prodect1 = db.prodects.Find(ID);
                db.prodects.Remove(Prodect1);
                db.SaveChanges();

            }

        }

    }
}
