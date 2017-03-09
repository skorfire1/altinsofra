using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace altinsofra
{
  public  class helper
    {
        public void custonexception(DbEntityValidationException e,string functionname,string source,params string [] parametre )
        {
            var context = new altinsofraDbEntities();

            string message = "";
            foreach (var eve in e.EntityValidationErrors)
            {


                message = "Entity of type" + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State + "has the following validation errors:";
                foreach (var ve in eve.ValidationErrors)
                {
                    message += "- Property:" + ve.PropertyName + ", Error:" + ve.ErrorMessage + "";

                }
            }
            var log = new ExceptionLog();

            log.Message = message;

            log.FunctionName =functionname;
            log.Source =source;
            if (parametre.Length>0)
            {
                List<ExceptionInParameter> parameters = new List<ExceptionInParameter>();


                foreach (var item in parametre)
                {
                    parameters.Add(new ExceptionInParameter() { Parameter = item });


                }
                log.ExceptionInParameters = parameters;

            }
            
           

            context.ExceptionLogs.Add(log);
            context.SaveChanges();

        }

    }
    public static class Helper
    {
        public static string Serializer<T>(this T obj)
        {
            var a = JsonConvert.SerializeObject(obj).ToString();

            return a;
        }
    }
}
