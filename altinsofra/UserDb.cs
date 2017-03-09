using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace altinsofra
{
    public class UserDb
    {
        public List<User> getUsers()
        {
            try
            {
                using (var context = new altinsofraDbEntities())

                {
                    var users = context.Users.ToList();

                    return users.Count >0 ? users : null;

                }


            }
            catch (DbEntityValidationException e)
            {

                helper hp = new helper();
                hp.custonexception(e, "getusers", "userdb");


                return null;

            }
            ;

        }

        public User getUserById(int _id)
        {
            try
            {
                using (var context = new altinsofraDbEntities())
                {
                    if (_id != 0)
                    {
                        var user = context.Users.Find(_id);
                        return user;

                    }
                    else
                    {
                        return null;
                    }

                }

            }
            catch (DbEntityValidationException e)
            {
                helper hp = new helper();
                hp.custonexception(e, "getuserbyid", "userdb");

                return null;
            }
        }

        public User addUser(User user)
        {

            try
            {
                using (var context = new altinsofraDbEntities())
                {
                    context.Users.Add(user);
                    int result = context.SaveChanges();
                    return result > 0 ? user : null;

                }

            }
            catch (DbEntityValidationException e)
            {
                helper hp = new helper();
                hp.custonexception(e, "adduser", "userdb", user.Serializer());

                throw;
            }

        }

        public User blockeUser(int _id)
        {
            try
            {
                using (var context = new altinsofraDbEntities())
                {
                    var selected = context.Users.Find(_id);

                    selected.IsActivated = 1;

                    int result = context.SaveChanges();

                    return result > 0 ? selected : null;

                }

            }
            catch (DbEntityValidationException e)
            {
                helper hp = new helper();
                hp.custonexception(e, "blockeuser", "userdb", _id.Serializer());
                throw;
              
            }
        }

        public User updateUser(User u)
        {
            try
            {
                using (var context=new  altinsofraDbEntities())
                {
                    var user = context.Users.Find(u.Id);
                    user.Name = u.Name;
                    user.IsActivated = u.IsActivated;
                    user.Email = u.Email;
                    user.Phone1 = u.Phone1;
                    user.Phone2 = u.Phone2;
                    user.Surname = u.Surname;
                    user.UserAdresses = u.UserAdresses;
                    u.OrderCarts = u.OrderCarts;
                    u.UserType = u.UserType;
                  int result =context.SaveChanges();
                    return result > 0 ? u : null;
                }

            }
            catch (DbEntityValidationException e)
            {
                helper hp=new helper();
                hp.custonexception(e,"updateUser","userdb",u.Serializer());

                throw;
            }
        }


    }
}

