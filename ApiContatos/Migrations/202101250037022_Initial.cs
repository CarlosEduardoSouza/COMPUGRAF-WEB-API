namespace ApiContatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Sobrenome = c.String(nullable: false, maxLength: 30),
                        Nacionalidade = c.String(nullable: false, maxLength: 30),
                        CEP = c.String(nullable: false, maxLength: 9),
                        CPF = c.String(nullable: false, maxLength: 11),
                        Estado = c.String(nullable: false, maxLength: 30),
                        Cidade = c.String(nullable: false, maxLength: 50),
                        Logradouro = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 50),
                        Telefone = c.String(nullable: false, maxLength: 16),
                    })
                .PrimaryKey(t => t.PessoaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pessoas");
        }
    }
}
