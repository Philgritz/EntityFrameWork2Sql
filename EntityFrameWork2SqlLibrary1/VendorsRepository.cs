using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameWork2SqlLibrary1;
using System.Linq;

namespace EntityFrameWork2SqlLibrary1 {
    class VendorsRepository {

        private static PRSContext context = new PRSContext();

        public static List<Vendors> GetAll() {
            return context.Vendors.ToList();
        }
        public static Vendors GetByPk(int id) {
            return context.Vendors.Find(id);
        }
        public static bool Insert(Vendors vendor) {
            if (vendor == null) { throw new Exception("Vendor instance can't be null"); }
            vendor.Id = 0;
            context.Vendors.Add(vendor);
            return context.SaveChanges() == 1;  //verify 1 row affected            
        }
        public static bool Update(Vendors vendor) {
            if (vendor == null) { throw new Exception("Vendor instance can't be null"); }
            var dbvendor = context.Vendors.Find(vendor.Id);  //read db for vendor id, make sure it exists in db
            if (dbvendor == null) { throw new Exception("No vendor with that id"); }
            dbvendor.Code = vendor.Code;
            dbvendor.Name = vendor.Name;
            dbvendor.Address = vendor.Address;
            dbvendor.City = vendor.City;
            dbvendor.State = vendor.State;
            dbvendor.Zip = vendor.Zip;
            dbvendor.Phone = vendor.Phone;
            dbvendor.Email = vendor.Email;

            return context.SaveChanges() == 1;

        }
        public static bool Delete(Vendors vendor) {
            if (vendor == null) { throw new Exception("Vendor instance can't be null"); }
            var dbvendor = context.Vendors.Find(vendor.Id);  //read db for vendor id, make sure it exists in db
            if (dbvendor == null) { throw new Exception("No vendor with that id"); }
            context.Vendors.Remove(dbvendor);
            return context.SaveChanges() == 1;
        }
        public static bool Delete(int id) {
            var vendor = context.Vendors.Find(id);
            if (vendor == null) { return false; }
            var rc = Delete(vendor);  //use other delete method
            return rc;
        }
    }
}
