using Comanda.Model.Classes;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comanda.DataAccess.Maps
{
    internal class ClientesMap : EntityTypeConfiguration<ClienteModel>
    {
        internal ClientesMap() : base()
        {
            HasKey(x => x.ClienteId);

            Property(x => x.ClienteId).HasColumnName("ClienteId");            
            Property(x => x.Nome).HasColumnName("Nome");
            Property(x => x.Comentario).HasColumnName("Comentario");

            ToTable("dbo.Clientes");
        }
    }
}
