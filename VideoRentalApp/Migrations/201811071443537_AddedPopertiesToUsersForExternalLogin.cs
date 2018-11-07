namespace VideoRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPopertiesToUsersForExternalLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "HomeTown", c => c.String());
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "HomeTown");
        }
    }
}
