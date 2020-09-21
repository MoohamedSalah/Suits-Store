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

        public void Saveprodects(Prodect Prodect )
        {
            using (var db = new SuitDBContext())
            {
                db.prodects.Add(Prodect);
                db.SaveChanges();

            }
        }

        public Prodect Getoneprodects(int? ID)
        {
            using (var db = new SuitDBContext())
            {
                return db.prodects.Find(ID);

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
