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
 
    public class CatagorySereves
    {
        public List<Category> GetCategories ()
        {
            using (var db = new SuitDBContext()) 
            {
                return db.categories.ToList();
                
            }

        }

        public List<Category> GetCategoriesFeature()
        {
            using (var db = new SuitDBContext())
            {
                return db.categories.Where(c=>c.ISFeatcher==true&&c.ImageURL!=null).ToList();

            }

        }

        public void SaveCategories(Category category )
        {
            using (var db = new SuitDBContext())
            {
                db.categories.Add(category);
                db.SaveChanges();

            }
        }

        public Category GetoneCategories(int? ID)
        {
            using (var db = new SuitDBContext())
            {
                return db.categories.Find(ID);

            }

        }
        public void UpdateCategories(Category category)
        {
            using (var db = new SuitDBContext())
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();

            }
        }

        public void  DeleteCategories(int ID)
        {
            using (var db = new SuitDBContext())
            {
                Category category1 = db.categories.Find(ID);
                db.categories.Remove(category1);
                db.SaveChanges();

            }

        }

        public List<Category> GetFeaturedCategories()
        {
            using (var context = new SuitDBContext())
            {
                return context.categories.Where(x => x.ISFeatcher  && x.ImageURL != null).ToList();
            }
        }
    }
}
