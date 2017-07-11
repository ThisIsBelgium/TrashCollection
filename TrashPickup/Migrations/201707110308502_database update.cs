namespace TrashPickup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AmountofDaysUnpaid", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "ContactNumber");
            DropColumn("dbo.AspNetUsers", "AmountDaysOwed");
            DropColumn("dbo.AspNetUsers", "DayCounter");
            DropColumn("dbo.AspNetUsers", "WeekCounter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "WeekCounter", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DayCounter", c => c.String());
            AddColumn("dbo.AspNetUsers", "AmountDaysOwed", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ContactNumber", c => c.String());
            DropColumn("dbo.AspNetUsers", "AmountofDaysUnpaid");
        }
    }
}
