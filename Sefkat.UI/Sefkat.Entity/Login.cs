using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sefkat.Entity
{
    public class Login
    {
        public int ID { get; set; } 
        public string Kadi { get; set; }
        public string Sifre { get; set; }    


    }
}
