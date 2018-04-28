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
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (16, 'Amap�', 'AP', 11)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (13, 'Amazonas', 'AM', 11)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (29, 'Bahia', 'BA', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (23, 'Cear�', 'CE', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (53, 'Distrito Federal', 'DF', 15)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (32, 'Esp�rito Santo', 'ES', 13)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (52, 'Goi�s', 'GO', 15)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (21, 'Maranh�o', 'MA', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (51, 'Mato Grosso', 'MT', 15)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (50, 'Mato Grosso do Sul', 'MS', 15)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (31, 'Minas Gerais', 'MG', 13)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (15, 'Par�', 'PA', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (25, 'Para�ba', 'PB', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (41, 'Paran�', 'PR', 14)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (26, 'Pernambuco', 'PE', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (22, 'Piau�', 'PI', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (33, 'Rio de Janeiro', 'RJ', 13)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (24, 'Rio Grande do Norte', 'RN', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (43, 'Rio Grande do Sul', 'RS', 14)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (11, 'Rond�nia', 'RO', 11)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (14, 'Roraima', 'RR', 11)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (42, 'Santa Catarina', 'SC', 14)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (35, 'S�o Paulo', 'SP', 13)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (28, 'Sergipe', 'SE', 12)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, RegiaId) values (17, 'Tocantins', 'TO', 11)");
        }
        
        public override void Down()
        {
        }
    }
}
