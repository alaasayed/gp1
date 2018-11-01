using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebmvcApplication22.Models
{
    public class WebmvcApplication22Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebmvcApplication22Context() : base("name=WebmvcApplication22Context")
        {
        }

        public System.Data.Entity.DbSet<WebmvcApplication22.DAL.user> users { get; set; }

        public System.Data.Entity.DbSet<WebmvcApplication22.DAL.stockuser> stockusers { get; set; }
    }
}
