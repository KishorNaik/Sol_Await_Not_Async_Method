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

            #region return value from task on non async method

            System.Console.WriteLine(GetString());

            #endregion

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


        #region return value from task on non async method

        private static String GetString()
        {
            String Str = String.Empty;
            Task.Factory.StartNew(() =>
            {
                Str = "Hello Async";
                return Str;
            }).Wait();

            return Str;
        }

        #endregion
    }
}
