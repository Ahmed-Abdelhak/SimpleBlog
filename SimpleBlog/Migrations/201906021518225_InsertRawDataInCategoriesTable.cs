namespace SimpleBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InsertRawDataInCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO categories VALUES ('SPORT')
INSERT INTO categories VALUES ('FASHION')
INSERT INTO categories VALUES ('HEALTH')
INSERT INTO categories VALUES ('NEWS')


                  ");
        }

        public override void Down()
        {
        }
    }
}
