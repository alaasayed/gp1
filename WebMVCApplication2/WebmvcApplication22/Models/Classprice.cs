using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebmvcApplication22.DAL;

namespace WebmvcApplication22.Models
{
    public class Classprice
    {
        string u1;
        int p1;

        public string U1
        {
            get
            {
                return u1;
            }

            set
            {
                u1 = value;
            }
        }

        public int P1
        {
            get
            {
                return p1;
            }

            set
            {
                p1 = value;
            }
        }
    }
}