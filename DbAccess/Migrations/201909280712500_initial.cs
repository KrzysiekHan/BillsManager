namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillId = c.Int(nullable: false, identity: true),
                        DueAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DueDate = c.DateTime(nullable: false),
                        Periodical = c.Boolean(nullable: false),
                        Description = c.String(),
                        RecipientId = c.Int(nullable: false),
                        BillTypeDictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillId)
                .ForeignKey("dbo.BillTypeDicts", t => t.BillTypeDictId, cascadeDelete: true)
                .ForeignKey("dbo.Recipients", t => t.RecipientId, cascadeDelete: true)
                .Index(t => t.RecipientId)
                .Index(t => t.BillTypeDictId);
            
            CreateTable(
                "dbo.BillTypeDicts",
                c => new
                    {
                        BillTypeDictId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BillTypeDictId);
            
            CreateTable(
                "dbo.Recipients",
                c => new
                    {
                        RecipientId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Address = c.String(),
                        Account = c.String(),
                        CustomerServiceUrl = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RecipientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "RecipientId", "dbo.Recipients");
            DropForeignKey("dbo.Bills", "BillTypeDictId", "dbo.BillTypeDicts");
            DropIndex("dbo.Bills", new[] { "BillTypeDictId" });
            DropIndex("dbo.Bills", new[] { "RecipientId" });
            DropTable("dbo.Recipients");
            DropTable("dbo.BillTypeDicts");
            DropTable("dbo.Bills");
        }
    }
}
