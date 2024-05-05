using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemi_Takip
{
    public class Limanlar
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Ulke { get; set; }
        public int Nufus { get; set; }
        public decimal DemirlemeUcreti { get; set; }
    }
}
