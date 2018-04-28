namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateEstadoesWitRegiaos : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (12, 'Acre', 'AC', 11)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (27, 'Alagoas', 'AL', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (16, 'Amapá', 'AP', 11)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (13, 'Amazonas', 'AM', 11)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (29, 'Bahia', 'BA', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (23, 'Ceará', 'CE', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (53, 'Distrito Federal', 'DF', 15)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (32, 'Espírito Santo', 'ES', 13)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (52, 'Goiás', 'GO', 15)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (21, 'Maranhão', 'MA', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (51, 'Mato Grosso', 'MT', 15)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (50, 'Mato Grosso do Sul', 'MS', 15)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (31, 'Minas Gerais', 'MG', 13)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (15, 'Pará', 'PA', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (25, 'Paraíba', 'PB', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (41, 'Paraná', 'PR', 14)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (26, 'Pernambuco', 'PE', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (22, 'Piauí', 'PI', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (33, 'Rio de Janeiro', 'RJ', 13)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (24, 'Rio Grande do Norte', 'RN', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (43, 'Rio Grande do Sul', 'RS', 14)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (11, 'Rondônia', 'RO', 11)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (14, 'Roraima', 'RR', 11)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (42, 'Santa Catarina', 'SC', 14)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (35, 'São Paulo', 'SP', 13)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (28, 'Sergipe', 'SE', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (17, 'Tocantins', 'TO', 11)");
        }
        
        public override void Down()
        {
        }
    }
}
