using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Comanda.Model.Classes;
using Comanda.DataAccess.Maps;

namespace Comanda.DataAccess.Contexts
{
    internal class PedidosContext : DbContext
    {
        internal PedidosContext() : base("PedidosContext")
        {

        }
        internal DbSet<ClienteModel> Clientes { get; set; }
        internal DbSet<ProdutoModel> Produtos { get; set; }
        internal DbSet<PedidosModel> Pedidos { get; set; }
        internal DbSet<SituacaoModel> Situacao { get; set; }        

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
