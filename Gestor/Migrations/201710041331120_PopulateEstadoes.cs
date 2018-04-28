namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateEstadoes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (12, 'Acre', 'AC', 1)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (27, 'Alagoas', 'AL', 2)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (16, 'Amap�', 'AP', 1)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (13, 'Amazonas', 'AM', 1)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (29, 'Bahia', 'BA', 2)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (23, 'Cear�', 'CE', 2)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (53, 'Distrito Federal', 'DF', 5)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (32, 'Esp�rito Santo', 'ES', 3)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (52, 'Goi�s', 'GO', 5)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (21, 'Maranh�o', 'MA', 2)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (51, 'Mato Grosso', 'MT', 5)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (50, 'Mato Grosso do Sul', 'MS', 5)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (31, 'Minas Gerais', 'MG', 3)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (15, 'Par�', 'PA', 2)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (25, 'Para�ba', 'PB', 2)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (41, 'Paran�', 'PR', 4)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (26, 'Pernambuco', 'PE', 2)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (22, 'Piau�', 'PI', 2)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (33, 'Rio de Janeiro', 'RJ', 3)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (24, 'Rio Grande do Norte', 'RN', 2)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (43, 'Rio Grande do Sul', 'RS', 4)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (11, 'Rond�nia', 'RO', 1)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (14, 'Roraima', 'RR', 1)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (42, 'Santa Catarina', 'SC', 4)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (35, 'S�o Paulo', 'SP', 3)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (28, 'Sergipe', 'SE', 2)");
            Sql("Insert into Estadoes (CodigoUf, Descricao, Uf, Regiao) values (17, 'Tocantins', 'TO', 1)");
        }

        public override void Down()
        {
        }
    }
}
