using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemi_Takip
{
    public class GemiContext : DbContext
    {
        //veritabanı ve tablolar bağlantısı sağlanıyor
        public GemiContext()
        {
            Database.Connection.ConnectionString = "server=NURDAN\\SQLEXPRESS;database=GemiDB;uid=sa;pwd=123";
        }
        public DbSet<Gemiler> GEMILER { get; set; }
        public DbSet<Kaptanlar> KAPTANLAR { get; set; }
        public DbSet<Kullanıcılar> KULLANICILAR { get; set; }
        public DbSet<Limanlar> LIMANLAR { get; set; }
        public DbSet<Murettebat> MURETTEBAT { get; set; }
        public DbSet<Seferler> SEFERLER { get; set; }
    }
}
