using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolebingapp
{
    class main
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Run...");
            string str1,fromlang,tolang,s1;
            Console.WriteLine("please  enter word thenfromlang then to lang");
             str1=Console.ReadLine();
             fromlang = Console.ReadLine();
           tolang = Console.ReadLine();
           //  string result = Translator.translate("en", "كتاب", "ar");

             string result = Translator.translate(tolang, str1, fromlang);
            Console.WriteLine(result);
            //result = Translator.translate(tolang, "الكلب يجري في الحديقة", null);
            //Console.WriteLine(result);
            s1 = Console.ReadLine();
            Console.ReadKey(true);
        }
    }
}
