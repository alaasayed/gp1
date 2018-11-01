using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Collections;
using System.Xml;
using DotNetWikiBot;
// AdmAuthentication admAuth = new AdmAuthentication("gpproject1", "/MiaaTuasuq7if2bxG1VLIaxZiAuyRvIvlszTv1FgwA=");

namespace WIKIAPPLICATION
{
    class WIKI
    {
        //https://en.wikipedia.org/wiki/Ahmed_Zewail
        //"https://www.google.com.eg/search?q="+query1+"&ie=utf-8&oe=utf-8&gws_rd=cr&ei=eyGdVYKFOOT8ywPi8onABA#q=WIKI"
        public static string searchWiki(string query1)
        {
            string url = "https://www.google.com.eg/search?q=" + query1 + "&ie=utf-8&oe=utf-8&gws_rd=cr&ei=eyGdVYKFOOT8ywPi8onABA#q=WIKI";
            int i = 0, index11 = 0, i11, i12  ;
            string s1, s2, s3, t12,t1;
            // Creates an HttpWebRequest with the specified URL. 
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            // Sends the HttpWebRequest and waits for the response.	
            try
            {
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                // Gets the stream associated with the response.
                Stream receiveStream = myHttpWebResponse.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding("windows-1251");
                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(receiveStream, encode);
                Console.WriteLine("\r\nResponse stream received.");
                Char[] read = new Char[256];
                // Reads 256 characters at a time.     
                int count = readStream.Read(read, 0, 256);

                s1 = "";

                while (count > 0)
                {
                    // Dumps the 256 characters on a string and displays the string to the console.
                    String str = new String(read, 0, count);
                    //Console.Write(str);
                    s1 = s1.Insert(i, str);
                    i++;
                    count = readStream.Read(read, 0, 256);
                }
                System.IO.File.WriteAllText("resp.txt", s1);
                s2 = "https://en.wikipedia.org/wiki/";
                //s1 = System.IO.File.ReadAllText("resp.txt");

                index11 = s1.IndexOf(s2);
                s1 = s1.Substring(index11, s1.Length - index11);
                s1 = s1.Replace("<b>", "");
                s1 = s1.Replace("</b>", "");
                System.IO.File.WriteAllText("respre.txt", s1);
                index11 = s1.IndexOf(s2);
                i11 = index11 + s2.Length;
                // i12 = s1.IndexOf("%",i11);
                if (i11 < 0)
                    Console.WriteLine("error text not exist");
                i12 = s1.IndexOfAny(new char[] { '@', '.', ',', '!', '>', '\"', '%', '\'', '&', '<' }, i11);
                if (i12 < 0)
                    Console.WriteLine("error text not exist");
                s3 = s1.Substring(i11, i12 - i11);
                // s3 = s1.Substring(index11 + s2.Length, i2-index11+s2);
                Console.WriteLine("\ntitle==\n" + s3);

                Site site1 = new Site("https://en.wikipedia.org", "alaasayed44", "lusture44");
                
                Page p1 = new Page(site1, s3);
                p1.LoadWithMetadata();
                while(!p1.Exists())
                {
                    Console.WriteLine("loop of page");
                    s2 = "https://en.wikipedia.org/wiki/";
                  // s1 = System.IO.File.ReadAllText("resp.txt");

                    index11 = s1.IndexOf(s2,i12);
                    s1 = s1.Substring(index11, s1.Length - index11);
                    s1 = s1.Replace("<b>", "");
                    s1 = s1.Replace("</b>", "");
                  //  System.IO.File.WriteAllText("respre.txt", s1);
                    index11 = s1.IndexOf(s2);
                    i11 = index11 + s2.Length;
                    // i12 = s1.IndexOf("%",i11);
                    if (i11 < 0)
                        Console.WriteLine("error text not exist");
                    i12 = s1.IndexOfAny(new char[] { '@', '.', ',', '!', '>', '\"', '%','?', '\'', '&', '<' }, i11);
                    
                    if (i12 < 0)
                        Console.WriteLine("error text not exist");
                    s3 = s1.Substring(i11, i12 - i11);

                    p1 = new Page(site1, s3);
                    p1.LoadWithMetadata();
                    Console.WriteLine("\ntitle no "+p1.title);

                }
                Console.WriteLine("\ntitle no " + p1.title);
                //System.IO.File.WriteAllText("respreloop.txt", s1);
               p1 = new Page(site1, s3);
                p1.LoadWithMetadata();
                p1.SaveToFile("h1.txt");
                t12 = p1.text;//written filetext
                System.IO.File.WriteAllText("respbefrem.txt", t12);
                t1 = remove(t12);
                string titl1 = p1.title;
               
              
                 
                // Releases the resources of the response.
                
                myHttpWebResponse.Close();
                //  Releases the resources of the Stream.
                readStream.Close();
               
                return t1;

            }
            catch
            {
                Console.WriteLine("error in connection ");
                return null;

            }
        }

