using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comanda.Model.Classes
{
    /// <summary>
    /// Tabela Produto
    /// </summary>
    public class ProdutoModel
    {
        public ProdutoModel()
        {
            
        }
        /// <summary>
        /// Chave primária da tabela Produto
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProdutoId { get; set; }
        /// <summary>
        /// Descrição do Produto.
        /// </summary>        
        public string Descricao { get; set; }
        /// <summary>
        /// Preço do produto.
        /// </summary>        
        public double Preco { get; set; }
        /// <summary>
        /// Lista Pedidos
        /// </summary>
        public virtual ICollection<PedidosModel> Pedidos { get; set; }        

    }
}
