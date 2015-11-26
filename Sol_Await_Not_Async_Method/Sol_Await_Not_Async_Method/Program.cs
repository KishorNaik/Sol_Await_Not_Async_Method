using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Await_Not_Async_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 
            Task.Run(async() =>
            {
                await SetStringMsg();
            }).Wait();

            Task.Run(() => System.Console.WriteLine("Hello Async Direct")).Wait();

            #endregion


            #region Task Return 

            Task.Run(async() =>
            {
                String Str = await SetStringMsg("Kishor", "Naik");
                System.Console.WriteLine(Str);
            }).Wait();

           Task.Run(() =>
           {
               System.Console.WriteLine("{0} {1}", "Kishor", "Naik");
           }).Wait();

            #endregion

            RunTask(() => { System.Console.WriteLine("Kishor Naik"); });

        }

        private static Task SetStringMsg()
        {
            return Task.Run(() => System.Console.WriteLine("Hello Async"));
        }


        private static Task<String> SetStringMsg(String FirstName, String LastName)
        {
            return Task.Run<String>(() =>
            {
                return String.Format("{0} {1}", FirstName, LastName);
            });
        }

        private static void RunTask(Action ActionObj)
        {
            Task.Run(ActionObj).Wait();
        }
    }
}
