namespace ValidaArquivoSiteMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agoravai2 : DbMigration
    {
        public override void Up()
        {
            DropTable("Usuario");
        }
        
        public override void Down()
        {
            CreateTable(
                "Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(unicode: false),
                        Senha = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
        }
    }
}
