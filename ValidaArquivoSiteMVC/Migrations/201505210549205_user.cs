namespace ValidaArquivoSiteMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Validacao",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, precision: 0),
                        Nome = c.String(unicode: false),
                        Tipo = c.String(unicode: false),
                        Validacao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Validacao");
        }
    }
}
