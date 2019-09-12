using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameWork2SqlLibrary1;
using System.Linq;

namespace EntityFrameWork2SqlLibrary1 {
    class UsersRepository {

        private static PRSContext context = new PRSContext();

        public static List<Users> GetAll() {
            return context.Users.ToList();
        }
        public static Users GetByPk(int id) {           
            return context.Users.Find(id);
        }
        public static bool Insert(Users user) {
            if(user == null) { throw new Exception("User instance can't be null"); }
            user.Id = 0;
            context.Users.Add(user);
            return context.SaveChanges() == 1;  //verify 1 row affected            
        }
        public static bool Update(Users user) {  
            if (user == null) { throw new Exception("User instance can't be null"); }
            var dbuser = context.Users.Find(user.Id);  //read db for user id, make sure it exists in db
            if(dbuser == null) { throw new Exception("No user with that id"); }
            dbuser.Username = user.Username;
            dbuser.Password = user.Password;
            dbuser.Firstname = user.Firstname;
            dbuser.Lastname = user.Lastname;
            dbuser.Phone = user.Phone;
            dbuser.Email = user.Email;
            dbuser.IsReviewer = user.IsReviewer;
            dbuser.IsAdmin = user.IsAdmin;

            return context.SaveChanges() == 1;

        }
        public static bool Delete(Users user) {
            if (user == null) { throw new Exception("User instance can't be null"); }
            var dbuser = context.Users.Find(user.Id);  //read db for user id, make sure it exists in db
            if (dbuser == null) { throw new Exception("No user with that id"); }
            context.Users.Remove(dbuser);
            return context.SaveChanges() == 1;
        }
        public static bool Delete(int id) {
            var user = context.Users.Find(id);
            if(user == null) { return false; }
            var rc = Delete(user);  //use other delete method
            return rc;
        }
    }
}
