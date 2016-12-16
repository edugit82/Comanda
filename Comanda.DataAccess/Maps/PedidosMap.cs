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

            ToTable("dbo.Pedidos");
        }
    }
}
