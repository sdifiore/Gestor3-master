using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gestor.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("SqlServer", throwIfV1Schema: false)
        {
        }

        public DbSet<Aditivo> Aditivos { get; set; }
        public DbSet<Ajuste> Ajustes { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CategoriaCliente> CategoriasCliente { get; set; }
        public DbSet<ClasseCusto> ClassesCusto { get; set; }
        public DbSet<Carga> Cargas { get; set; }
        public DbSet<CondicaoPreco> CondicoesPrecos { get; set; }
        public DbSet<Comum> Comuns { get; set; }
        public DbSet<Cotacao> Cotacoes { get; set; }
        public DbSet<CuboEstoque> CubosEstoque { get; set; }
        public DbSet<CuboTrabalhado> CubosTrabalhados { get; set; }
        public DbSet<CustoFolha> CustoFolhas { get; set; }
        public DbSet<CustoCargoDireto> CustoCargoDiretos { get; set; }
        public DbSet<CustoInsumo> CustoInsumos { get; set; }
        public DbSet<DespesaExportacao> DespesasExportacao { get; set; }
        public DbSet<DespesaFixa> DespesasFixas { get; set; }
        public DbSet<DfxProdRev> DfxProdRevs { get; set; }
        public DbSet<Dominio> Dominios { get; set; }
        public DbSet<Embal> Embals { get; set; }
        public DbSet<Extrusora> Extrusoras { get; set; }
        public DbSet<EncapTubo> EncapTuboes { get; set; }
        public DbSet<Estrutura> Estruturas { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<FatHistorico> FatHistoricos { get; set; }
        public DbSet<Finalidade> Finalidades { get; set; }
        public DbSet<Frete> Fretes { get; set; }
        public DbSet<Graxa> Graxas { get; set; }
        public DbSet<GrupoRateio> GruposRateio { get; set; }
        public DbSet<IcmsFrete> IcmsFretes { get; set; }
        public DbSet<Indice> Indices { get; set; }
        public DbSet<IndiceRateioFormacaoPrecoVenda> IndiceRateioFormacaoPrecoVendas { get; set; }
        public DbSet<IndiceRateioLucratividade> IndiceRateioLucratividades { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Linha> Linhas { get; set; }
        public DbSet<LogData> LogData { get; set; }
        public DbSet<Lubrificante> Lubrificantes { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<MedidaFita> MedidaFitas { get; set; }
        public DbSet<Memoria> Memorias { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
        public DbSet<PadraoFixo> PadroesFixos { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<ParmGraxa> ParmGraxas { get; set; }
        public DbSet<Pcp> Pcps { get; set; }
        public DbSet<PlanejCompra> PlanejCompras { get; set; }
        public DbSet<PlanejMod> PlanejMods { get; set; }
        public DbSet<PlanejProducao> PlanejProducoes { get; set; }
        public DbSet<PlanejVenda> PlanejVendas { get; set; }
        public DbSet<PreForma> PreFormas { get; set; }
        public DbSet<PrecoExportacao> PrecosExpostacao { get; set; }
        public DbSet<PrecoNacional> PrecosNacionais { get; set; }
        public DbSet<PrensaPreForma> PrensasPreForma { get; set; }
        public DbSet<ProcTubo> ProcTubos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<QtdEmbalagem> QtdEmbalagems { get; set; }
        public DbSet<QtdMaquinas> QtdMaquinas { get; set; }
        public DbSet<Quadro> Quadros { get; set; }
        public DbSet<QuadroPercentual> QuadrosPercentuais { get; set; }
        public DbSet<Rateio> Rateios { get; set; }
        public DbSet<Regiao> Regioes { get; set; }
        public DbSet<Resina> Resinas { get; set; }
        public DbSet<ResinaBase> ResinasBase { get; set; }
        public DbSet<ResinaPtfe> ResinasPtfe { get; set; }
        public DbSet<SemanaEstoque> SemanasEstoque { get; set; }
        public DbSet<Sequencia> Sequencias { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Sucata> Sucatas { get; set; }
        public DbSet<TdHistorico> TdHistoricos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<TipoAlteracao> TiposAlteracao { get; set; }
        public DbSet<TipoCliente> TiposCliente { get; set; }
        public DbSet<TipoProducao> TiposProducao { get; set; }
        public DbSet<TipoVenda> TiposVenda { get; set; }
        public DbSet<TotalParmGraxa> TotalParmGraxas { get; set; }
        public DbSet<Uf> Ufs { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}