using EntityFrameWork2SqlLibrary1;
using System;
using System.Linq;

namespace EntityFrameWork2SqlConsole {
    class Program {
        static void Main(string[] args) {

            using(var context = new PRSContext()) {   //create instance of new context. add using library

                //var request = new Request() {
                //    Id = 0,
                //    Description = "Another New Request",
                //    Justification = "I dont need one",
                //    ReasonRejection = null,
                //    DeliveryMode = "Pickup",
                //    Status = "NEW",
                //    Total = 0,
                //    UserId = context.Users.SingleOrDefault(u => u.Username.Equals("Jeff")).Id //brings back a whole user insance. only want Id
                //};
                //context.Request.Add(request);  //adds to collection but not to db

                //var reqs = (from r in context.Request
                //            select r).ToList();
                //reqs.ForEach(r => {
                //    r.Total = r.RequestLine.Sum(1 => 1.Product.Price * 1.Quantity);
                //    ToConsole(r);
                //});
                //context.SaveChanges();

                //var total = context.Request.Sum(r => r.Total);
                //Console.WriteLine($"Total of all requests is {total}");



                var req3 = context.Request.Find(3);
                //req3.Total = req3.RequestLine.Sum(1 => 1.Product.Price * 1.Quantity);  //keeps request total up to date
                context.SaveChanges();
                Console.WriteLine($"{req3.Description} {req3.Status} {req3.Total.ToString("C")}");
                req3.RequestLine.ToList().ForEach(r1 => {
                    Console.WriteLine($"{r1.Product.Name,-10} {r1.Quantity,5} " +
                        $"{r1.Product.Price.ToString("C"),10}" +
                        $"{(r1.Product.Price * r1.Quantity).ToString("C"),11}");
                });


                //var request = new Request() { Id = 4, Description = "Another Changed Description" };  //read record to change
                //var dbRequest = context.Request.Find(request.Id);
                //dbRequest.Description = request.Description;

                //dbRequest = context.Request.Find(4);
                //context.Request.Remove(dbRequest);
                //context.SaveChanges();  //adds changes to the db

                //var Nike = context.Vendors.Find(3); //.Find is same as get by pk

                //Console.WriteLine($"{Nike.Code} {Nike.Name}");

                ////var users = context.Users.ToList();      //create collection instance of user data
                //var users = from u in context.Users.ToList()
                //            where u.Username.Contains("1") || u.Username.Contains("J")
                //            select u;


                //foreach (var user in users) {
                //    Console.WriteLine($"{user.Username} {user.Firstname} {user.Lastname}");
                //}
            }
        }   
    }
}
