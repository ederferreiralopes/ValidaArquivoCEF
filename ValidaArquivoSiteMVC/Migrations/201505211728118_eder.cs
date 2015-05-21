namespace ValidaArquivoSiteMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eder : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "Arquivo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, precision: 0),
                        Nome = c.String(unicode: false),
                        Tipo = c.String(unicode: false),
                        Validacao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id)                ;
            
        }
        
        public override void Down()
        {
            DropTable("Arquivo");
            DropTable("Usuario");
        }
    }
}
