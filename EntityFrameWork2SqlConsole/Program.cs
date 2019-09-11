using EntityFrameWork2SqlLibrary1;
using System;
using System.Linq;

namespace EntityFrameWork2SqlConsole {
    class Program {
        static void Main(string[] args) {

            using(var context = new PRSContext()) {   //create instance of new context. add using library

                var Nike = context.Vendors.Find(3); 

                Console.WriteLine($"{Nike.Code} {Nike.Name}"); //.Find is same as get by pk

                var users = context.Users.ToList();      //create collection instance of user data
                

                foreach (var user in users) {
                    Console.WriteLine($"{user.Username} {user.Firstname} {user.Lastname}");
                }
            }
        }   
    }
}
