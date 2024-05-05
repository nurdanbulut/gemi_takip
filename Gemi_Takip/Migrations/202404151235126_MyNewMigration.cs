namespace Gemi_Takip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyNewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gemilers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Agirlik = c.Decimal(nullable: false, precision: 18, scale: 2),
                        YapimYili = c.Int(nullable: false),
                        Tip = c.String(),
                        Kapasite = c.Int(nullable: false),
                        MaxAgirlik = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PetrolKapasitesi = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KonteynerKapasitesi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Kaptanlars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        Adres = c.String(),
                        Vatandaslik = c.String(),
                        DogumTarihi = c.DateTime(nullable: false),
                        IseGirisTarihi = c.DateTime(nullable: false),
                        Lisans = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Kullanıcılar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Limanlars",
                c => new
                    {
                        Ad = c.String(nullable: false, maxLength: 128),
                        Ulke = c.String(),
                        Nufus = c.Int(nullable: false),
                        PasaportGerekli = c.Boolean(nullable: false),
                        DemirlemeUcreti = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Ad);
            
            CreateTable(
                "dbo.Mucrets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        Adres = c.String(),
                        Vatandaslik = c.String(),
                        DogumTarihi = c.DateTime(nullable: false),
                        IseGirisTarihi = c.DateTime(nullable: false),
                        Gorev = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Seferlers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GemiSeriNo = c.Int(nullable: false),
                        Kaptan1ID = c.Int(nullable: false),
                        Kaptan2ID = c.Int(nullable: false),
                        MucretID = c.Int(nullable: false),
                        YolcuGirisTarihi = c.DateTime(nullable: false),
                        DonusTarihi = c.DateTime(nullable: false),
                        KalkisLimanı = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gemilers", t => t.GemiSeriNo, cascadeDelete: true)
                .ForeignKey("dbo.Kaptanlars", t => t.Kaptan1ID, cascadeDelete: true)
                .ForeignKey("dbo.Kaptanlars", t => t.Kaptan2ID, cascadeDelete: true)
                .ForeignKey("dbo.Mucrets", t => t.MucretID, cascadeDelete: true)
                .Index(t => t.GemiSeriNo)
                .Index(t => t.Kaptan1ID)
                .Index(t => t.Kaptan2ID)
                .Index(t => t.MucretID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seferlers", "MucretID", "dbo.Mucrets");
            DropForeignKey("dbo.Seferlers", "Kaptan2ID", "dbo.Kaptanlars");
            DropForeignKey("dbo.Seferlers", "Kaptan1ID", "dbo.Kaptanlars");
            DropForeignKey("dbo.Seferlers", "GemiSeriNo", "dbo.Gemilers");
            DropIndex("dbo.Seferlers", new[] { "MucretID" });
            DropIndex("dbo.Seferlers", new[] { "Kaptan2ID" });
            DropIndex("dbo.Seferlers", new[] { "Kaptan1ID" });
            DropIndex("dbo.Seferlers", new[] { "GemiSeriNo" });
            DropTable("dbo.Seferlers");
            DropTable("dbo.Mucrets");
            DropTable("dbo.Limanlars");
            DropTable("dbo.Kullanıcılar");
            DropTable("dbo.Kaptanlars");
            DropTable("dbo.Gemilers");
        }
    }
}
