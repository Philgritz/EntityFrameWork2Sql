using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameWork2SqlLibrary1;
using System.Linq;

namespace EntityFrameWork2SqlLibrary1 {
    class RequestLineRepository {

        private static PRSContext context = new PRSContext();

        public static List<RequestLine> GetAll() {
            return context.RequestLine.ToList();
        }
        public static RequestLine GetByPk(int id) {
            return context.RequestLine.Find(id);
        }
        public static bool Insert(RequestLine requestline) {
            if (requestline == null) { throw new Exception("Requestline instance can't be null"); }
            requestline.Id = 0;
            context.RequestLine.Add(requestline);
            return context.SaveChanges() == 1;  //verify 1 row affected            
        }
        public static bool Update(RequestLine requestline) {
            if (requestline == null) { throw new Exception("Requestline instance can't be null"); }
            var dbrequestline = context.RequestLine.Find(requestline.Id);  //read db for requestline id, make sure it exists in db
            if (dbrequestline == null) { throw new Exception("No requestline with that id"); }
            dbrequestline.RequestId = requestline.RequestId;
            dbrequestline.ProductId = requestline.ProductId;
            dbrequestline.Quantity = requestline.Quantity;
          

            return context.SaveChanges() == 1;

        }
        public static bool Delete(RequestLine requestline) {
            if (requestline == null) { throw new Exception("Requestline instance can't be null"); }
            var dbrequestline = context.RequestLine.Find(requestline.Id);  //read db for requestline id, make sure it exists in db
            if (dbrequestline == null) { throw new Exception("No requestline with that id"); }
            context.RequestLine.Remove(dbrequestline);
            return context.SaveChanges() == 1;
        }
        public static bool Delete(int id) {
            var requestline = context.RequestLine.Find(id);
            if (requestline == null) { return false; }
            var rc = Delete(requestline);  //use other delete method
            return rc;
        }
    }
}
