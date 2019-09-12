using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameWork2SqlLibrary1;
using System.Linq;

namespace EntityFrameWork2SqlLibrary1 {
    class RequestRepository {

        private static PRSContext context = new PRSContext();

        public static List<Request> GetAll() {
            return context.Request.ToList();
        }
        public static Request GetByPk(int id) {
            return context.Request.Find(id);
        }
        public static bool Insert(Request request) {
            if (request == null) { throw new Exception("Request instance can't be null"); }
            request.Id = 0;
            context.Request.Add(request);
            return context.SaveChanges() == 1;  //verify 1 row affected            
        }
        public static bool Update(Request request) {
            if (request == null) { throw new Exception("Request instance can't be null"); }
            var dbrequest = context.Request.Find(request.Id);  //read db for request id, make sure it exists in db
            if (dbrequest == null) { throw new Exception("No request with that id"); }
            dbrequest.Description = request.Description;
            dbrequest.Justification = request.Justification;
            dbrequest.ReasonRejection = request.ReasonRejection;
            dbrequest.DeliveryMode = request.DeliveryMode;
            dbrequest.Status = request.Status;
            dbrequest.Total = request.Total;
            dbrequest.UserId = request.UserId;
          

            return context.SaveChanges() == 1;

        }
        public static bool Delete(Request request) {
            if (request == null) { throw new Exception("Request instance can't be null"); }
            var dbrequest = context.Request.Find(request.Id);  //read db for request id, make sure it exists in db
            if (dbrequest == null) { throw new Exception("No request with that id"); }
            context.Request.Remove(dbrequest);
            return context.SaveChanges() == 1;
        }
        public static bool Delete(int id) {
            var request = context.Request.Find(id);
            if (request == null) { return false; }
            var rc = Delete(request);  //use other delete method
            return rc;
        }
    }
}
