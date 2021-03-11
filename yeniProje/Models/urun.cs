using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yeniProje.Models
{
    public class urun
    {
        public int id { get; set; }
        public string urunismi { get; set; }
        public double fiyati { get; set; }
        public int adet { get; set; }
        public string aciklama { get; set; }

    }
}