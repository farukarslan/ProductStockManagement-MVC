using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace yeniProje.Models
{
    public class urunCONTEXT:DbContext
    {
        public urunCONTEXT(): base("sqlim")
        {

        }
        public DbSet<urun> urunler { get; set; }

    }
}