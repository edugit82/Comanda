using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Comanda.Model.Classes;
using Comanda.DataAccess.Maps;

namespace Comanda.DataAccess.Contexts
{
    public class PedidosContext : DbContext
    {
        public PedidosContext() : base("PedidosContext")
        {

        }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<PedidosModel> Pedidos { get; set; }
        public DbSet<SituacaoModel> Situacao { get; set; }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Configurations.Add(new ClientesMap());
            modelBuilder.Configurations.Add(new ProdutosMap());
            modelBuilder.Configurations.Add(new PedidosMap());
            modelBuilder.Configurations.Add(new SituacaoMap());            
        }
    }
}
