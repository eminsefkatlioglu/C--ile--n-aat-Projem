using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefkat.Entity
{
    public class Ev
    {
        public int ID { get; set; }
        public string SatılıkKiralık { get; set; }
        public string İl { get; set; }
        public string İlce { get; set; }
        public string Semt { get; set; }
        public string Mahalle { get; set; }
        public string Resim { get; set; }
        public int Fiyat { get; set; }
    }
}
