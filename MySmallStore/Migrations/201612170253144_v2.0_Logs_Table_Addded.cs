namespace MySmallStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v20_Logs_Table_Addded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        LogText = c.String(maxLength: 50),
                        LogDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LogID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Log");
        }
    }
}
