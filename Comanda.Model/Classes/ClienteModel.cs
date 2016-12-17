using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comanda.Model.Classes
{
    /// <summary>
    /// Tabela Cliente
    /// </summary>
    public class ClienteModel
    {
        public ClienteModel()
        {
            this.Pedidos = new HashSet<PedidosModel>();            
        }
        /// <summary>
        /// Chave Primária da Tabela Cliente
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ClienteId { get; set; }
        /// <summary>
        /// Nome do cliente, campo obrigatório
        /// </summary>       
        public string Nome { get; set; }
        /// <summary>
        /// Comentário em relação ao nome. 
        /// Ex:. Nome: João Comentário: Da esquina
        ///      Nome: João Comentário: Do trabalho
        /// </summary>        
        public string Comentario { get; set; }
        /// <summary>
        /// Lista Pedidos
        /// </summary>
        public virtual ICollection<PedidosModel> Pedidos { get; set; }        
    }
}
