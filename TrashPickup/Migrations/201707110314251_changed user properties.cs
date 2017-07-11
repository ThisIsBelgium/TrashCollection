namespace TrashPickup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeduserproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ContactNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ContactNumber");
        }
    }
}