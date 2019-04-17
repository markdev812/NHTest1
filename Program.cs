using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;



namespace NHTest
{


    class Program
    {

        static void Main(string[] args)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            using (var tx = session.BeginTransaction())
            {
                var appInst = from a in session.Query<AppInstance>()
                              select a;

                foreach (var ai in appInst)
                {
                    Console.WriteLine($"{ai.Id} {ai.AppName} {ai.AppVersion}");
                }

            }



            NHibernateHelper.CloseSession();

            Console.ReadKey();
        }
    }
}