        public static string searchWiki(string query, int size)
        {
            string result = searchWiki(query);
            if (size >= result.Length)
                size = result.Length - 1;
            return result.Substring(0, size);
        }

        private static string remove(string s1)
        {
            string str3, t4, t5;
            t5 = s1;
            t4 = s1;
            int ri0, ri1, itr0, ri01, ri00,ri4 ;
              ri4 = t5.IndexOf("'''");
                if (ri4 > 0)
                {

                    t4 = t4.Substring(ri4,t5.Length-ri4);
                        
                     
                }
            //removing  <>
            itr0 = 0;
            try
            {
                while (itr0 < t4.Length)
                {

                    ri0 = t4.IndexOf("<");
                    if (ri0 < 0) break;
                    ri1 = t4.IndexOf(">", ri0);

                    if (t4.Substring(ri1 + 1, 1) == "<")
                    {

                        t5 = t4.Remove(ri0, ri1 - ri0);
                    }
                    else
                        t5 = t4.Remove(ri0, ri1 - ri0 + 2);
                    itr0 = ri1;
                    t4 = t5;

                }
                 Console.WriteLine("loop of <>");
                 //removing  ()
            itr0 = 0;
            
                while (itr0 < t4.Length)
                {

                    ri0 = t4.IndexOf("(");
                    if (ri0 < 0) break;
                    ri1 = t4.IndexOf(")", ri0);

                    if (t4.Substring(ri1 + 1, 1) == "(")
                    {

                        t5 = t4.Remove(ri0, ri1 - ri0);
                    }
                    else
                        t5 = t4.Remove(ri0, ri1 - ri0 + 2);
                    itr0 = ri1;
                    t4 = t5;

                }
                //remove url
                itr0 = 0;
                while (itr0 < t4.Length)
                {

                    ri0 = t4.IndexOf("url");
                    if (ri0 < 0) break;
                    ri1 = t4.IndexOf("|", ri0);


                    t5 = t4.Remove(ri0, ri1 - ri0);
                    itr0 = ri1;
                    t4 = t5;

                }
                //Console.WriteLine("loop of url");
                //remove ]]
                itr0 = 0;
                while (itr0 < t4.Length)
                {
                    ri1 = 0;
                    ri0 = t4.IndexOf("[[", ri1);
                    if (ri0 < 0) break;
                    t5 = t4.Remove(ri0, 2);

                    ri1 = t4.IndexOf("]]", ri0);
                    if (ri1 < 0) break;
                    t5 = t4.Remove(ri1, 2);
                    ri1 = ri1 - 2;
                    itr0 = ri1 + 2;

                    t4 = t5;

                }
                //Console.WriteLine("loop of ]]");
                //remove [[
                itr0 = 0;
                while (itr0 < t4.Length)
                {
                    ri1 = 0;
                    ri0 = t4.IndexOf("[[", ri1);
                    if (ri0 < 0) break;
                    t5 = t4.Remove(ri0, 2);
                    ri1 = ri1 - 2;
                    itr0 = ri1 + 2;
                    t4 = t5;

                }
                //Console.WriteLine("loop of [[");
                //remove }}
                itr0 = 0;
                while (itr0 < t4.Length)
                {
                    ri00 = 0;
                    ri01 = t4.IndexOf("{{", ri00);
                    if (ri01 < 0) break;
                    t5 = t4.Remove(ri01, 2);
                    ri00 = t4.IndexOf("}}", ri01);
                    if (ri00 < 0) break;
                    t5 = t4.Remove(ri00, 2);
                    itr0 = ri00 + 2;
                    t4 = t5;
                }
                //Console.WriteLine("loop of}}");
                //remove {{
                itr0 = 0;
                while (itr0 < t4.Length)
                {
                    ri1 = 0;
                    ri0 = t4.IndexOf("{{", ri1);
                    if (ri0 < 0) break;
                    t5 = t4.Remove(ri0, 2);
                    ri1 = ri1 - 2;
                    itr0 = ri1 + 2;
                    t4 = t5;

                }
                //  Console.WriteLine("loop of {{");
                //remove '''''
                itr0 = 0;
                while (itr0 < t4.Length)
                {
                    ri1 = 0;
                    ri0 = t4.IndexOf("'''''", ri1);
                    if (ri0 < 0) break;
                    t5 = t4.Remove(ri0, 5);
                    ri1 = ri1 - 2;
                    itr0 = ri1 + 2;
                    t4 = t5;

                }
                // Console.WriteLine("loop of '''''");
                //remove | & = & < &> &{} &' ...


                t5 = t5.Replace("|", " or ");
                //t5 = t5.Replace("=", " is ");
                t5 = t5.Replace("<", "");
                t5 = t5.Replace(">", "");
                t5 = t5.Replace("{", "");
                t5 = t5.Replace("}", "");
                t5 = t5.Replace("'", "");
                t5 = t5.Replace("...", "");

                //get introduction


                Console.WriteLine("remo");
                str3 = t5;

                return str3;
            }

            catch
            {

                Console.WriteLine("error in trimming");
                return null;
            }
        }

    }
}
