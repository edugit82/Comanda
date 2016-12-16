using Comanda.Model.Classes;
using System.Data.Entity.ModelConfiguration;

namespace Comanda.DataAccess.Maps
{
    public class ProdutosMap : EntityTypeConfiguration<ProdutoModel>
    {
        public ProdutosMap() : base()
        {
            HasKey(x => x.ProdutoId);

            Property(x => x.ProdutoId).HasColumnName("ProdutoId");
            Property(x => x.Descricao).HasColumnName("Descricao");
            Property(x => x.Preco).HasColumnName("Preco");

            ToTable("dbo.Produtos");
        }        
    }
}
