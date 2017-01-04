using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comanda.Model.Classes
{
    public class SituacaoModel
    {
        public SituacaoModel()
        {
            this.Pedidos = new HashSet<PedidosModel>();            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int SituacaoId { get; set; }
        public string Descricao { get; set; }
        /// <summary>
        /// Lista Pedidos
        /// </summary>
        public virtual ICollection<PedidosModel> Pedidos { get; set; }      
    }
}
