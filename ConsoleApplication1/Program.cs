using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using altinsofra;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            UserDb db=new UserDb();

            var user = db.getUsers();
        }
    }
}
