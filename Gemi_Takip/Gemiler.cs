using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemi_Takip
{
    public class Gemiler
    {
        public int SeriNo { get; set; }
        public string Ad { get; set; }
        public decimal Agirlik { get; set; }
        public int YapimYili { get; set; }
        public string Tip { get; set; }
        public int Kapasite { get; set; }
        public decimal MaxAgirlik { get; set; }
        public decimal PetrolKapasitesi { get; set; }
        public int KonteynerKapasitesi { get; set; }
    }
}
