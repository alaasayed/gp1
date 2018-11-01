using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIKIAPPLICATION
{
    class Program
    {
        static void Main(string[] args)
        {
           // Program p = new Program();
            string text1;
            Console.WriteLine("please enter query");
            string query1 = Console.ReadLine();
            // for example "anis mansour","ahmed zewail", "harry potter","harry potter","ocr","egypt","sheldon";
            //Program p1 = new Program();
            text1 = WIKI.searchWiki(query1);
            if (text1 == null) Console.WriteLine("null text");
            else
            {
                //text1 = WIKI.searchWiki(query1,20);
                Console.WriteLine("\nTest.............................\n");
                System.IO.File.WriteAllText("output.txt", text1);
                Console.WriteLine("\nread output file\n");
            }
          Console.ReadLine();
        }
    }
}
