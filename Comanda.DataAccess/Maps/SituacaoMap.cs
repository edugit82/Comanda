using Comanda.Model.Classes;
using System.Data.Entity.ModelConfiguration;

namespace Comanda.DataAccess.Maps
{
    public class SituacaoMap : EntityTypeConfiguration<SituacaoModel>
    {
        public SituacaoMap()
        {
            HasKey(x => x.SituacaoId);

            Property(x => x.SituacaoId).HasColumnName("SituacaoId");
            Property(x => x.Descricao).HasColumnName("Descricao");

            ToTable("dbo.Situacao");
        }
    }
}
