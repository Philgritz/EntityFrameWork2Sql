using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameWork2SqlLibrary1;
using System.Linq;

namespace EntityFrameWork2SqlLibrary1 {
    class ProductsRepository {

        private static PRSContext context = new PRSContext();

        public static List<Products> GetAll() {
            return context.Products.ToList();
        }
        public static Products GetByPk(int id) {
            return context.Products.Find(id);
        }
        public static bool Insert(Products product) {
            if (product == null) { throw new Exception("Product instance can't be null"); }
            product.Id = 0;
            context.Products.Add(product);
            return context.SaveChanges() == 1;  //verify 1 row affected            
        }
        public static bool Update(Products product) {
            if (product == null) { throw new Exception("Product instance can't be null"); }
            var dbproduct = context.Products.Find(product.Id);  //read db for product id, make sure it exists in db
            if (dbproduct == null) { throw new Exception("No product with that id"); }
            dbproduct.PartNbr = product.PartNbr;
            dbproduct.Name = product.Name;
            dbproduct.Price = product.Price;
            dbproduct.Unit = product.Unit;
            dbproduct.PhotoPath = product.PhotoPath;
            dbproduct.VendorId = product.VendorId;
          

            return context.SaveChanges() == 1;

        }
        public static bool Delete(Products product) {
            if (product == null) { throw new Exception("Product instance can't be null"); }
            var dbproduct = context.Products.Find(product.Id);  //read db for product id, make sure it exists in db
            if (dbproduct == null) { throw new Exception("No product with that id"); }
            context.Products.Remove(dbproduct);
            return context.SaveChanges() == 1;
        }
        public static bool Delete(int id) {
            var product = context.Products.Find(id);
            if (product == null) { return false; }
            var rc = Delete(product);  //use other delete method
            return rc;
        }
    }
}
