using Comanda.Model.Classes;
using System.Data.Entity.ModelConfiguration;

namespace Comanda.DataAccess.Maps
{
    public class PedidosMap : EntityTypeConfiguration<PedidosModel>
    {
        public PedidosMap() : base()
        {
            HasKey(x => x.DataHora);

            Property(x => x.DataHora).HasColumnName("DataHora");
            Property(x => x.Qtd).HasColumnName("Qtd");

            Property(x => x.ClienteId).HasColumnName("ClienteId");
            Property(x => x.ProdutoId).HasColumnName("ProdutoId");
            Property(x => x.SituacaoId).HasColumnName("SituacaoId");

            HasRequired<ClienteModel>(x => x.Cliente).WithMany(x => x.Pedidos);
            HasRequired<ProdutoModel>(x => x.Produto).WithMany(x => x.Pedidos);
            HasRequired<SituacaoModel>(x => x.Situacao).WithMany(x => x.Pedidos);            

            ToTable("dbo.Pedidos");
        }
    }
}
