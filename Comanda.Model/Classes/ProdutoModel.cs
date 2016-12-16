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
            this.Clientes = new HashSet<ClienteModel>();
        }
        /// <summary>
        /// Chave primária da tabela Produto
        /// </summary>
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
        /// Lista Clientes
        /// </summary>
        public virtual ICollection<ClienteModel> Clientes { get; set; }

    }
}
