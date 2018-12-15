namespace CnBrito.AgendaContatos.Data.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "agendaContatos.Contato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("agendaContatos.Usuario", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "agendaContatos.Email",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Endereco = c.String(nullable: false, maxLength: 100, unicode: false),
                        IdContato = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("agendaContatos.Contato", t => t.IdContato, cascadeDelete: true)
                .Index(t => t.IdContato);
            
            CreateTable(
                "agendaContatos.Telefone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 50, unicode: false),
                        Numero = c.String(maxLength: 20, unicode: false),
                        IdContato = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("agendaContatos.Contato", t => t.IdContato, cascadeDelete: true)
                .Index(t => t.IdContato);
            
            CreateTable(
                "agendaContatos.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Login = c.String(nullable: false, maxLength: 20, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("agendaContatos.Contato", "IdUsuario", "agendaContatos.Usuario");
            DropForeignKey("agendaContatos.Telefone", "IdContato", "agendaContatos.Contato");
            DropForeignKey("agendaContatos.Email", "IdContato", "agendaContatos.Contato");
            DropIndex("agendaContatos.Telefone", new[] { "IdContato" });
            DropIndex("agendaContatos.Email", new[] { "IdContato" });
            DropIndex("agendaContatos.Contato", new[] { "IdUsuario" });
            DropTable("agendaContatos.Usuario");
            DropTable("agendaContatos.Telefone");
            DropTable("agendaContatos.Email");
            DropTable("agendaContatos.Contato");
        }
    }
}
