using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemi_Takip
{
    public class Seferler
    {
        public int ID { get; set; }
        public int GemiSeriNo { get; set; }
        public int Kaptan1ID { get; set; }
        public int Kaptan2ID { get; set; }
        public int MurettebatID { get; set; }
        public DateTime YolcuGirisTarihi { get; set; }
        public DateTime DonusTarihi { get; set; }
        public string KalkisLimanı { get; set; }

        [ForeignKey("GemiSeriNo")]
        public Gemiler Gemi { get; set; }

        [ForeignKey("Kaptan1ID")]
        public Kaptanlar Kaptan1 { get; set; }

        [ForeignKey("Kaptan2ID")]
        public Kaptanlar Kaptan2 { get; set; }

        [ForeignKey("MurettebatID")]
        public Murettebat Murettebat { get; set; }
    }
}
