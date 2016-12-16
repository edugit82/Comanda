using Comanda.Model.Classes;
using System.Data.Entity.ModelConfiguration;

namespace Comanda.DataAccess.Maps
{
    public class ClientesMap : EntityTypeConfiguration<ClienteModel>
    {
        public ClientesMap() : base()
        {
            HasKey(x => x.ClienteId);

            Property(x => x.ClienteId).HasColumnName("ClientId");
            Property(x => x.Nome).HasColumnName("Nome");
            Property(x => x.Comentario).HasColumnName("Comentario");

            ToTable("dbo.Clientes");
        }
    }
}
