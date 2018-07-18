using SqlServerUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGenApi
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Server = localhost; User = sa; Password = vista1; Database = Multivista";
            Multivista multivista = new Multivista(connectionString);

            Multivista.DboCompany c = (from e in multivista.dboCompany
                     orderby e.companyID descending
                     select e).First();

            Console.WriteLine($"{c.companyName} {c.companyID}");

            Console.ReadKey();
        }
    }
}
