using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace altinsofra
{
    public class OrderedDb
    {
        public Ordered AddOrdered(Ordered ordered)
        {
            try
            {
                using (var context=new altinsofraDbEntities())
                {
                    context.Ordereds.Add(ordered);
                   int result=context.SaveChanges();
                    return (result > 0) ? ordered : null;

                }

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }



        }
    }
}
