namespace ValidaArquivoSiteMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usu2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Login = c.String(unicode: false),
                        Senha = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
        }
        
        public override void Down()
        {
            DropTable("Usuario");
        }
    }
}
